using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class OrganizationAlreadyExistsException : DomainException
    {
        public OrganizationAlreadyExistsException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
