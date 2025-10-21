namespace Omar_Ahmed_0523006.Data.Models
{
    public class Compttion
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Locatioon { get; set; }
        public DateTime DateComp{ get; set; }

        public List<TeamCompttion> teamCompttions { get; set; }

    }
}
