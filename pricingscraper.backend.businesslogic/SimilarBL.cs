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
    public class SimilarBL : ISimilarBL
    {
        ISimilarRepository repository;

        public SimilarBL(ISimilarRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SimilarDTO>> getListSimilarByProducto(int nIdProducto) => await repository.getListSimilarByProducto(nIdProducto);
        public async Task<SimilarDTO> getSimilarByID(int nIdSimilar) => await repository.getSimilarByID(nIdSimilar);
        public async Task<IList<SelectDTO>> getSelectComercio() => await repository.getSelectComercio();
        public async Task<SqlRspDTO> InsSimilar(SimilarDTO similar) => await repository.InsSimilar(similar);
        public async Task<SqlRspDTO> UpdSimilar(SimilarDTO similar) => await repository.UpdSimilar(similar);
    }
}
