using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable{
    private readonly DbContext _Context;
    private IUserRepository? _User;
    public UnitOfWork(DbContext ctx) => _Context = ctx;

    public IUserRepository Users => _User ??= new UserRepository(_Context);

    public void Dispose(){ 
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveChanges()=> await _Context.SaveChangesAsync();
}
