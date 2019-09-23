using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Points.Commands.AddPoint;
using DeratControl.Application.Points.Queries.GetPointsByPerimeter;
using DeratControl.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private CommandDispatcher _commandDispatcher;
        private QueryDispatcher _queryDispatcher;

        public PointController(CommandDispatcher cdis,QueryDispatcher qdis )
        {
            this._queryDispatcher = qdis;

            this._commandDispatcher = cdis;
        }

        [HttpPost]
        [Route("/addpoint")]
        public async Task<CommandResult> AddPoints(AddPointsCommand request)
        {
            return await this._commandDispatcher.Dispatch(request);
        }

        [HttpGet]
        [Route("/getpoints/{id}")]
        public async Task<PointViewModelResult> GetPoints(int id)
        {
            return await this._queryDispatcher.Dispatch<GetPointQuery, PointViewModelResult>(new GetPointQuery() { PointId = id });
        }
    }
}