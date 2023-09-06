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
    public class AuthBL : IAuthBL
    {
        IAuthRepository repository;

        public AuthBL(IAuthRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<SqlRspDTO> AuthUser(UsuarioDTO usuario) => await repository.AuthUser(usuario);
    }
}
