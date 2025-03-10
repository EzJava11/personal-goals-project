using System.ComponentModel.DataAnnotations;

namespace PersonalGoalsAPI.Models
{
    public class MandrilInsert
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
    }
}
