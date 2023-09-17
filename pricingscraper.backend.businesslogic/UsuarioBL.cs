using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;
using pricingscraper.backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic
{
    public class UsuarioBL : IUsuarioBL
    {
        IUsuarioRepository repository;

        public UsuarioBL(IUsuarioRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<UsuarioDTO>> getListUsuario() => await repository.getListUsuario();
        public async Task<UsuarioDTO> getUsuarioByID(int nIdUsuario) => await repository.getUsuarioByID(nIdUsuario);
        public async Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario) => await repository.InsUsuario(usuario);
        public async Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario) => await repository.UpdUsuario(usuario);
    }
}
