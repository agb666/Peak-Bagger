using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Models
{

    public class TrigPointType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}