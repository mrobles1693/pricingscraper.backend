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
    public class CategoriaBL : ICategoriaBL
    {
        ICategoriaRepository repository;

        public CategoriaBL(ICategoriaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<CategoriaDTO>> getListCategoria() => await repository.getListCategoria();
        public async Task<CategoriaDTO> getCategoriaByID(int nIdCategoria) => await repository.getCategoriaByID(nIdCategoria);
        public async Task<SqlRspDTO> InsCategoria(CategoriaDTO categoria) => await repository.InsCategoria(categoria);
        public async Task<SqlRspDTO> UpdCategoria(CategoriaDTO categoria) => await repository.UpdCategoria(categoria);
    }
}
