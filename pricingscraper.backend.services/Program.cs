using pricingscraper.backend.services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Agregar acceso de FrontEnd
var CorsConfiguration = "corspolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: CorsConfiguration,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "http://localhost:4201")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Asignacion de Interfaces/Entidades y BD Conexion
builder.Services.ConfigureRepositoryManager(builder.Configuration["ConnectionStrings:cnPricingScraper"]);
builder.Services.ConfigureServicesManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsConfiguration);

app.UseAuthorization();

app.MapControllers();

app.Run();
