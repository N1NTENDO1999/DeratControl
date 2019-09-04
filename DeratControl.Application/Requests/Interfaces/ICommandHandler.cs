using System;
using DeratControl.Application.Requests;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Interfaces
{
    public interface ICommandHandler<in TRequest> where TRequest : IRequest
    {
        CommandResult Handle (TRequest request);
    }

}
