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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<UsuarioDTO>> getListUsuario()
        {
            IEnumerable<UsuarioDTO> list = new List<UsuarioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_usuario]", 1);

                list = await connection.QueryAsync<UsuarioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<UsuarioDTO> getUsuarioByID(int nIdUsuario)
        {
            UsuarioDTO resp = new UsuarioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_usuario]", 2);
                parameters.Add("nIdUsuario", nIdUsuario);

                resp = await connection.QuerySingleAsync<UsuarioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_usuario]", 3);
                parameters.Add("sUsuario", usuario.sUsuario);
                parameters.Add("sPassword", usuario.sPassword);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_usuario]", 4);
                parameters.Add("nIdUsuario", usuario.nIdUsuario);
                parameters.Add("sUsuario", usuario.sUsuario);
                parameters.Add("sPassword", usuario.sPassword);
                parameters.Add("bActivo", usuario.bActivo);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
