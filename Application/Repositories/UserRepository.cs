using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository{
    public UserRepository(DbContext context) : base(context){}

    public async Task<User?> GetByIdAsync(long id) => await _Entity.FindAsync(id);
}
