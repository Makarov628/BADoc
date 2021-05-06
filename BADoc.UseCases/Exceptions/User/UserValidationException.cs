using System;

namespace BADoc.UseCases.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message)
        {
            Message = message;
        }
        public override string Message { get; }
    }
}