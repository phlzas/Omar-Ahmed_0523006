using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;

namespace Omar_Ahmed_0523006.RepostryPattern.TeamRepos
{
    public class TeamRepos : GenericRepo<Team>, ITeamRepos
    {
        private readonly AppDbContext _dbContext;

        public TeamRepos(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Team> add(Team team, int CoachID)
        {
            team.CoachId = CoachID;
            Add(team);
            return  team;
        }

        public async Task<List<Team>> GetAllWithSpicfecCoach(int id)
        {
            return await _dbContext.team.Include(o => o.Coach).Include(o => o.players).Where(o => o.Coach.Id == id).ToListAsync();
        }

        public async Task<List<Team>> GetAllWithNoComption()
        {
            return await _dbContext.team.Where(o => o.teamCompttions.Any()!).Include(o => o.players).ToListAsync();
        }

        public async Task<Team> GetAllWithSpicfcComption(int id)
        {
            return  _dbContext.team.Include(o => o.players).Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
