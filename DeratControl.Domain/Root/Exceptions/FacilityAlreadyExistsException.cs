using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class FacilityAlreadyExistsException : DomainException
    {
        public FacilityAlreadyExistsException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
