using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;

namespace DeratControl.Application.Users.Commands
{
    public sealed class AddCustomerCommand: CustomerDTO, IRequest
    {
    }
    public sealed class AddCustomerCommandHandler : BaseCommandHandler<AddCustomerCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext,
            AddCustomerCommand request)
        {
            var customer = request;

            if (unitOfWork.UserRepository.Exists(customer.Email))
                throw new UserAlreadyExistsException();
            var organization = await GetOrganizationById(customer.OrganizationId);
            var entity = new User(customer.Address, customer.Email, customer.FirstName, customer.LastName,
                customer.Phone,organization);
            await unitOfWork.UserRepository.AddAsync(entity);
            await unitOfWork.Commit();
            return new CommandCreateResult<int>(entity.Id);
        }

        private Task<Organization> GetOrganizationById(int organizationId)
        {
            return unitOfWork.OrganizationRepository.FindByIdAsync(organizationId);
        }

        protected override void AssertRequestIsValid(AddCustomerCommand request)
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
