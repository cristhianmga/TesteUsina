using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using TesteUsina.Configuration;
using TesteUsinaNegocio.DTO;
using TesteUsinaNegocio.Interface;
using TesteUsinaNegocio.Services;
using TesteUsinaNegocio.Validation;
using TesteUsinaPersistencia.Interface;
using TesteUsinaPersistencia.Padrao;
using TesteUsinaPersistencia.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BANCO DE DADOS
string mySqlConnection = builder.Configuration.GetConnectionString("DEV");
builder.Services.AddDbContext<TesteDbContext>(options => options.UseSqlServer(mySqlConnection));

//mapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//INJEÇÂO DE DEPENDENCIA
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPadraoDB, PadraoDB>();
builder.Services.AddValidatorsFromAssemblyContaining<ClienteValidation>();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsapp");
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
