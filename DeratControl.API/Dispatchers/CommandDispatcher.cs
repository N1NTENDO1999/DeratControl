using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Security.Claims;

namespace DeratControl.Application.Interfaces
{
    public class CommandDispatcher
    {
        private IHttpContextAccessor _context;

        public CommandDispatcher(IHttpContextAccessor context)
        {
            this._context = context;
        }

        async Task<CommandResult>  Dispatch<T>(T command)where T : IRequest
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                                                "Command can not be null.");
            }

            else if (!this._context.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            ICommandHandler<T>handler= (ICommandHandler<T>)this._context.HttpContext.RequestServices.GetService(typeof(ICommandHandler<T>));

            int userId =int.Parse(this._context.HttpContext.User.Identity.Name);

            IRepository<User, int> userRepo =(IRepository<User, int>)this._context.HttpContext.RequestServices.GetService(typeof(IRepository<User,int>));

            User currentUser = userRepo.FindById(userId);

            CommandExecutionContext commandExeContext = new CommandExecutionContext() { requestedUser=currentUser};

            return await handler.Handle(commandExeContext,command);
        }
    }
}
