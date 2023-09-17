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
    public class ComercioRepository : IComercioRepository
    {
        private readonly IConfiguration _configuration;

        public ComercioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ComercioDTO>> getListComercio()
        {
            IEnumerable<ComercioDTO> list = new List<ComercioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_comercio]", 1);

                list = await connection.QueryAsync<ComercioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ComercioDTO> getComercioByID(int nIdComercio)
        {
            ComercioDTO resp = new ComercioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_comercio]", 2);
                parameters.Add("nIdComercio", nIdComercio);

                resp = await connection.QuerySingleAsync<ComercioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsComercio(ComercioDTO comercio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_comercio]", 3);
                parameters.Add("sComercio", comercio.sComercio);
                parameters.Add("sDescripcion", comercio.sDescripcion);
                parameters.Add("sUrl", comercio.sUrl);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdComercio(ComercioDTO comercio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_comercio]", 4);
                parameters.Add("nIdComercio", comercio.nIdComercio);
                parameters.Add("sComercio", comercio.sComercio);
                parameters.Add("sDescripcion", comercio.sDescripcion);
                parameters.Add("sUrl", comercio.sUrl);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
