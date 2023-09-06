using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IAuthBL
    {
        Task<SqlRspDTO> AuthUser(UsuarioDTO usuario);
    }
}
