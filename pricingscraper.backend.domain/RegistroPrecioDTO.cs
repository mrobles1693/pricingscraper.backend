using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class RegistroPrecioDTO
    {
        public long? nIdRegistroPrecio { get; set; }
        public int nIdProducto { get; set; }
        public int nIdComercio { get; set; }
        public int nIdSimilar { get; set; }
        public decimal nPrecio { get; set; }
        public decimal? nPrecioOferta { get; set; }
        public decimal? nPrecioTarjeta { get; set; }
        public DateTime dFecha { get; set; }

    }
}
