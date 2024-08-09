global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.EntityFrameworkCore;
global using AutoMapper;
global using dotnet.Data;
global using dotnet.Model;
global using dotnet.Base;
global using dotnet.Enums;
global using dotnet.DTOs;
global using dotnet.Interface;
global using dotnet.DTOs.Clothes;
global using dotnet.DTOs.AppUser;
global using dotnet.Repository;
global using dotnet.DTOs.Files;


using dotnet.Extensions;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSecurityExtension(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();