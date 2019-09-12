using System;
using DeratControl.Application.Requests;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Requests.Interfaces;

namespace DeratControl.Application.Interfaces
{
    public interface IQueryHandler<in TRequest, TResponse> where TRequest : IRequest
    {
        Task<TResponse> Handle (CommandExecutionContext executionContext, TRequest request);
    }
}
