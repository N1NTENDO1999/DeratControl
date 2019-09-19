using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private CommandDispatcher comdispatcher;

        public AdminController(CommandDispatcher comdispatcher)
        {
            this.comdispatcher = comdispatcher;
        }

        [HttpPost]
        [Route("/AddEmployee")]
        public async Task<CommandResult> AddEmployee(AddEmployeeCommand request)
        {
            return await comdispatcher.Dispatch(request);
        }
    }
}