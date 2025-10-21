using Microsoft.EntityFrameworkCore;
using Omar_Ahmed_0523006.Data;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;

namespace Omar_Ahmed_0523006.RepostryPattern.ComptionRepos
{
    public class ComptionRepos : GenericRepo<Compttion>, IComptionRepos
    {
        private readonly AppDbContext _DbContext;
        public ComptionRepos(AppDbContext appDb) : base(appDb)
        {
            _DbContext = appDb;
        }

        public async Task<bool> DeleteBool(int id)
        {
            var s = await _DbContext.compttion.FindAsync(id);
            if(s == null)
            {
                return false;
            }
            Delete(s);
            return true;

        }

        public async Task<List<Compttion>> GetAll()
        {
            return await _DbContext.compttion.Include(o => o.teamCompttions).ThenInclude(o => o.Team).ToListAsync();
        }
    }
}
