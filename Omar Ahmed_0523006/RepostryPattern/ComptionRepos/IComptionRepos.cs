using Omar_Ahmed_0523006.Data.Models;

namespace Omar_Ahmed_0523006.RepostryPattern.ComptionRepos
{
    public interface IComptionRepos
    {
        Task<bool> DeleteBool(int id);
        Task<List<Compttion>> GetAll();     
    }
}
