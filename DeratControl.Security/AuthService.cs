﻿using DeratControl.Domain.Security;
using DeratControl.Security.Infrastracture;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace DeratControl.Security
{
    class AuthService : IAuthService
    {
        private UserManager<SecurityUser> userManager;
        private SignInManager<SecurityUser> signInManager;
        public AuthService(UserManager<SecurityUser> userMng, SignInManager<SecurityUser> signInMng)
        {
            userManager = userMng;
            signInManager = signInMng;
        }

        public async Task<string> GetUserByName(string userName)
        {
            SecurityUser user = await userManager.FindByNameAsync(userName);
            if (user == null)
                throw new Exception("User not found.");
            return user.Id;
        }

        public async Task<SignInResponse<string>> SignIn(SignInRequest credentials)
        {
            SecurityUser user = await userManager.FindByNameAsync(credentials.UserName);
            if (user == null)
                throw new Exception("User not found");
            var signIn = await signInManager.PasswordSignInAsync(user, credentials.Password, true, true);

            if (signIn.Succeeded == false)
                throw new Exception("Could not sign in");

            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var claimsIdentity = new ClaimsIdentity(claims);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience:AuthOptions.AUDIENCE,
                notBefore: now,
                expires: now.AddHours(AuthOptions.LIFETIME),
                claims: claimsIdentity.Claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            SignInResponse<string> response = new SignInResponse<string>()
            {
                Token = new Token() { Expired = jwt.ValidTo, Value = encodedJwt },
                Email = credentials.UserName,
                UserId = user.Id
            };
            return response;
        }
       
        public async Task<SignOutResponse> SignOut(SignOutRequest credentials)
        {
            await signInManager.SignOutAsync();
            SignOutResponse signOutResponse = new SignOutResponse();
            return signOutResponse;
        }
    }
}