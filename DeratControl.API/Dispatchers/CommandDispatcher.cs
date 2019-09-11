using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests;

namespace DeratControl.API.Dispatchers
{
    public class CommandDispatcher
    {
        /*private readonly CommandExecutionContext _context;

        public CommandDispatcher(CommandExecutionContext context)
        {
            _context = context;
        }

        public CommandResult Dispatch<TCommandHandler>(TCommandHandler command) 
            where TCommandHandler : IRequest
        {
            Func<TCommandHandler> handler;


            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                                                "Command can not be null.");
            }

            var _handler = handler.Invoke<ICommandHandler<TCommandHandler>>();
            return _handler.Retrieve(command);*/
        }
    }
}
