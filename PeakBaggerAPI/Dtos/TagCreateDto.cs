using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class TagCreateDto
    {
        [Required]
        public string? Name { get; set; }  //Trail 100 etc
    }
}