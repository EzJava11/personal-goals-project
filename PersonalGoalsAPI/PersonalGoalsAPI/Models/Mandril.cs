namespace PersonalGoalsAPI.Models
{
    public class Mandril
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public List <Skills>? Skills { get; set; }
    }
}
