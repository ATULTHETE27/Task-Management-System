using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
	public class Status
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Status")]
		[Required]
		[MaxLength(50)]
		public string? Name { get; set; }
	}
}