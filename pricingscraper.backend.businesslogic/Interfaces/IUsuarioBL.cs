using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IUsuarioBL
    {
        Task<IList<UsuarioDTO>> getListUsuario();
        Task<UsuarioDTO> getUsuarioByID(int nIdUsuario);
        Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario);
    }
}
