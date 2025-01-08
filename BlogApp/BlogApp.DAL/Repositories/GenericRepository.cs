using BlogApp.Core.Entities.Common;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DAL.Repositories;

public class GenericRepository<T>(BlogDbContext _context) :IGenericRepository<T> where T: BaseEntity,new()
{
    protected DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
        => Table.AsQueryable();  
  
    public async Task<T?> GetByIdAsync(int id)
       => await Table.FindAsync(id);

    public IQueryable<T> GetWhere(Func<T, bool> expression)
       => Table.Where(expression).AsQueryable();

    public Task<bool> IsExistAsync(int id)
        => Table.AnyAsync(t => t.Id == id);

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
        
        // T? entity = await GetByIdAsync(id);
        // Delete(entity!);
    }

    public async Task<int> SaveAsync()
       => await _context.SaveChangesAsync();
}