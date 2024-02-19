using Application.Applications;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.IServices;
using Domain.Servicos;
using Infrastructure.Configs;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>();

#region  Interfaces e Classes

//Repository
builder.Services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGeneric<>));
builder.Services.AddSingleton<IPet, RepositoryPet>();
builder.Services.AddSingleton<IUser, RepositoryUser>();

//Service Domain
builder.Services.AddSingleton<IServicePet, ServicePet>();

//Application
builder.Services.AddSingleton<IApplicationPet, ApplicationPet>();
builder.Services.AddSingleton<IApplicationUser, ApplicationUser>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
