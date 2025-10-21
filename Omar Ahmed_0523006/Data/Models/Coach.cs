using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Omar_Ahmed_0523006.Data.Models
{
    public class Coach
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Speclatation { get; set; }
        [Required]
        public int ExpYears { get; set; }
        //

        [JsonIgnore]
        public Team Team { get; set; }
    }
}
