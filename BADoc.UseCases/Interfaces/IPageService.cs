using System;
using System.Threading.Tasks;

using BADoc.UseCases.DTO;

namespace BADoc.UseCases.Interfaces
{
    public interface IPageService
    {
        Task<GetPageDTO> Get(Guid id);
        Task Update(UpdatePageDTO updatePage);
    }
}