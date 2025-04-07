using Microsoft.EntityFrameworkCore;
using UniSocial.Infrastructure.Context;
using UniSocial.Application.Interfaces;
using UniSocial.Application.Services;
using UniSocial.Infrastructure.Repositories;
using UniSocial.Domain.Interfaces;
using UniSocial.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o EF + MySQL
builder.Services.AddDbContext<UniSocialContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecao de dependência
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IPostagemService, PostagemService>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();

builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();

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
