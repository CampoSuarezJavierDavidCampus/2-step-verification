using Application.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Persistence;
using VerificationProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>(opts =>{
    string connection = builder.Configuration.GetConnectionString("ConnectionWindows")!;
    opts.UseMySql(connection, ServerVersion.AutoDetect(connection) );
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope()){
    var service = scope.ServiceProvider;
    services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApiAuth,ApiAuth>();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
