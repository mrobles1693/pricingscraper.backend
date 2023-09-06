using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.businesslogic.Interfaces
{
    public interface IProductoBL
    {
        Task<IList<ProductoDTO>> getListProducto();
        Task<ProductoDTO> getProductoByID(int nIdProducto);
        Task<IList<SelectDTO>> getSelectPresentacion();
        Task<IList<SelectDTO>> getSelectMarca();
        Task<IList<SelectDTO>> getSelectUnidadMedida();
        Task<SqlRspDTO> InsProducto(ProductoDTO producto);
        Task<SqlRspDTO> UpdProducto(ProductoDTO producto);
    }
}
