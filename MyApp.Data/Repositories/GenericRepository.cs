using System.Linq;
using System.Linq.Expressions;
using MyApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MyAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get All
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get by Id
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        

        // Add New Entity
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update Entity
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete by Entity Id
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
    /*
    private readonly MyAppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(MyAppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity); */



