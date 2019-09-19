using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Review.Commands.AddReview;
using DeratControl.Application.Review.Queries.GetReviewsByEmpleyee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private CommandDispatcher _commandDispatcher;
        private QueryDispatcher _queryDispatcher;

        public ReviewController(CommandDispatcher cdis, QueryDispatcher qdis)
        {
            this._queryDispatcher = qdis;

            this._commandDispatcher = cdis;
        }

        [HttpPost]
        [Route("/addReview")]
        public async Task<CommandResult> AddReview(AddReviewCommand request)
        {
            return await this._commandDispatcher.Dispatch(request);
        }

        [HttpGet]
        [Route("/getReviews/{employeeid}")]
        public async Task<ReviewsDTO> GetPoints(int employeeid)
        {
            return await this._queryDispatcher.Dispatch<GetReviewsQuery, ReviewsDTO>(new GetReviewsQuery() { EmployeeId = employeeid });
        }
    }
}