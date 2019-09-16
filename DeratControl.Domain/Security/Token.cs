using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Security
{
    public class Token
    {
        public DateTime Expired { get; set; }
        public string Value { get; set; }
    }
}
