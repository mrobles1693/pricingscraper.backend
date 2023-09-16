using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.domain
{
    public class UsuarioDTO
    {
        public int? nIdUsuario { get; set; }
        public string sUsuario { get; set; }
        public string? sPassword { get; set; }
        public bool bActivo { get; set; }
    }
}
