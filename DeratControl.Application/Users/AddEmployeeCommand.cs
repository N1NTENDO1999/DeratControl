using System;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using DeratControl.Domain.Root.Repositories;

namespace DeratControl.Application.Users
{
    public sealed class AddEmployeeCommand: EmployeeDTO, IRequest
    {     
    }

    public sealed class AddEmployeeCommandHandler : BaseCommandHandler<AddEmployeeCommand>
    {
        private readonly IUnitOfWork unitOfWork;
      
        public AddEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddEmployeeCommand request)
        {
            var employee = request;
            
            if (unitOfWork.UserRepository.Exists(employee.Email))
                throw new UserAlreadyExistsException();

            var entity = new User()
            {
                Address = employee.Address,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
               
            };

            await unitOfWork.UserRepository.AddAsync(entity);
            await unitOfWork.Commit();
            return new CommandCreateResult<int>(entity.Id);
        }
    }

}
