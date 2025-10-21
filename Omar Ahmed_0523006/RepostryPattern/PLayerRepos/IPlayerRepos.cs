using Omar_Ahmed_0523006.Data.Models;

namespace Omar_Ahmed_0523006.RepostryPattern.PLayerRepos
{
    public interface IPlayerRepos
    {
        Task<bool> UpdateSeplaization(int id, string Spelaization);
        Task<List<player>> GetAll();
                
    }
}
