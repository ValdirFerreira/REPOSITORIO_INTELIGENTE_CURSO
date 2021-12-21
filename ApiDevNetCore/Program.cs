using Dominio.InserfaceServico;
using Dominio.Interfaces;
using Dominio.Servicos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Configuracoes;
using Repositorio.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=192.168.0.101,1433;Initial Catalog=REPOSITORIO_INTELIGENTE_TESTE;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

builder.Services.AddSingleton(typeof(IGenerica<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<IProduto, RepositorioProduto>();

builder.Services.AddSingleton<IProdutoServico, ProdutoServico>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
