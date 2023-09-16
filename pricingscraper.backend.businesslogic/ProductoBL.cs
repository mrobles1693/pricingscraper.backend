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
    public class ProductoBL : IProductoBL
    {
        IProductoRepository repository;

        public ProductoBL(IProductoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ProductoDTO>> getListProducto() => await repository.getListProducto();
        public async Task<ProductoDTO> getProductoByID(int nIdProducto) => await repository.getProductoByID(nIdProducto); 
        public async Task<IList<SelectDTO>> getSelectPresentacion() => await repository.getSelectPresentacion();
        public async Task<IList<SelectDTO>> getSelectMarca() => await repository.getSelectMarca();  
        public async Task<IList<SelectDTO>> getSelectUnidadMedida() => await repository.getSelectUnidadMedida();    
        public async Task<SqlRspDTO> InsProducto(ProductoDTO producto) => await repository.InsProducto(producto);
        public async Task<SqlRspDTO> UpdProducto(ProductoDTO producto) => await repository.UpdProducto (producto);
        public async Task<IList<CategoriaDTO>> getListCategoriasByProducto(int nIdProducto) => await repository.getListCategoriasByProducto(nIdProducto);
        public async Task<IList<CategoriaDTO>> getListCategoriasDispByProducto(int nIdProducto) => await repository.getListCategoriasDispByProducto(nIdProducto);
        public async Task<SqlRspDTO> InsCategoriaProducto(ProductoCategoriaDTO productoCategoria) => await repository.InsCategoriaProducto(productoCategoria);
        public async Task<SqlRspDTO> DelCategoriaProducto(ProductoCategoriaDTO productoCategoria) => await repository.DelCategoriaProducto(productoCategoria);
    }
}
