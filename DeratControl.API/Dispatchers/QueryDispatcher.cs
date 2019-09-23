using System;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Application.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DeratControl.Security;
using DeratControl.Domain.Security;

namespace DeratControl.API.Dispatchers
{
    public class QueryDispatcher
    {
        private readonly IHttpContextAccessor _context;

        public QueryDispatcher(IHttpContextAccessor context)
        {
            this._context = context;

        }

       public async Task<TResult> Dispatch<TRequest,TResult>(TRequest command) where TRequest : IRequest where TResult:IQueryResult
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command),
                                                "Command can not be null.");


            if (!this._context.HttpContext.User.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException();

            var unitOfWork = (IUnitOfWork)this._context.HttpContext.RequestServices.
              GetService(typeof(IUnitOfWork));

            int userId = await ((IAuthService)this._context.HttpContext.RequestServices.
                GetService(typeof(IAuthService))).GetUserByName(this._context.HttpContext.User.Identity.Name);

            User currentUser = await unitOfWork.UserRepository.FindByIdAsync(userId);

            if (currentUser == null)
                throw new NullReferenceException("User was not found");

            var handler = (IQueryHandler<TRequest,TResult>)this._context.HttpContext.RequestServices.
                GetService(typeof(IQueryHandler<TRequest,TResult>));

            CommandExecutionContext commandExeContext = new CommandExecutionContext(currentUser);

            return await handler.Handle(commandExeContext, command);
        }
    }
}
