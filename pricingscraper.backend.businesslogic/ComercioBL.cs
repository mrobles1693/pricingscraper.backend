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
    public class ComercioBL : IComercioBL
    {
        IComercioRepository repository;

        public ComercioBL(IComercioRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ComercioDTO>> getListComercio() => await repository.getListComercio();
        public async Task<ComercioDTO> getComercioByID(int nIdComercio) => await repository.getComercioByID(nIdComercio);
        public async Task<SqlRspDTO> InsComercio(ComercioDTO comercio) => await repository.InsComercio(comercio);
        public async Task<SqlRspDTO> UpdComercio(ComercioDTO comercio) => await repository.UpdComercio(comercio);
    }
}
