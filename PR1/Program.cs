using Microsoft.EntityFrameworkCore;
using PR1.ActionClass;
using PR1.Interface;
using PR1.Models;

var builder = WebApplication.CreateBuilder(args);

var connectingString = builder.Configuration.GetConnectionString("ConnectDb");
builder.Services.AddDbContext<InformationTechnologyCircleContext>(options => options.UseSqlServer(connectingString));

builder.Services.AddTransient<IUser, UserClass>();


builder.Services.AddControllers();
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

