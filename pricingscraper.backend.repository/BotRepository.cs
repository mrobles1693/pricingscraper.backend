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

        public async Task<IList<SimilarDTO>> getListSimilar()
        {
            IEnumerable<SimilarDTO> list = new List<SimilarDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_rs]", 1);

                list = await connection.QueryAsync<SimilarDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
