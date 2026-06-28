using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoWrapper;
using Microsoft.EntityFrameworkCore;
using University.Core.Modules;
using University.Data.Context;
using University.Data.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{


    container.RegisterModule<RepositoryModule>();
    container.RegisterModule<ServiceModule>();
    container.RegisterModule(new DataModule(builder.Configuration));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiResponseAndExceptionWrapper();

app.MapControllers();

app.Run();
