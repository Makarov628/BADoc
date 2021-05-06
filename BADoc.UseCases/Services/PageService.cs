using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BADoc.UseCases.DTO;
using BADoc.UseCases.Interfaces;
using BADoc.Infrastructure.Interfaces;
using BADoc.UseCases.Exceptions;

namespace BADoc.UseCases.Services
{
    public class PageService : IPageService
    {
        private readonly IDbContext _dbContext;
        public PageService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetPageDTO> Get(Guid id)
        {
            var page = await _dbContext.Pages.FirstOrDefaultAsync(p => p.Id == id);
            
            if (page == null)
            {
                throw new NotFoundException();
            }

            return GetPageDTO.FromPage(page);
        }

        public async Task Update(UpdatePageDTO updatePage)
        {
            var page = await _dbContext.Pages.FirstOrDefaultAsync(p => p.Id == updatePage.Id);
            
            if (page == null)
            {
                throw new NotFoundException();
            }

            _dbContext.Pages.Update(updatePage.ToPage(page));
            await _dbContext.SaveChangesAsync();
        }
    }
}