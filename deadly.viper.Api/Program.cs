using Microsoft.OpenApi.Models;
using deadly.viper.Domain.Catalog;
using deadly.viper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
	options.UseSqlite("Data Source=../Registrar.Sqlite",
	b => b.MigrationsAssembly("deadly.viper.Api"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "deadly viper API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "deadly viper API V1");
});

app.MapControllers();

app.Run();

string Authority = builder.Configuration["Auth0:Authority"] ??
    throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"] ??
    throw new ArgumentNullException("Auth0:Audience");

string storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ??
    throw new ArgumentNullException("ConnectionString:StoreConnection");

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(storeConnectionString,
    b => b.MigrationsAssembly("Deadly.Viper.Api"))
);