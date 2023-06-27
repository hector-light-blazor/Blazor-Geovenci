using Geovenci.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.Repositories.Interfaces
{
    public interface IMapRepo
    {
        public Task<bool> CreateMapProject(MapProject map);
        public Task<bool> UpdateMapProject(MapProject map);
        public Task<MapProject> GetMapProject(int Id);
        public Task<List<MapProject>> GetMapProjects();
    }
}
