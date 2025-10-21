using Omar_Ahmed_0523006.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Omar_Ahmed_0523006.Dtos.TeamDtosss
{
    public class TeamDto
    {
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        //
        [Required]
        public int CoachId { get; set; }
        //public Coach Coach { get; set; }
    }
}
