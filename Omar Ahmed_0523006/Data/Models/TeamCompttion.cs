namespace Omar_Ahmed_0523006.Data.Models
{
    public class TeamCompttion
    {
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int CompttionId { get; set; }
        public Compttion ?Compttion { get; set; }
    }
}
