using System;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DeratControl.Application.Interfaces;
using DeratControl.Domain.Security;
using DeratControl.Security;

namespace DeratControl.API.Dispatchers
{
    public class CommandDispatcher
    {
        private readonly IHttpContextAccessor _context;

        public CommandDispatcher(IHttpContextAccessor context)
        {
            this._context = context;
        }

       public async Task<CommandResult>  Dispatch<TRequest>(TRequest command)where TRequest : IRequest
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command),
                                                "Command can not be null.");
            
             if (!this._context.HttpContext.User.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException();

            var userRepo = (IRepository<User, int>)this._context.HttpContext.RequestServices.
              GetService(typeof(IRepository<User, int>));

            int userId = await ((IAuthService)this._context.HttpContext.RequestServices.
                 GetService(typeof(IAuthService))).GetUserByName(this._context.HttpContext.User.Identity.Name);
            User currentUser = userRepo.FindById(userId);

            if (currentUser == null)
                throw new NullReferenceException();

            var commandExeContext = new CommandExecutionContext(currentUser);

            var handler= (ICommandHandler<TRequest>)this._context.HttpContext.RequestServices.
                GetService(typeof(ICommandHandler<TRequest>));

            return await handler.Handle(commandExeContext,command);
        }
    }
}
