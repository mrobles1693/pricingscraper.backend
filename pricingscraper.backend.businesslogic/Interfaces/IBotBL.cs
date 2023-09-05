using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IBotBL
    {
        Task<SqlRspDTO> getIdBotExecution();
        Task<IList<SimilarDTO>> getListSimilar();
        Task<SqlRspDTO> insRegistroPrecio(RegistroPrecioDTO registroPrecio);
        Task<SqlRspDTO> finBotExecution(int nIdBotExecution);
    }
}
