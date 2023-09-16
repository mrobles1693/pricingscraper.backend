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
    public class PresentacionBL : IPresentacionBL
    {
        IPresentacionRepository repository;

        public PresentacionBL(IPresentacionRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<PresentacionDTO>> getListPresentacion() => await repository.getListPresentacion();
        public async Task<PresentacionDTO> getPresentacionByID(int nIdPresentacion) => await repository.getPresentacionByID(nIdPresentacion);
        public async Task<SqlRspDTO> InsPresentacion(PresentacionDTO presentacion) => await repository.InsPresentacion(presentacion);
        public async Task<SqlRspDTO> UpdPresentacion(PresentacionDTO presentacion) => await repository.UpdPresentacion(presentacion);
    }
}
