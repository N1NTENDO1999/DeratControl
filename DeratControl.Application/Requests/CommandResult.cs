using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Application.Requests
{
    public class CommandResult
    {

    }
    public class CommandCreateResult<Tkey>  : CommandResult where Tkey : struct
    {
        public Tkey Id { get; set; }
        public CommandCreateResult(Tkey id)
        {
            this.Id = id;
        }
    }
}
