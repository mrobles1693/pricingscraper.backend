using pricingscraper.backend.businesslogic;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.repository;
using pricingscraper.backend.repository.Interfaces;

namespace pricingscraper.backend.services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IPresentacionRepository, PresentacionRepository>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
            services.AddScoped<IComercioRepository, ComercioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISimilarRepository, SimilarRepository>();
            services.AddScoped<IBotExecutionRepository, BotExecutionRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IAuthBL, AuthBL>();
            services.AddScoped<IBotBL, BotBL>();
            services.AddScoped<IProductoBL, ProductoBL>();
            services.AddScoped<ICategoriaBL, CategoriaBL>();
            services.AddScoped<IMarcaBL, MarcaBL>();
            services.AddScoped<IPresentacionBL, PresentacionBL>();
            services.AddScoped<IUnidadMedidaBL, UnidadMedidaBL>();
            services.AddScoped<IComercioBL, ComercioBL>();
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<ISimilarBL, SimilarBL>();
            services.AddScoped<IBotExecutionBL, BotExecutionBL>();
        }
    }
}