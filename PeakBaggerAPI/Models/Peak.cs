using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeakBaggerAPI.Models
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Height { get; set; }
        [Required]
        public string? LoactionRefernce { get; set; }
        public string? Description { get; set; }
        public Area? Area { get; set; }
        public int AreaId  { get; set; }
        public int TagId { get; set; }
        public ICollection<Bagged>? Bagged { get; set; }
    }
}