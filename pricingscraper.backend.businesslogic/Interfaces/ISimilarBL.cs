using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface ISimilarBL
    {
        Task<IList<SimilarDTO>> getListSimilarByProducto(int nIdProducto);
        Task<SimilarDTO> getSimilarByID(int nIdSimilar);
        Task<IList<SelectDTO>> getSelectComercio();
        Task<SqlRspDTO> InsSimilar(SimilarDTO similar);
        Task<SqlRspDTO> UpdSimilar(SimilarDTO similar);
    }
}
