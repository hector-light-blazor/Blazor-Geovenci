using Geovenci.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO = Geovenci.Models.DTOs;
using Entity = Geovenci.Data.Entities;

namespace Geovenci.Models.Extensions
{
    public static class MapProjectExtension
    {
        public static Entity.MapProject ToEntity(this DTO.MapProject project) 
        {
            var now = DateTime.UtcNow;
            return new Entity.MapProject()
            {
                Extent = project.Extent,
                Name = project.Name,
                ProjectStartDateUtc = now,
                ProjectDueDateUtc = now
            };
        }
    }
}
