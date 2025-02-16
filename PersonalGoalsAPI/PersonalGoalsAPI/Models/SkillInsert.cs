using System.ComponentModel.DataAnnotations;
using static PersonalGoalsAPI.Models.Skills;

namespace PersonalGoalsAPI.Models
{
    public class SkillInsert
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public PowerE Power { get; set; }

    }
}
