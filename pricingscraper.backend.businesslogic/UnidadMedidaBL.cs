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
    public class UnidadMedidaBL : IUnidadMedidaBL
    {
        IUnidadMedidaRepository repository;

        public UnidadMedidaBL(IUnidadMedidaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<UnidadMedidaDTO>> getListUnidadMedida() => await repository.getListUnidadMedida();
        public async Task<UnidadMedidaDTO> getUnidadMedidaByID(int nIdUnidadMedida) => await repository.getUnidadMedidaByID(nIdUnidadMedida);
        public async Task<SqlRspDTO> InsUnidadMedida(UnidadMedidaDTO unidadMedida) => await repository.InsUnidadMedida(unidadMedida);
        public async Task<SqlRspDTO> UpdUnidadMedida(UnidadMedidaDTO unidadMedida) => await repository.UpdUnidadMedida(unidadMedida);
    }
}
