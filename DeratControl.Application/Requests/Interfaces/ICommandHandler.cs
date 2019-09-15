using System;
using DeratControl.Application.Requests;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Requests.Interfaces;

namespace DeratControl.Application.Interfaces
{
    public interface ICommandHandler<in TRequest> where TRequest : IRequest
    {
        Task<CommandResult> Handle(CommandExecutionContext executionContext, TRequest request);
    }
    
    public abstract class BaseCommandHandler<TRequest> : ICommandHandler<TRequest> where TRequest : IRequest
    {
        public Task<CommandResult> Handle(CommandExecutionContext executionContext, TRequest request)
        {
            AssertRequestIsValid(request);

            return HandleRequest(executionContext, request);
        }

        protected abstract Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, TRequest request);

        protected virtual void AssertRequestIsValid(TRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}
