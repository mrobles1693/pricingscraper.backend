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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConfiguration _configuration;

        public CategoriaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CategoriaDTO>> getListCategoria()
        {
            IEnumerable<CategoriaDTO> list = new List<CategoriaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_categoria]", 1);

                list = await connection.QueryAsync<CategoriaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<CategoriaDTO> getCategoriaByID(int nIdCategoria)
        {
            CategoriaDTO resp = new CategoriaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_categoria]", 2);
                parameters.Add("nIdCategoria", nIdCategoria);

                resp = await connection.QuerySingleAsync<CategoriaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsCategoria(CategoriaDTO categoria)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_categoria]", 3);
                parameters.Add("sCategoria", categoria.sCategoria);
                parameters.Add("sDescripcion", categoria.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCategoria(CategoriaDTO categoria)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_categoria]", 4);
                parameters.Add("nIdCategoria", categoria.nIdCategoria);
                parameters.Add("sCategoria", categoria.sCategoria);
                parameters.Add("sDescripcion", categoria.sDescripcion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
