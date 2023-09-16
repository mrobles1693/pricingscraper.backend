using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IList<MarcaDTO>> getListMarca();
        Task<MarcaDTO> getMarcaByID(int nIdMarca);
        Task<SqlRspDTO> InsMarca(MarcaDTO marca);
        Task<SqlRspDTO> UpdMarca(MarcaDTO marca);
    }
}
