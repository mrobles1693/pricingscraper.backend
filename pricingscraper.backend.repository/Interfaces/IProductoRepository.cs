using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IList<ProductoDTO>> getListProducto();
        Task<ProductoDTO> getProductoByID(int nIdProducto);
        Task<IList<SelectDTO>> getSelectPresentacion();
        Task<IList<SelectDTO>> getSelectMarca();
        Task<IList<SelectDTO>> getSelectUnidadMedida();
        Task<SqlRspDTO> InsProducto(ProductoDTO producto);
        Task<SqlRspDTO> UpdProducto(ProductoDTO producto);
        Task<IList<CategoriaDTO>> getListCategoriasByProducto(int nIdProducto);
        Task<IList<CategoriaDTO>> getListCategoriasDispByProducto(int nIdProducto);
        Task<SqlRspDTO> InsCategoriaProducto(ProductoCategoriaDTO productoCategoria);
        Task<SqlRspDTO> DelCategoriaProducto(ProductoCategoriaDTO productoCategoria);
    }
}
