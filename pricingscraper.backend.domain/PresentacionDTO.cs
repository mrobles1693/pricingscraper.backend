using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class PresentacionDTO
    {
        public int? nIdPresentacion { get; set; }
        public string sPresentacion { get; set; }
        public string? sDescripcion { get; set; }
    }
}
