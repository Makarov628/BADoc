using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using BADoc.Entities.Models;
using BADoc.Entities.Enums;
using BADoc.UseCases.Interfaces;
using BADoc.Infrastructure.Interfaces;
using BADoc.UseCases.DTO;
using BADoc.UseCases.Exceptions;
using BADoc.UseCases.Utils;

namespace BADoc.UseCases.Services
{
    public class TreeViewService : ITreeViewService
    {
        private readonly IDbContext _dbContext;

        public TreeViewService(IDbContext dbContext)
        {
            _dbContext = dbContext;
         
        }

        public async Task AddNode(CreateNodeDTO createNode)
        {
            if (createNode.Type == NodeType.Category)
            {
                _dbContext.Categories.Add(createNode.ToCategory());
            }
            else if (createNode.Type == NodeType.Page)
            {
                _dbContext.Pages.Add(createNode.ToPage());
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNode(UpdateNodeDTO updateNode)
        {
            Category category = _dbContext.Categories.Include(c => c.ParentCategory).FirstOrDefault(c => c.Id == updateNode.Id);
            Page page = _dbContext.Pages.Include(c => c.Category).FirstOrDefault(p => p.Id == updateNode.Id);
            
            if (category != null)
            {
                _dbContext.Categories.Update(updateNode.ToCategory(category));
            }
            else if (page != null)
            {
                _dbContext.Pages.Update(updateNode.ToPage(page));
            }
            else 
            {
                throw new NotFoundException();
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteNode(DeleteNodeDTO deleteNode)
        {
            Category category = _dbContext.Categories.Include(c => c.ParentCategory).FirstOrDefault(c => c.Id == deleteNode.Id);
            Page page = _dbContext.Pages.Include(p => p.Category).FirstOrDefault(p => p.Id == deleteNode.Id);
            
            if (category != null)
            {
                _dbContext.Categories.Remove(deleteNode.ToCategory(category));
            }
            else if (page != null)
            {
                _dbContext.Pages.Remove(deleteNode.ToPage(page));
            }
            else 
            {
                throw new NotFoundException();
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetTreeViewDTO>> GetTreeView(Guid? rootId = null)
        {

            
            var dtosFromCategories = await _dbContext.Categories.Select(category => GetTreeViewDTO.FromCategory(category)).ToListAsync();
            var dtosFromPages = await _dbContext.Pages.Select(page => GetTreeViewDTO.FromPage(page)).ToListAsync();

            await _dbContext.SaveChangesAsync();           

            return dtosFromCategories.Concat(dtosFromPages).ToList().CreateTreeIncludeRoot(rootId);
        }

        public async Task<List<GetTreeViewDTO>> GetTreeWithParentsOnly(Guid? rootId = null)
        {
            var dtosFromCategories = await _dbContext.Categories.Select(category => GetTreeViewDTO.FromCategory(category)).ToListAsync(); 
            await _dbContext.SaveChangesAsync();

            return dtosFromCategories.CreateTree(rootId).ToList();
        }
    }
}
