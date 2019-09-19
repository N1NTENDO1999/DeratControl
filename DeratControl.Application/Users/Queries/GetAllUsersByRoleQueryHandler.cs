using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Domain.Root;

namespace DeratControl.Application.Users.Queries
{
    class GetAllUsersByRoleQueryHandler : IQueryHandler<GetUsersQuery, UsersViewModelResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllUsersByRoleQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<UsersViewModelResult> Handle(CommandExecutionContext executionContext, GetUsersQuery request)
        {
            var users = unitOfWork.UserRepository.FindRoleById(request.RoleId);
            if (users == null)
            {
                throw new ArgumentException();
            }
            return Task.FromResult(new UsersViewModelResult(){Users = users});
            
        }
    }
}
