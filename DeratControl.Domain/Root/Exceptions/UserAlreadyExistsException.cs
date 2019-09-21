namespace DeratControl.Domain.Root.Exceptions
{
    public class UserAlreadyExistsException : DomainException
    {
        public UserAlreadyExistsException(string message, int statusCode) : base(message, statusCode)
        {
        }
    }
}
