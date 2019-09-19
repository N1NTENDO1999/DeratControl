using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Users;
using DeratControl.Domain.Security;
using DeratControl.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private CommandDispatcher comdispatcher;
        private IAuthService authService;

        public AdminController(CommandDispatcher comdispatcher, IAuthService authService)
        {
            this.comdispatcher = comdispatcher;
            this.authService = authService;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeCommand request)
        {
            var result = (CommandCreateResult<int>) await comdispatcher.Dispatch(request);
            await authService.Register(result.Id,request.Email,request.Password,"ADMIN");
            return Ok();

        }
    }
}