using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Omar_Ahmed_0523006.Data.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        //
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        [JsonIgnore]
        public List<player>? players { get; set; }
        public List<TeamCompttion>? teamCompttions { get; set; }
    }
}
