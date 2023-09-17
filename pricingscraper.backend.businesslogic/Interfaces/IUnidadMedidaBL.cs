﻿using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IUnidadMedidaBL
    {
        Task<IList<UnidadMedidaDTO>> getListUnidadMedida();
        Task<UnidadMedidaDTO> getUnidadMedidaByID(int nIdUnidadMedida);
        Task<SqlRspDTO> InsUnidadMedida(UnidadMedidaDTO unidadMedida);
        Task<SqlRspDTO> UpdUnidadMedida(UnidadMedidaDTO unidadMedida);
    }
}
