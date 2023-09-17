using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IComercioBL
    {
        Task<IList<ComercioDTO>> getListComercio();
        Task<ComercioDTO> getComercioByID(int nIdComercio);
        Task<SqlRspDTO> InsComercio(ComercioDTO comercio);
        Task<SqlRspDTO> UpdComercio(ComercioDTO comercio);
    }
}
