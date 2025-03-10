using PersonalGoalsAPI.Models;

namespace PersonalGoalsAPI.Services
{
    public class MandrilDataStore
    {
        public List<Mandril> Mandriles { get; set; }
        public static MandrilDataStore Current { get; } = new MandrilDataStore();
        public MandrilDataStore()
        {
            Mandriles = new List<Mandril>()
            {
                new Mandril()
                {
                    Id = 1,
                    Name = "Javier",
                    LastName = "Niño",
                    Skills = new List<Skills>()
                    {
                        new Skills()
                        {
                            Id = 1,
                            Name = "Jump",
                            Power = Skills.PowerE.Extreme
                        }
                    }
                }
            };

        }
    }
}
