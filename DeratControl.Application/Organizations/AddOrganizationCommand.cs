using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Organizations
{
    public class AddOrganizationCommand : IRequest
    {
        public string Name { get; set; }

        public string CreatedBy { get; set; }


    }

    public class AddOrganizationCommandHendler : ICommandHandler<AddOrganizationCommand>
    {
        private readonly IOrganizationRepository organizationRepository;

        public AddOrganizationCommandHendler(IOrganizationRepository organizationRepository)
        {
            this.organizationRepository = organizationRepository;
        }
        public async Task<CommandResult> Handle(CommandExecutionContext executionContext, AddOrganizationCommand request)
        {
            if (IsValidRequest(request))
            {
                var entity = new Organization(request.Name, executionContext.RequestedUser.FirstName + executionContext.RequestedUser.LastName);
                if (organizationRepository.IsExists(entity))
                {
                    throw new Exception();
                }
                else
                {
                    organizationRepository.Add(entity);
                    return new CommandCreateResult<int>(entity.Id);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private bool IsValidRequest(AddOrganizationCommand request)
        {
            if (request == null)
            {
                return false;
            }
            else if (request.Name.Equals(string.Empty) || request.CreatedBy.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
