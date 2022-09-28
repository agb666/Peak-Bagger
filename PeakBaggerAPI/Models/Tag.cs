using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Models
{
public class Tag
{
	[Key]
	[Required]
	public int Id {get; set;}
	[Required]
	public string? Name {get; set;}  //Trail 100 etc

}
}