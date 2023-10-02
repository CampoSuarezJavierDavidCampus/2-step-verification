using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories.Generics;
public abstract class GenericRepository<T> where T : class{    
    protected readonly DbSet<T> _Entity;
    public GenericRepository(DbContext context)=>_Entity = context.Set<T>();

    #region CRUD
        protected virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? expression = null){
            if (expression is not null){
                return await _Entity.Where(expression).ToListAsync();
            }
            return await _Entity.ToListAsync();
        } 
        public async virtual Task<T> FindFirst(Expression<Func<T, bool>> expression){
            if (expression != null){
                var res = await _Entity.Where(expression).ToListAsync();
                return res.First();
            }
            return await _Entity.FirstAsync();
        }
        public async virtual void Add(T entity) => await _Entity.AddAsync(entity);
        public async virtual void AddRange(IEnumerable<T> entities) => await _Entity.AddRangeAsync(entities);
        public virtual void Remove(T entity) => _Entity.Remove(entity);
        public virtual void RemoveRange(IEnumerable<T> entities) => _Entity.RemoveRange(entities);
        public virtual void Update(T entity) => _Entity.Update(entity);
    #endregion

    #region GetAllAsync
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await GetAll();
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression) => await GetAll(expression);
        public virtual async Task<IEnumerable<T>> GetAllAsync(IParam param) => await GetAllPaginated(param);
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, IParam param) => await GetAllPaginated(param, expression);
    #endregion

    #region pagination
        protected virtual bool PaginateExpression(T entity, string Search)=> true;
        private async Task<IEnumerable<T>> GetAllPaginated(IParam param, Expression<Func<T, bool>>? expression = null){
            return (await GetAll(expression))
                    .Where(x => PaginateExpression(x,param.Search))
                    .Skip((param.PageIndex - 1) * param.PageSize)
                    .Take(param.PageSize)
                    .ToList();
        }
    #endregion
    
}