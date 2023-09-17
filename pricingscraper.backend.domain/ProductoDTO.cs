using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class ProductoDTO
    {
        public int? nIdProducto { get; set; }
        public string sSKU { get; set; }
        public string sDescripcion { get; set; }
        public int nIdPresentacion { get; set; }
        public string? sPresentacion { get; set; }
        public int nIdMarca { get; set; }
        public string? sMarca { get; set; }
        public int nIdUnidadMedida { get; set; }
        public string? sUnidadMedida { get; set; }
        public string? sSimbolo { get; set; }
        public decimal nUnidades { get; set; }
    }
}
