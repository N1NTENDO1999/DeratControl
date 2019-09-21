using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DeratControl.Domain.Root.Exceptions
{
    public abstract class DomainException : Exception
    {
        public string ContentType { get; set; } = @"text/plain";
        public int StatusCode { get; set; }
        public DomainException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
