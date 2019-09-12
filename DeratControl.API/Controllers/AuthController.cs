using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.Domain.Security;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult SignIn()
        {
           
        }
        public IActionResult SignOut()
        {

        }
    }
}