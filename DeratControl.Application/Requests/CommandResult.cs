using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Requests
{
    public class CommandResult
    {

    }

    public class CommandCreateResult<TKey> : CommandResult where TKey : struct
    {
        public TKey Id { get; }

        public CommandCreateResult(TKey key)
        {
            Id = key;
        }
    }
}
