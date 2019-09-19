using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.Domain.Security;
using DeratControl.Security;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        [Route("signIn")]
        public Task<SignInResponse<string>> SignIn([FromBody]SignInRequest signInRequest)
        {
            var response= authService.SignIn(signInRequest);
            return response;
        }
        [HttpPost]
        [Route("/signOut")]
        public Task<SignOutResponse> SignOut(SignOutRequest signOutRequest)
        {
            return authService.SignOut(signOutRequest);
        }
    }
}