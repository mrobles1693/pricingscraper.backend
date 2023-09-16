using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IPresentacionBL
    {
        Task<IList<PresentacionDTO>> getListPresentacion();
        Task<PresentacionDTO> getPresentacionByID(int nIdPresentacion);
        Task<SqlRspDTO> InsPresentacion(PresentacionDTO presentacion);
        Task<SqlRspDTO> UpdPresentacion(PresentacionDTO presentacion);
    }
}
