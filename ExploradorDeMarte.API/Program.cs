using ExploradorDeMarte.API.Dominio.Servicos;
using ExploradorDeMarte.API.Dominio.Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
