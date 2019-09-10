using System;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DeratControl.Application.Interfaces
{
    public class CommandDispatcher
    {
        private IHttpContextAccessor _context;

        public CommandDispatcher(IHttpContextAccessor context)
        {
            this._context = context;
        }

        async Task<CommandResult>  Dispatch<TRequest>(TRequest command)where TRequest : IRequest
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

            ICommandHandler<TRequest>handler= (ICommandHandler<TRequest>)this._context.HttpContext.RequestServices.
                GetService(typeof(ICommandHandler<TRequest>));

            int userId =int.Parse(this._context.HttpContext.User.Identity.Name);

            IRepository<User, int> userRepo =(IRepository<User, int>)this._context.HttpContext.RequestServices.
                GetService(typeof(IRepository<User,int>));

            User currentUser = userRepo.FindById(userId);

            CommandExecutionContext commandExeContext = new CommandExecutionContext() { requestedUser=currentUser};

            return await handler.Handle(commandExeContext,command);
        }
    }
}
