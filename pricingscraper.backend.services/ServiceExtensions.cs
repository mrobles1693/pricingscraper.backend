﻿using pricingscraper.backend.businesslogic;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.repository;
using pricingscraper.backend.repository.Interfaces;

namespace pricingscraper.backend.services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBotRepository, BotRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IBotBL, BotBL>();
        }
    }
}