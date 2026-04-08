using CrudCafeteria.Data;
using CrudCafeteria.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 DbContext (banco em memória)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SolicitacoesDb"));

builder.Services.AddScoped<ISolicitacaoService, SolicitacaoService>();

// 🔹 Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Retorna "Aberta" em vez de 0
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter()
        );
    });

// 🔹 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();