using System;
using System.Linq;
using System.Collections.Generic;

using BADoc.UseCases.DTO;

namespace BADoc.UseCases.Utils
{
    public static class TreeViewExtensions
    {

        public static List<GetTreeViewDTO> CreateTree(this List<GetTreeViewDTO> collection, Guid? parentId = default)
        {
            var level = new List<GetTreeViewDTO>();

            foreach (var node in collection.Where(n => n.ParentId == parentId))
            {
                level.Add(new GetTreeViewDTO()
                {
                    Id = node.Id,
                    Name = node.Name,
                    Type = node.Type,
                    ParentId = node.ParentId,
                    Childs = collection.CreateTree(node.Id)
                });
            }

            return level;
        }

        public static List<GetTreeViewDTO> CreateTreeIncludeRoot(this List<GetTreeViewDTO> collection, Guid? rootId)
        {
            try
            {
                GetTreeViewDTO root = collection.First(c => c.Id == rootId);
                root.Childs = collection.CreateTree(root.Id);
                return new List<GetTreeViewDTO>() { root };
            }
            catch (System.Exception)
            {
                return collection.CreateTree();
            }

        }
    }
}