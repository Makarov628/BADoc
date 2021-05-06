using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BADoc.UseCases.DTO;

namespace BADoc.UseCases.Interfaces
{
    public interface IContactService
    {
        Task<GetContactDTO> Get(Guid id);

        Task<List<GetContactDTO>> GetAll();

        Task Create(CreateContactDTO createContact);

        Task Update(UpdateContactDTO updateContact);

        Task Delete(DeleteContactDTO deleteContact);
    }
}