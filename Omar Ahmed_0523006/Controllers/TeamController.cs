using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Omar_Ahmed_0523006.Data.Models;
using Omar_Ahmed_0523006.Dtos.TeamDtosss;
using Omar_Ahmed_0523006.RepostryPattern.CoachesRepos;
using Omar_Ahmed_0523006.RepostryPattern.GenericRepos;
using Omar_Ahmed_0523006.RepostryPattern.TeamRepos;

namespace Omar_Ahmed_0523006.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly ICoachRepos _coachRepos;
        private readonly IGenricRepo<Team> _genricRepo;
        private readonly ITeamRepos _teamRepos;
        public TeamController(ICoachRepos coach, IGenricRepo<Team> genricRepo, ITeamRepos teamRepos)
        {
            _genricRepo = genricRepo;
            _coachRepos = coach;
            _teamRepos = teamRepos;
        }

        [HttpPost("CreateTeamWihtCoach")]
        public async Task<IActionResult> CreateTeamWihtCoach([FromBody] TeamDto teamDto)
        {
            var A = _coachRepos.GetById(teamDto.CoachId);
            if (A == null) { return NotFound("Coach deos not Exsite"); }
            var ss  = _teamRepos.GetAllWithSpicfecCoach(teamDto.CoachId);
            if (ss != null)
            {
                return BadRequest("Coach is already added to anathor team");
            }
            var s = new Team
            {
                City = teamDto.City,
                CoachId = teamDto.CoachId,
                Name = teamDto.Name,
                players = new List<player>(),
                Coach  = A.Result,

            };

            _genricRepo.Add(s);
            _genricRepo.savechanges();
            return Created();
        }
        [HttpGet ("GetAllWihtNoComptions")]
        public async Task<IActionResult> GetAllWihtNoComptions()
        {
            var s = _teamRepos.GetAllWithNoComption();
            var d = s.Result.Select(s => new
            {
                s.Id,
                s.Name,

                Player_Count = s.players.Count() == null ? 0 : s.players.Count(),

            }).OrderByDescending(o => o.Player_Count);

            return  Ok(d);
        }


     }
}
