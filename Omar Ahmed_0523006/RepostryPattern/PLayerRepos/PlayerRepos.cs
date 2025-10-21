using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;

namespace Omar_Ahmed_0523006.RepostryPattern.PLayerRepos
{
    public class PlayerRepos : GenericRepo<player>,IPlayerRepos
    {
        private readonly AppDbContext _DbContext;
        public PlayerRepos(AppDbContext appDb) : base(appDb)
        {
            _DbContext = appDb;
        }

        public async Task<List<player>> GetAll()
        {
            return await _DbContext.player.Include(o => o.team).ToListAsync();
        }

        public async Task<bool> UpdateSeplaization(int id, string Postion)
        {
            var s = await _DbContext.player.FindAsync(id);
            if (s == null)
            {
                return false;
            }
            s.Postion = Postion;
            Update(s);
            return true;

        }
    }
}
