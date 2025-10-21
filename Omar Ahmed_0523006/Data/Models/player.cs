using System.ComponentModel.DataAnnotations;

namespace Omar_Ahmed_0523006.Data.Models
{
    public class player
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        public string Postion { get; set; }
        [MinLength(18)]
        public int Age { get; set; }
          //  

        public int TeamId { get; set; } 

        public Team team { get; set; }

    }
}
