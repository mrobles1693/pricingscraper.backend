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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly IConfiguration _configuration;

        public MarcaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<MarcaDTO>> getListMarca()
        {
            IEnumerable<MarcaDTO> list = new List<MarcaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_marca]", 1);

                list = await connection.QueryAsync<MarcaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<MarcaDTO> getMarcaByID(int nIdMarca)
        {
            MarcaDTO resp = new MarcaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_marca]", 2);
                parameters.Add("nIdMarca", nIdMarca);

                resp = await connection.QuerySingleAsync<MarcaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsMarca(MarcaDTO marca)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_marca]", 3);
                parameters.Add("sMarca", marca.sMarca);
                parameters.Add("sDescripcion", marca.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdMarca(MarcaDTO marca)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_marca]", 4);
                parameters.Add("nIdMarca", marca.nIdMarca);
                parameters.Add("sMarca", marca.sMarca);
                parameters.Add("sDescripcion", marca.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
