using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class PerimeterDoesNotExists : DomainException
    {
        public PerimeterDoesNotExists(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
