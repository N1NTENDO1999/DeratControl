using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class UserIsNotEmployeeException : DomainException
    {
        public UserIsNotEmployeeException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
