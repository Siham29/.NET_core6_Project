using Microsoft.EntityFrameworkCore;
using UserApi;
using UserApi.Models;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ActionFilter>(_ => new ActionFilter("Admin"));
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InitServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseExceptionHandlerMiddleware();

if (app.Environment.IsDevelopment())
{
    //app.UseWelcomePage();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 

app.Run();
