using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class ProductoCategoriaDTO
    {
        public int nIdProducto { get; set; }
        public string? sProducto { get; set; }   
        public int nIdCategoria { get; set; }
        public string? sCategoria { get; set; }
    }
}
