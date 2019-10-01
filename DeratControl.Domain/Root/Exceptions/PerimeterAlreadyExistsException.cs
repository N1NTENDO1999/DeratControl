﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public class PerimeterAlreadyExistsException : DomainException
    {
        public PerimeterAlreadyExistsException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
