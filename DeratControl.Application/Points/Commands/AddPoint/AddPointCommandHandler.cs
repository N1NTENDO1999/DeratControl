using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;
using DeratControl.Application.Requests.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Points.Commands.AddPoint
{
    public class AddPointCommandHandler : BaseCommandHandler<AddPointCommand>
    {
        protected override Task<CommandResult> HandleRequest(CommandExecutionContext executionContext, AddPointCommand request)
        {
            throw new NotImplementedException();
        }

        protected override void AssertRequestIsValid(AddPointCommand request)
        {
            
        }
    }
}
