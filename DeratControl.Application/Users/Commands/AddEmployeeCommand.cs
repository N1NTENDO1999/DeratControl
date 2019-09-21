using System;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DeratControl.Application.Users
{
    public sealed class AddEmployeeCommand : EmployeeDTO, IRequest
    {
    }

    public sealed class AddEmployeeCommandHandler : BaseCommandHandler<AddEmployeeCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext,
            AddEmployeeCommand request)
        {
            var employee = request;

            if (unitOfWork.UserRepository.Exists(employee.Email))
                throw new UserAlreadyExistsException("Current user already exists", StatusCodes.Status400BadRequest);

            var entity = new User(employee.Address, employee.Email, employee.FirstName, employee.LastName,
                employee.Phone,0);
            await unitOfWork.UserRepository.AddAsync(entity);
            await unitOfWork.Commit();
            return new CommandCreateResult<int>(entity.Id);
        }

        protected override void AssertRequestIsValid(AddEmployeeCommand request)
        {
            base.AssertRequestIsValid(request);
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Address) ||
                string.IsNullOrEmpty(request.FirstName) ||
                string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Phone))
            {
                throw new ArgumentNullException();
            }
        }
    }

}
