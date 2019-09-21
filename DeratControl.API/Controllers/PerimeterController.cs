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
using DeratControl.Application.Perimeters.Queries.GetPerimeterIndividual;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerimeterController : ControllerBase
    {
        private readonly CommandDispatcher commandDispatcher;
        private readonly QueryDispatcher queryDispatcher;
        public PerimeterController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
            this.queryDispatcher = queryDispatcher;
        }
        [HttpPost]
        [Route("/AddPerimeter")]
        public async Task<CommandResult> AddPerimeter(AddPerimeterCommand request)
        {
            return await this.commandDispatcher.Dispatch<AddPerimeterCommand>(request);
        }

        [HttpGet]
        [Route("/GetPerimeter/{id}")]
        public async Task<PerimeterViewModelResult> GetPerimeter(int id)
        {
            return await this.queryDispatcher.Dispatch<GetPerimeterQuery, PerimeterViewModelResult>(new GetPerimeterQuery() { PerimeterId = id });
        }

        [HttpGet]
        [Route("/GetPerimeters/{facilityId}")]
        public async Task<PerimetersViewModelResult> GetPerimetersList(int facilityId)
        {
            return await this.queryDispatcher.Dispatch<GetPerimetersListQuery, PerimetersViewModelResult>(new GetPerimetersListQuery() { FacilityId = facilityId });
        }
    }
}