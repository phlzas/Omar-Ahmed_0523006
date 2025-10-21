using Omar_Ahmed_0523006.Data.Models;

namespace Omar_Ahmed_0523006.RepostryPattern.CoachesRepos
{
    public interface ICoachRepos
    {
        Task<ICollection<Coach>> GetAll(); 
        Task<Coach> GetById(int id);
        Task<Coach> GetByTeam( Coach coach );
    }
}
