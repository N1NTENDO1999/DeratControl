﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class PointDoesNotExistException : DomainException
    {
        public PointDoesNotExistException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
