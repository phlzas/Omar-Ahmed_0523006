
using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;

namespace Omar_Ahmed_0523006.RepostryPattern.GenericRepos
{
    public class GenericRepo<T> : IGenricRepo<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void  Add(T item)
        {
          
            _dbContext.Set<T>().Add(item);   
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public Task<List<T>> GetAll()
        {
             return  _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
           return await _dbContext.Set<T>().FindAsync(id);
        }

        public void savechanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
