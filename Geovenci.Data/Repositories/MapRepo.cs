using Geovenci.Data.Entities;
using Geovenci.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.Repositories
{
    public class MapRepo : IMapRepo
    {
        private readonly IDbContextFactory<GeovenciAppDbContext> _dbContextFactory;
        public MapRepo(IDbContextFactory<GeovenciAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<bool> CreateMapProject(MapProject map)
        {
            var mp = new MapProject();

           

            using var context = await _dbContextFactory.CreateDbContextAsync();

            context.Entry<MapProject>(mp).CurrentValues.SetValues(map);

            context.MapProjects.Add(mp);
            await context.SaveChangesAsync();
            

            return map.Id != 0;
        }

        public async Task<MapProject> GetMapProject(int Id)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var response = await context.MapProjects.FirstOrDefaultAsync(x => x.Id == Id);

            return response ?? new MapProject();
        }

        public async Task<List<MapProject>> GetMapProjects()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var response = await context.MapProjects.ToListAsync();

            return response;
        }

        public async Task<bool> UpdateMapProject(MapProject map)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var mapProject = await context.MapProjects.FirstOrDefaultAsync(m => m.Id == map.Id);

            if (mapProject != null) 
            {
                context.Entry<MapProject>(mapProject).CurrentValues.SetValues(map);
            
        
                context.MapProjects.Update(mapProject);

                var result = await context.SaveChangesAsync();

                return result > 0;
            }

           return false;

        }
      
    }
}
