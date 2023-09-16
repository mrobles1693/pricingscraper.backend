﻿using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IList<CategoriaDTO>> getListCategoria();
        Task<CategoriaDTO> getCategoriaByID(int nIdCategoria);
        Task<SqlRspDTO> InsCategoria(CategoriaDTO categoria);
        Task<SqlRspDTO> UpdCategoria(CategoriaDTO categoria);
    }
}
