using Geovenci.Data.Entities;
using Geovenci.Data.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data
{
    public class GeovenciAppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbSet<MapProject> MapProjects { get; set; }

        public DbSet<HistoricalChanges> HistoricalChanges { get; set; }
        public DbSet<Layer> Layers { get; set; }

        public DbSet<MapLayerUser> MapLayerUsers { get; set; }

        public GeovenciAppDbContext(DbContextOptions<GeovenciAppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeovenciAppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateEntities();

            AuditEntities();

            return base.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync(string userId = null)
        {
            UpdateEntities();

            AuditEntities();

            var result = await base.SaveChangesAsync();
            return result;
        }

        //public virtual override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    UpdateEntities();

        //    AuditEntities();

        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        public async Task<int> SaveChangesFromSourceAsync(string modificationSource,
            CancellationToken cancellationToken = default)
        {
            UpdateEntities();

            AuditEntities(modificationSource);

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntities()
        {
            var now = DateTime.UtcNow;

            var addedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            var updatedModifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

            var deletedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            if(addedEntities.Any())
            {
                UpdateAddedEntities(addedEntities, now);

            }

            if (updatedModifiedEntities.Any()) 
            {
                UpdateModifiedEntities(updatedModifiedEntities, now);
            }

            if (deletedEntities.Any()) 
            {
                DeletedEntities(deletedEntities, now);
            }

        }

        private void AuditEntities(string? modificationSource = default) 
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted));

            try {

                var historicalChanges = entries
                    .Select(e => e.Audit(modificationSource))
                    .Where(c => c.ModificationJsonData != "[]")
                    .ToList();

                // Historical Changes.
                if (historicalChanges.Count() != 0)
                {
                    AddRange(historicalChanges);
                    SaveChanges();
                }
            } catch (Exception ex) {

                Console.WriteLine(ex);
            }
            
        
        }

        private void UpdateAddedEntities(IEnumerable<EntityEntry> entries, DateTime timeStamp) 
        {
            
            foreach(var entry in entries) 
            {
                if (entry.Entity is EntityBase eb) 
                {
                    eb.CreatedAtUtc = timeStamp;
                    eb.CreatedBy = GetCurrentUserId();
                }
            }
        }

        private void UpdateModifiedEntities(IEnumerable<EntityEntry> entries, DateTime timeStamp)
        {
            foreach (var entry in entries) 
            {
                if (entry.Entity is EntityBase eb) 
                {
                    eb.UpdatedAtUtc = timeStamp;
                    eb.UpdatedBy = GetCurrentUserId();
                }
            }
        
        }

        private void DeletedEntities(IEnumerable<EntityEntry> entries, DateTime timeStamp) 
        {

            foreach (var entry in entries)
            {
                if (entry.Entity is EntityBase eb)
                {
                    eb.UpdatedAtUtc = timeStamp;
                    eb.UpdatedBy = GetCurrentUserId();
                    eb.IsDeleted = true;
                }
            }
        }


        private string GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            return identity?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
