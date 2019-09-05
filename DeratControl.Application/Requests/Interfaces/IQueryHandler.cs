using System;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Interfaces
{
    public interface IQueryHandler<in TRequest> where TRequest : IRequest
    {
        Task<CommandResult> Handle (CommandExecutionContext executionContext, TRequest request);
    }
}
