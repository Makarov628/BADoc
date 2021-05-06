using System;
using BADoc.UseCases.DTO;

namespace BADoc.Web.Utils
{
    public interface IJwtGenerator
    {
        string CreateToken(GetUserDTO user);
    }
}