using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BADoc.UseCases.DTO;
using BADoc.UseCases.Interfaces;
using BADoc.Infrastructure.Interfaces;
using BADoc.UseCases.Exceptions;

namespace BADoc.UseCases.Services
{
    public class ContactService : IContactService
    {
        private readonly IDbContext _dbContext;

        public ContactService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetContactDTO> Get(Guid id)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();

            if (contact == null)
            {
                throw new NotFoundException();
            }


            return GetContactDTO.FromContact(contact);
        }

        public async Task<List<GetContactDTO>> GetAll()
        {
            var contacts = await _dbContext.Contacts.Select(contact =>
                GetContactDTO.FromContact(contact)
            ).ToListAsync();

            await _dbContext.SaveChangesAsync();

            return contacts;
        }
        public async Task Create(CreateContactDTO createContact)
        {
            _dbContext.Contacts.Add(createContact.ToContact());
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateContactDTO updateContact)
        {
            try
            {
                _dbContext.Contacts.Update(updateContact.ToContact());
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new NotFoundException();
            }

        }

        public async Task Delete(DeleteContactDTO deleteContact)
        {
            try
            {
                _dbContext.Contacts.Remove(deleteContact.ToContact());
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new NotFoundException();
            }
        }

    }
}
