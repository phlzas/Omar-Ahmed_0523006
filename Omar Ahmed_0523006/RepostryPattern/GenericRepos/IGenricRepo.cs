namespace Omar_Ahmed_0523006.RepostryPattern.GenericRepos
{
    public interface IGenricRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        void Add(T item);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetByIDAsync(int id);
        void savechanges();
    }
}
