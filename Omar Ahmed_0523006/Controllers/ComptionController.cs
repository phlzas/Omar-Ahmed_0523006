using Microsoft.AspNetCore.Mvc;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.CoachesRepos;
using Omar_Ahmed_0523006.RepostryPattern.ComptionRepos;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;
using Omar_Ahmed_0523006.RepostryPattern.PLayerRepos;
using Omar_Ahmed_0523006.RepostryPattern.TeamRepos;

namespace Omar_Ahmed_0523006.Controllers
{
    public class ComptionController : ControllerBase
    {
        private readonly ICoachRepos _coachRepos;
        private readonly IGenricRepo<Compttion> _genricRepo;
        private readonly IGenricRepo<Team> _genricRepo2;
        private readonly ITeamRepos _teamRepos;
        private readonly IPlayerRepos _playerRepos;
        private readonly IComptionRepos _comptionRepos;
        public ComptionController(IGenricRepo<Team> genricRepo2, IComptionRepos comptionRepos,ICoachRepos coach, IGenricRepo<Compttion> genricRepo, ITeamRepos teamRepos, IPlayerRepos playerRepos)
        {
            _genricRepo = genricRepo;
            _coachRepos = coach;
            _teamRepos = teamRepos;
            _playerRepos = playerRepos;
            _comptionRepos = comptionRepos;
            _genricRepo2 = genricRepo2;
        }

        [HttpDelete("DeleteIfExsite")]
        public async Task<IActionResult> DeleteIfExsite(int id)
        {
            var s  = _comptionRepos.DeleteBool(id);
            if (s.Result == true) {
                _genricRepo.savechanges();
                return  NoContent();
            }
            return NotFound("Comtption is not found");
        }

        [HttpGet("GettWithData")]
        public async Task<IActionResult> GettWithData()
        {
            var s = _comptionRepos.GetAll();
            var p =   s.Result.SelectMany(o => o.teamCompttions).Select(o => o.TeamId).ToList();
            var ss  =  new List<Team>();
            foreach(var team in p) {
                var sa = _teamRepos.GetAllWithSpicfecCoach(team);
                ss.Add(new Team { Id = sa.Id, City = sa.Result. });
            }
            var d = s.Result.Select(o => new
            {
                o.Locatioon,
                TotalNumbarPartecating = o.teamCompttions.Count(),
                TotalNumberOfPlayers = ss.Select(o => o.players.Count()).Sum()

            }).GroupBy(o => o.Locatioon).ToList();
            return  Ok(d);
        }
    }
}
