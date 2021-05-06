using System;

namespace BADoc.Web.DTO
{
    public class ErrorDTO
    {
        public string Message { get; set; }

        public static ErrorDTO Create(string message) => new ErrorDTO()
        {
            Message = message
        };
    }
}