using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class SimilarDTO
    {
        public long? nIdSimilar { get; set; }
        public int nIdProducto { get; set; }
        public int nIdComercio { get; set; }
        public string sUrl { get; set; } 
        public string sDescripcion { get; set; }
        public string? sSKU { get; set; }
        public decimal nPrecio { get; set; }
        public bool bElegido { get; set; }
        public bool bManual { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
    }
}
