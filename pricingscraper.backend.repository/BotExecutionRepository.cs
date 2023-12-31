﻿using Dapper;
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
    public class BotExecutionRepository : IBotExecutionRepository
    {
        private readonly IConfiguration _configuration;

        public BotExecutionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<BotExecutionDTO>> getListBotExecution()
        {
            IEnumerable<BotExecutionDTO> list = new List<BotExecutionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_execution]", 1);

                list = await connection.QueryAsync<BotExecutionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<BotExecutionDTO> getBotExecution(int nIdBotExecution)
        {
            BotExecutionDTO resp = new BotExecutionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_execution]", 2);
                parameters.Add("nIdBotExecution", nIdBotExecution);

                resp = await connection.QuerySingleOrDefaultAsync<BotExecutionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<BotExecutionReportDTO>> getBotExecutionRepo(int nIdBotExecution)
        {
            IEnumerable<BotExecutionReportDTO> list = new List<BotExecutionReportDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPricingScraper")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[pa_bot_execution]", 3);
                parameters.Add("nIdBotExecution", nIdBotExecution);

                list = await connection.QueryAsync<BotExecutionReportDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
