using ApiCatalogo.ApiEndpoints;
using ApiCatalogo.AppServiceExtensions;
using ApiCatalogo.Service;
using ApiCatalogo.Services;


var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITokenService>(new TokenService());

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapAutenticacaoEndpoitns();
app.MapCategoriasEndpotions();
app.MapProdutosEndpoitns();

var environment = app.Environment;

app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();