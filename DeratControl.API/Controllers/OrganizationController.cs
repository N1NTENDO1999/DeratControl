using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Organizations;
using DeratControl.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private CommandDispatcher comdispatcher;

        public OrganizationController(CommandDispatcher comdispatcher)
        {
            this.comdispatcher = comdispatcher;
        }

        [HttpPost]
        [Route("/huy")]
        public async Task<CommandResult> AddOrganization(AddOrganizationCommand request)
        {
            return await this.comdispatcher.Dispatch(request);
        }
    }
}