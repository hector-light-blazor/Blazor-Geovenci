using Geovenci.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Geovenci.Data.Extension
{
    public static class EntityEntryExtension
    {
        public static int? GetEntityId(this EntityEntry entry) 
        {
            var values = entry.State == EntityState.Deleted ? entry.OriginalValues : entry.CurrentValues;
            if (values.Properties != null && values.Properties.Any(p => p.Name.Equals("Id")))
            {
                if (values.TryGetValue<int>("Id", out var value)) 
                {
                    return value;
                }                  
            }

            return null;
        }

        public static HistoricalChanges Audit(this EntityEntry entry, string? source = default) 
        {
            var entityId = entry.GetEntityId();
            var entityName = entry.Entity.GetType().Name;
            var modificationType = entry.State.ToString();
            var modifications = entry.GetModifications();

            return new HistoricalChanges
            {
                EntityId = entityId ?? -1,
                Name = entityName,
                ModificationSource = source,
                ModificationType = modificationType,
                ModificationJsonData = JsonConvert.SerializeObject(modifications),
                CreateDateUtc = DateTime.UtcNow,
            };
        }

        public static IEnumerable<Modification> GetModifications(this EntityEntry entry) 
        {
            var modifications = new HashSet<Modification>();

            foreach (var property in entry.Properties.Where(p => p.IsModified))
            {
                var modification = new Modification
                {
                    PropertyName = property.Metadata.Name
                };

                switch (entry.State)
                {
                    case EntityState.Modified:
                        modification.CurrentValue = property.CurrentValue?.ToString();
                        modification.OriginalValue = property.OriginalValue?.ToString();
                        break;
                    case EntityState.Deleted:
                        modification.CurrentValue = property.CurrentValue?.ToString();
                        modification.OriginalValue = property.OriginalValue?.ToString();
                        break;
                }
                modifications.Add(modification);
            }


            return modifications;
        }
    }
}
