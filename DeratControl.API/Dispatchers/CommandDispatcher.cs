using System;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DeratControl.Application.Interfaces;

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

            User currentUser = userRepo.FindById(int.Parse(this._context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

            if (currentUser == null)
                throw new NullReferenceException();

            var commandExeContext = new CommandExecutionContext(currentUser);

            var handler= (ICommandHandler<TRequest>)this._context.HttpContext.RequestServices.
                GetService(typeof(ICommandHandler<TRequest>));

            return await handler.Handle(commandExeContext,command);
        }
    }
}
