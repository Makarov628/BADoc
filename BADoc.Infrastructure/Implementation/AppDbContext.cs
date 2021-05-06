using System;
using System.Threading;
using System.Threading.Tasks;
using BADoc.Entities.Models;
using BADoc.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BADoc.Infrastructure.Implementation
{
    public class AppDbContext : IdentityDbContext, IDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            // this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Category>()
                .HasMany(c => c.Pages)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.Categories)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Page>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pages)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; } 

        public DbSet<Contact> Contacts { get; set; } 

        public DbSet<Page> Pages { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return base.SaveChangesAsync(token);
        }

    }
}
