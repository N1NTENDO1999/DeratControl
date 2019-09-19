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
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly CommandDispatcher commandDispatcher;
        private readonly QueryDispatcher queryDispatcher;

        OrganizationController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        [Route("/AddOrganization")]
        public async Task<CommandResult> AddOrganization(AddOrganizationCommand request)
        {
            return await this.commandDispatcher.Dispatch<AddOrganizationCommand>(request);
        }
    }
}