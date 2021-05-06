using System;

namespace BADoc.UseCases.Exceptions
{
    public class NotFoundException : Exception
    {
        public override string Message => "This object not exists";
    }
}