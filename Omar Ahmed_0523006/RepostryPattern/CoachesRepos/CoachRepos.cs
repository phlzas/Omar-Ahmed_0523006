using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;

namespace Omar_Ahmed_0523006.RepostryPattern.CoachesRepos
{
    public class CoachRepos : GenericRepo<Coach>, ICoachRepos
    {
        private readonly AppDbContext _DbContext;
        public CoachRepos (AppDbContext appDb) : base (appDb)
        {
            _DbContext = appDb;
        }
        public async Task<ICollection<Coach>> GetAll()
        {
            return await _DbContext.coaches.Include(o => o.Team).ToListAsync();
        }

        public async Task<Coach> GetById(int id)
        {
            return await _DbContext.coaches.FindAsync(id);
        }

        public async Task<Coach> GetByTeam(Coach coach)
        {
            return  _DbContext.coaches.Include(o => o.Team).Where(o => o.Id == coach.Id).FirstOrDefault();
        }
    }
}
