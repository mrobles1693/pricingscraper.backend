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
    public class SimilarRepository : ISimilarRepository
    {
        private readonly IConfiguration _configuration;

        public SimilarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SimilarDTO>> getListSimilarByProducto(int nIdProducto)
        {
            IEnumerable<SimilarDTO> list = new List<SimilarDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_similar]", 1);
                parameters.Add("nIdProducto", nIdProducto);

                list = await connection.QueryAsync<SimilarDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SimilarDTO> getSimilarByID(int nIdSimilar)
        {
            SimilarDTO resp = new SimilarDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_similar]", 2);
                parameters.Add("nIdSimilar", nIdSimilar);

                resp = await connection.QuerySingleAsync<SimilarDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectComercio()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_similar]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsSimilar(SimilarDTO similar)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_similar]", 4);
                parameters.Add("nIdProducto", similar.nIdProducto);
                parameters.Add("nIdComercio", similar.nIdComercio);
                parameters.Add("sUrl", similar.sUrl);
                parameters.Add("sDescripcion", similar.sDescripcion);
                parameters.Add("sSKU", similar.sSKU);
                parameters.Add("nPrecio", similar.nPrecio);
                parameters.Add("bElegido", similar.bElegido);
                parameters.Add("bManual", similar.bManual);
                parameters.Add("nIdUsuario_crea", similar.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdSimilar(SimilarDTO similar)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_similar]", 5);
                parameters.Add("nIdSimilar", similar.nIdSimilar);
                parameters.Add("nIdProducto", similar.nIdProducto);
                parameters.Add("nIdComercio", similar.nIdComercio);
                parameters.Add("sUrl", similar.sUrl);
                parameters.Add("sDescripcion", similar.sDescripcion);
                parameters.Add("sSKU", similar.sSKU);
                parameters.Add("nPrecio", similar.nPrecio);
                parameters.Add("bElegido", similar.bElegido);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
