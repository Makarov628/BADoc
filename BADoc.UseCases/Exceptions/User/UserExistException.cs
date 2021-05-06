using System;

namespace BADoc.UseCases.Exceptions
{
    public class UserExistsException : Exception
    {
        public override string Message => "User with this Email is exists";
    }
}