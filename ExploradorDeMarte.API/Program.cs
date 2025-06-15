using ExploradorDeMarte.API.Dominio.Servicos;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var result = new
        {
            status = 400,
            title = "Erro de validação",
            detail = "Há erros nos dados enviados. Verifique os campos.",
            errors
        };

        return new BadRequestObjectResult(result);
    };
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IServicoPlanalto, ServicoPlanalto>();
builder.Services.AddSingleton<IServicoSonda, ServicoSonda>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    var requestPath = context.HttpContext.Request.Path;

    if (response.StatusCode == 404 && requestPath != "/")
    {
        response.ContentType = "application/json";

        var result = new
        {
            status = 404,
            title = "Recurso não encontrado",
            detail = "O endpoint requisitado não existe.",
            path = context.HttpContext.Request.Path
        };

        await response.WriteAsJsonAsync(result);
    }
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
