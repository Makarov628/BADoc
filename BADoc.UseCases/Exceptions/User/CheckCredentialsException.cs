using System;

namespace BADoc.UseCases.Exceptions
{
    public class CheckCredentialsException : Exception
    {
        public override string Message => "Email or Password incorrect";
    }
}