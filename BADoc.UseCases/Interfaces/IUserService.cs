using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using BADoc.UseCases.DTO;

namespace BADoc.UseCases.Interfaces
{
    public interface IUserService
    {
        Task Create(CreateUserDTO userDTO);

        Task<GetUserDTO> CheckCredentials(CheckCredentialsDTO credentialsDTO);

        Task ChangePassword(UpdateUserPasswordDTO userPasswordDTO);

        Task Delete(DeleteUserDTO userDTO);
    }
}