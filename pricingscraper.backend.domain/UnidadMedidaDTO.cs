using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class UnidadMedidaDTO
    {
        public int nIdUnidadMedida { get; set; }
        public string sUnidadMedida { get; set; }
        public string sSimbolo { get; set; }
        public string? sDescripcion { get; set; }    
    }
}
