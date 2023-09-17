using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IList<UsuarioDTO>> getListUsuario();
        Task<UsuarioDTO> getUsuarioByID(int nIdUsuario);
        Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario);
    }
}
