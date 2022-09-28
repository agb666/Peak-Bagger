
namespace PeakBaggerAPI.Dtos
{

    public class PeakReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Height { get; set; }
        public string? LoactionRefernce { get; set; }
        public string? Description { get; set; }
        public AreaReadDto? Area { get; set; }
        public int Tag { get; set; }

        //public ICollection<BaggedReadDto>? Bagged { get; set; }

    }
}