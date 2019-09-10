using System;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Application.Interfaces;
using DeratControl.Domain.Root;
using DeratControl.Application.Requests;
using DeratControl.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DeratControl.Application.Interfaces
{
    public class QueryDispatcher
    {
        private IHttpContextAccessor _context;

        public QueryDispatcher(IHttpContextAccessor context)
        {
            this._context = context;
        }

        async Task<TResult> Dispatch<TRequest,TResult>(TRequest command) where TRequest : IRequest where TResult:IQueryResult
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

            IQueryHandler<TRequest,TResult> handler = (IQueryHandler<TRequest,TResult>)this._context.HttpContext.RequestServices.
                GetService(typeof(IQueryHandler<TRequest,TResult>));

            int userId = int.Parse(this._context.HttpContext.User.Identity.Name);

            IRepository<User, int> userRepo = (IRepository<User, int>)this._context.HttpContext.RequestServices.
                GetService(typeof(IRepository<User, int>));

            User currentUser = userRepo.FindById(userId);

            CommandExecutionContext commandExeContext = new CommandExecutionContext() { requestedUser = currentUser };

            return await handler.Handle(commandExeContext, command);
        }
    }
}
