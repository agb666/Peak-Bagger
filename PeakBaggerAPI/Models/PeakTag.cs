using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeakBaggerAPI.Models
{

public class PeakTag
{
	[Key]
	[Required]    public int Id {get; set;}   
	public int PeakId {get; set;}
    public int TagId {get; set;}

    public Peak? Peak {get; set;}
    public Tag? Tag {get; set;}
	
}
}