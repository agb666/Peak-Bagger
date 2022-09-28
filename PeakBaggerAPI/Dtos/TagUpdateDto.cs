using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class TagUpdateDto
    {
        [Required]
        public string? Name { get; set; }
    }
}