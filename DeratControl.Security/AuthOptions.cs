using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Security.Infrastracture
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer"; 
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 1;
        public const string AUDIENCE = "Audience"; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }

}
