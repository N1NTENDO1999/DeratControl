﻿using DeratControl.Application.Interfaces;
using DeratControl.Application.Organizations;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Entities;
using DeratControl.Domain.Root;
using DeratControl.Domain.Root.Exceptions;
using DeratControl.Domain.Root.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Organizations
{
    public class AddOrganizationCommand : IRequest
    {
        public string OrganizationName { get; set; }
    }

    public class AddOrganizationCommandHandler : BaseCommandHandler<AddOrganizationCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        //TODO : inject IUnitOfWork insted of IOrganizationRepository when avaliable
        public AddOrganizationCommandHandler(IUnitOfWork organizationRepository)
        {
            this.unitOfWork = organizationRepository;
        }

        protected override async Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddOrganizationCommand request)
        {
            if (await this.unitOfWork.OrganizationRepository.Exists(request.OrganizationName))
            {
                throw new OrganizationAlreadyExistsException();
            }

            var entity = new Organization(request.OrganizationName, executionContext.RequestedUser);
            await this.unitOfWork.OrganizationRepository.AddAsync(entity);

            await this.unitOfWork.Commit();

            return new CommandCreateResult<int>(entity.Id);
        }

        protected override void AssertRequestIsValid(AddOrganizationCommand request)
        {
            base.AssertRequestIsValid(request);

            if (string.IsNullOrEmpty(request.OrganizationName))
            {
                throw new ArgumentNullException(nameof(request.OrganizationName));
            }
        }
    }
}
