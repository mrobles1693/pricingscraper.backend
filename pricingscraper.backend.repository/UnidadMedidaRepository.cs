using Dapper;
using Microsoft.Extensions.Configuration;
using pricingscraper.backend.domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pricingscraper.backend.repository.Interfaces;

namespace pricingscraper.backend.repository
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly IConfiguration _configuration;

        public UnidadMedidaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<UnidadMedidaDTO>> getListUnidadMedida()
        {
            IEnumerable<UnidadMedidaDTO> list = new List<UnidadMedidaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_unidad_medida]", 1);

                list = await connection.QueryAsync<UnidadMedidaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<UnidadMedidaDTO> getUnidadMedidaByID(int nIdUnidadMedida)
        {
            UnidadMedidaDTO resp = new UnidadMedidaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_unidad_medida]", 2);
                parameters.Add("nIdUnidadMedida", nIdUnidadMedida);

                resp = await connection.QuerySingleAsync<UnidadMedidaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsUnidadMedida(UnidadMedidaDTO unidadMedida)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_unidad_medida]", 3);
                parameters.Add("sUnidadMedida", unidadMedida.sUnidadMedida);
                parameters.Add("sSimbolo", unidadMedida.sSimbolo);
                parameters.Add("sDescripcion", unidadMedida.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdUnidadMedida(UnidadMedidaDTO unidadMedida)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_unidad_medida]", 4);
                parameters.Add("nIdUnidadMedida", unidadMedida.nIdUnidadMedida);
                parameters.Add("sUnidadMedida", unidadMedida.sUnidadMedida);
                parameters.Add("sSimbolo", unidadMedida.sSimbolo);
                parameters.Add("sDescripcion", unidadMedida.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
