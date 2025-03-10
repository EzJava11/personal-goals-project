namespace PersonalGoalsAPI.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PowerE Power { get; set; }
        public enum PowerE
        {
            Soft,
            Moderate,
            Intense,
            Powerful,
            Extreme
        }
    }
}
