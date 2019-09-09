using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Security
{
    class SignInResponse<T>
    {
        public string Email { get; set; }
        public T UserId { get; set; }
        public Token Token { get; set; }
    }
}
