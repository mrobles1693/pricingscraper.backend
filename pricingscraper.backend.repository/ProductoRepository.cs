using Dapper;
using Microsoft.Extensions.Configuration;
using pricingscraper.backend.domain;
using pricingscraper.backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pricingscraper.backend.repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IConfiguration _configuration;

        public ProductoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProductoDTO>> getListProducto()
        {
            IEnumerable<ProductoDTO> list = new List<ProductoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 1);

                list = await connection.QueryAsync<ProductoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ProductoDTO> getProductoByID(int nIdProducto)
        {
            ProductoDTO resp = new ProductoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 2);
                parameters.Add("nIdProducto", nIdProducto);

                resp = await connection.QuerySingleAsync<ProductoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectPresentacion()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMarca()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectUnidadMedida()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsProducto(ProductoDTO producto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 6);
                parameters.Add("sSKU", producto.sSKU);
                parameters.Add("sDescripcion", producto.sDescripcion);
                parameters.Add("nIdPresentacion", producto.nIdPresentacion);
                parameters.Add("nIdMarca", producto.nIdMarca);
                parameters.Add("nIdUnidadMedida", producto.nIdUnidadMedida);
                parameters.Add("nUnidades", producto.nUnidades);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdProducto(ProductoDTO producto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_producto]", 7);
                parameters.Add("nIdProducto", producto.nIdProducto);
                parameters.Add("sSKU", producto.sSKU);
                parameters.Add("sDescripcion", producto.sDescripcion);
                parameters.Add("nIdPresentacion", producto.nIdPresentacion);
                parameters.Add("nIdMarca", producto.nIdMarca);
                parameters.Add("nIdUnidadMedida", producto.nIdUnidadMedida);
                parameters.Add("nUnidades", producto.nUnidades);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
