using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.Entities
{
    public class HistoricalChanges
    {
        public int Id { get; set; }

        public string? Name { get; set; }  

        public int EntityId { get; set; }

        public string? ModificationSource { get; set; }

        public string? ModificationType { get; set; }

        public string? ModificationJsonData { get; set; }

        public DateTime CreateDateUtc { get; set; }


    }
}
