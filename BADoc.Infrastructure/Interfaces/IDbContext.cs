using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BADoc.Entities.Models;

namespace BADoc.Infrastructure.Interfaces
{
    public interface IDbContext 
    {
        DbSet<Category> Categories { get; }
        DbSet<Contact> Contacts { get; }
        DbSet<Page> Pages { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}