using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class ComercioDTO
    {
        public int? nIdComercio { get; set; }
        public string sComercio { get; set; }
        public string? sDescripcion { get; set; }
        public string sUrl { get; set; }      
    }
}
