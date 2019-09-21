using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class OrganizationNotExistException : DomainException
    {
        public OrganizationNotExistException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
