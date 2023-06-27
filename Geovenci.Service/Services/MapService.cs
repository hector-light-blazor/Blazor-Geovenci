using Geovenci.Data.Repositories.Interfaces;
using Geovenci.Models.DTOs;
using Geovenci.Models.Extensions;
using Geovenci.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Service.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepo _mapRepo;

        public MapService(IMapRepo mapRepo)
        {
            _mapRepo = mapRepo;
        }

        public Task<bool> CreateMapProject(MapProject mapProject)
        {
            var entity = mapProject.ToEntity();

            var result = _mapRepo.CreateMapProject(entity);

            return result;
        }

        public Task<MapProject> GetMapProject()
        {
            throw new NotImplementedException();
        }

        public Task<List<MapProject>> GetMapProjects()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMapProject()
        {
            throw new NotImplementedException();
        }
    }
}
