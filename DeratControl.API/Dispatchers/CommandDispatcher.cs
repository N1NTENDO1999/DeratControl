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

            //if (!this._context.HttpContext.User.Identity.IsAuthenticated)
            //    throw new UnauthorizedAccessException();

            var unitOfWork = (IUnitOfWork)this._context.HttpContext.RequestServices.
              GetService(typeof(IUnitOfWork));

            //int userId = await ((IAuthService)this._context.HttpContext.RequestServices.
            //     GetService(typeof(IAuthService))).GetUserByName(this._context.HttpContext.User.Identity.Name);

            //User currentUser = await unitOfWork.UserRepository.FindByIdAsync(userId);

            //if (currentUser == null)
            //    throw new NullReferenceException("User was not found");

            var handler = (ICommandHandler<TRequest>)this._context.HttpContext.RequestServices.
                GetService(typeof(ICommandHandler<TRequest>));

            var commandExeContext = new CommandExecutionContext(new User("a","b","c","d","e",0));

            return await handler.Handle(commandExeContext, command);
        }
    }
}
