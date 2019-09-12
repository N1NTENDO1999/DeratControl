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
        Task<CommandResult> Handle (CommandExecutionContext executionContext, TRequest request);
    }

}
