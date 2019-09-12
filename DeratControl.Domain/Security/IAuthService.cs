﻿using DeratControl.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Domain.Security
{
    public interface IAuthService
    {
        Task<SignInResponse<string>> SignIn(SignInRequest credentials);
        Task<SignOutResponse> SignOut(SignOutRequest credentials);
        Task<string> GetUserByName(string userName);
    }
}