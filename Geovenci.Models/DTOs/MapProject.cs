using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Models.DTOs
{
    public class MapProject
    {

        public int Id { get; set; }

        
        public string Extent { get; set; } = string.Empty;


        public string Name { get; set; } = string.Empty;


    }
}
