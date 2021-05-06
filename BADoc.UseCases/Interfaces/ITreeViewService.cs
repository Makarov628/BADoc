using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using BADoc.UseCases.DTO;

namespace BADoc.UseCases.Interfaces
{
    public interface ITreeViewService
    {
        Task<List<GetTreeViewDTO>> GetTreeView(Guid? rootId = null);
        Task<List<GetTreeViewDTO>> GetTreeWithParentsOnly(Guid? rootId = null);
        Task AddNode(CreateNodeDTO createNode);
        Task UpdateNode(UpdateNodeDTO updateNode);
        Task DeleteNode(DeleteNodeDTO deleteNode); 
    }
}