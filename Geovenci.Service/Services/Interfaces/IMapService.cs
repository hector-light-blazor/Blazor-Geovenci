using Geovenci.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Service.Services.Interfaces
{
    public interface IMapService
    {
        public Task<bool> CreateMapProject(MapProject mapProject);
        public Task<bool> UpdateMapProject();
        public Task<MapProject> GetMapProject();
        public Task<List<MapProject>> GetMapProjects();
    }
}
