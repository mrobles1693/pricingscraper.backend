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
    public class PresentacionRepository : IPresentacionRepository
    {
        private readonly IConfiguration _configuration;

        public PresentacionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PresentacionDTO>> getListPresentacion()
        {
            IEnumerable<PresentacionDTO> list = new List<PresentacionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_presentacion]", 1);

                list = await connection.QueryAsync<PresentacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<PresentacionDTO> getPresentacionByID(int nIdPresentacion)
        {
            PresentacionDTO resp = new PresentacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_presentacion]", 2);
                parameters.Add("nIdPresentacion", nIdPresentacion);

                resp = await connection.QuerySingleAsync<PresentacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsPresentacion(PresentacionDTO presentacion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_presentacion]", 3);
                parameters.Add("sPresentacion", presentacion.sPresentacion);
                parameters.Add("sDescripcion", presentacion.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdPresentacion(PresentacionDTO presentacion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_presentacion]", 4);
                parameters.Add("nIdPresentacion", presentacion.nIdPresentacion);
                parameters.Add("sPresentacion", presentacion.sPresentacion);
                parameters.Add("sDescripcion", presentacion.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
