using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Traps.Commands.SetTrap;
using DeratControl.Application.Traps.Queries.ViewTrapByPoint;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrapController : ControllerBase
    {
        private CommandDispatcher _commandDispatcher;
        private QueryDispatcher _queryDispatcher;

        public TrapController(CommandDispatcher cdis, QueryDispatcher qdis)
        {
            this._queryDispatcher = qdis;

            this._commandDispatcher = cdis;
        }

        [HttpPost]
        [Route("/settrap")]
        public async Task<CommandResult> SetTrap(SetTrapCommand request)
        {
            return await this._commandDispatcher.Dispatch(request);
        }

        [HttpGet]
        [Route("/gettrap/{pointid}")]
        public async Task<TrapViewModelResult> GetTrap(int pointid)
        {
            return await this._queryDispatcher.Dispatch<ViewTrapQuery, TrapViewModelResult>(new ViewTrapQuery() { PointId = pointid });
        }
    }
}