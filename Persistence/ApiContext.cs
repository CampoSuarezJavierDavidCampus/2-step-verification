using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiContext: DbContext{
    public ApiContext(DbContextOptions<ApiContext> opts): base(opts){}

    public DbSet<User> Users { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
