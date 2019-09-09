using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Security
{
    class Token
    {
        private DateTime Expired { get; set; }
        private string Value { get; set; }
    }
}
