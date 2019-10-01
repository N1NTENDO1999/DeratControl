using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Perimeters.Commands;
using DeratControl.Application.Perimeters.Queries.GetPerimetersList;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Facilities.Commands;
using DeratControl.Application.Facilities.Queries.GetFacilitiesList;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly CommandDispatcher commandDispatcher;
        private readonly QueryDispatcher queryDispatcher;
        public FacilityController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
        }
        [HttpPost]
        [Route("/AddFacility")]
        public async Task<CommandResult> AddFacility(AddFacilityCommand request)
        {
            return await this.commandDispatcher.Dispatch<AddFacilityCommand>(request);
        }

        [HttpGet]
        [Route("/GetFacilities/{id}")]
        public async Task<FacilityViewModel> GetFacilities(int id)
        {
            return await this.queryDispatcher.Dispatch<GetFacilityQuery, FacilityViewModel>(new GetFacilityQuery() { FacilityId = id });
        }
    }
}
