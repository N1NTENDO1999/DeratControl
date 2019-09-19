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
        private CommandDispatcher _commanddispatcher;
        private QueryDispatcher _queryDispatcher;

        public PointController(CommandDispatcher cdis,QueryDispatcher qdis )
        {
            this._queryDispatcher = qdis;

            this._commanddispatcher = cdis;
        }

        [HttpPost]
        [Route("/addpoint")]
        public async Task<CommandResult> AddPoints(AddPointsCommand request)
        {
            return await this._commanddispatcher.Dispatch(request);
        }

        [HttpGet]
        [Route("/getpoints/{perimeterid}")]
        public async Task<PointsViewModelResult> GetPoints(int perimeterid)
        {
            return await this._queryDispatcher.Dispatch<GetPointsQuery,PointsViewModelResult>(new GetPointsQuery() {PerimeterId=perimeterid });
        }
    }
}