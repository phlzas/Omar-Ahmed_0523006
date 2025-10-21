using Microsoft.AspNetCore.Mvc;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.RepostryPattern.CoachesRepos;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;
using Omar_Ahmed_0523006.RepostryPattern.TeamRepos;

namespace Omar_Ahmed_0523006.Controllers
{
    public class CoahesController : ControllerBase
    {
        private readonly ICoachRepos _coachRepos;
        private readonly IGenricRepo<Coach> _genricRepo;
        private readonly ITeamRepos _teamRepos;
        public CoahesController(ICoachRepos coach, IGenricRepo<Coach> genricRepo, ITeamRepos teamRepos)
        {
            _genricRepo = genricRepo;
            _coachRepos = coach;
            _teamRepos = teamRepos;
        }
        [HttpGet("GetAllCoaches")]
        public async Task<IActionResult> GetAllCoaches()
        {
            var d = _coachRepos.GetAll();
            var s = d.Result
                .Select(
                o => new
                {
                    o.Id,
                    o.Name,
                    TeamName = o.Team.Name
                    ,
                    o.Speclatation,
                    o.Team.City
                }
                ).GroupBy(o => o.Speclatation);
            if (s == null)
            {
                return NotFound("Found");

            }
            return Ok(s);
        }

        [HttpGet("GetCoache{id}")]
        public async Task<IActionResult> GetCoaches(int id)
        {
            
            var d = _teamRepos.GetAllWithSpicfecCoach(id);
            if (d.Result.Select(o => o.Coach) == null)
            {
                return NotFound("Coach Does not Exsite");
            }
            var s2 = d.Result.Select(o => new
            {
               Team_id =  o.Id,
               Team_Name =  o.Name,
                Coach_id =  o.CoachId,
               Coach_Name =  o.Coach.Name,
               TotalNumberOfplayers = o.players.Count()
            });
            return Ok(s2); 

        }
    }
}
