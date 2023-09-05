using Dapper;
using Microsoft.Extensions.Configuration;
using pricingscraper.backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.repository
{
    public class BotRepository : IBotRepository
    {
        private readonly IConfiguration _configuration;

        public BotRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlRspDTO> getIdBotExecution()
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_rs]", 1);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SimilarDTO>> getListSimilar()
        {
            IEnumerable<SimilarDTO> list = new List<SimilarDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_rs]", 2);

                list = await connection.QueryAsync<SimilarDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> insRegistroPrecio(RegistroPrecioDTO registroPrecio)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_rs]", 3);
                parameters.Add("nIdProducto", registroPrecio.nIdProducto);
                parameters.Add("nIdComercio", registroPrecio.nIdComercio);
                parameters.Add("nIdSimilar", registroPrecio.nIdSimilar);
                parameters.Add("nIdBotExecution", registroPrecio.nIdBotExecution);
                parameters.Add("nPrecio", registroPrecio.nPrecio);
                parameters.Add("nPrecioOferta", registroPrecio.nPrecioOferta);
                parameters.Add("nPrecioTarjeta", registroPrecio.nPrecioTarjeta);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> finBotExecution(int nIdBotExecution)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_rs]", 4);
                parameters.Add("nIdBotExecution", nIdBotExecution);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
