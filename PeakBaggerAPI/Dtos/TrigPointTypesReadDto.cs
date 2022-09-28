using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{

    public class TrigPointTypeReadDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}