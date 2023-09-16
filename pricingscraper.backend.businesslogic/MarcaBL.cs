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
    public class MarcaBL : IMarcaBL
    {
        IMarcaRepository repository;

        public MarcaBL(IMarcaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<MarcaDTO>> getListMarca() => await repository.getListMarca();  
        public async Task<MarcaDTO> getMarcaByID(int nIdMarca) => await repository.getMarcaByID(nIdMarca);
        public async Task<SqlRspDTO> InsMarca(MarcaDTO marca) => await repository.InsMarca(marca);
        public async Task<SqlRspDTO> UpdMarca(MarcaDTO marca) => await repository.UpdMarca(marca);
    }
}
