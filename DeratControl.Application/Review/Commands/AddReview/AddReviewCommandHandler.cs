using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Review.Commands.AddReview
{
    public class AddReviewCommandHandler : BaseCommandHandler<AddReviewCommand>
    {
        public IUnitOfWork UnitOfWork { get; }

        public AddReviewCommandHandler(IUnitOfWork unitofwork)
        {
            this.UnitOfWork = unitofwork;
        }
        protected async override Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddReviewCommand request)
        {
            var review = this.UnitOfWork.ReviewRepository.AddAsync(new Domain.Entities.Review(DateTime.Now, Domain.Entities.Status.ToDo, request.FacilityId, request.FacilityId));
            await this.UnitOfWork.Commit();
            return new CommandCreateResult<int>(review.Id);
        }
    }
}
