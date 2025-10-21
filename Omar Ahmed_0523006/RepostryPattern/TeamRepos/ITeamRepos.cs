using Omar_Ahmed_0523006.Data.Models;

namespace Omar_Ahmed_0523006.RepostryPattern.TeamRepos
{
    public interface ITeamRepos
    {
         Task<Team> add(Team team, int CoachID);
        Task<List<Team>> GetAllWithNoComption();
        Task<List<Team>> GetAllWithSpicfecCoach(int id);
        Task<Team> GetAllWithSpicfcComption ( int id);
    }
}
