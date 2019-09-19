
using DeratControl.API.Dispatchers;
using DeratControl.Application.Organizations;
using DeratControl.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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