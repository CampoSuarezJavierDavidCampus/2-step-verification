using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using VerificationProject.Services;

namespace VerificationProject.Extensions;
public static class ApplicationExtensions{
    public static void AddAplicacionServices(this IServiceCollection services){
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthService,AuthService>();
    }
}
