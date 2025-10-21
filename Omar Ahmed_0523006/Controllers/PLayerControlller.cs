using Microsoft.AspNetCore.Mvc;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.CoachesRepos;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;
using Omar_Ahmed_0523006.RepostryPattern.PLayerRepos;
using Omar_Ahmed_0523006.RepostryPattern.TeamRepos;

namespace Omar_Ahmed_0523006.Controllers
{
    public class PLayerController : ControllerBase
    {
        private readonly ICoachRepos _coachRepos;
        private readonly IGenricRepo<Coach> _genricRepo;
        private readonly ITeamRepos _teamRepos;
        private readonly IPlayerRepos _playerRepos;
        public PLayerController(ICoachRepos coach, IGenricRepo<Coach> genricRepo, ITeamRepos teamRepos, IPlayerRepos playerRepos)
        {
            _genricRepo = genricRepo;
            _coachRepos = coach;
            _teamRepos = teamRepos;
            _playerRepos = playerRepos;
        }
        [HttpPut("UpdateSeplaization")]
        public async Task<IActionResult> UpdateSeplaization(int id, string Postion)
        {
            var s  = _playerRepos.UpdateSeplaization(id, Postion);
            if (s.Result == false) {
                return  BadRequest("player Not Found");
            }
            _genricRepo.savechanges();
            return Ok("Postion Has Been Updateed");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWihInfo()
        {
            var s = _playerRepos.GetAll();
            var d = s.Result.Select(o => new { 
              team_name = o.team.Name,
              yongest = s.Result.OrderBy(o => o.Age).FirstOrDefault().Age,
              Oldest = s.Result.OrderByDescending(o => o.Age).FirstOrDefault().Age,
            }).GroupBy(o => o.team_name);
            return  Ok(d);

        }

    }
}
