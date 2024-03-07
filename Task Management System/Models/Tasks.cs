using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
	public class Tasks
	{
		public int Id { get; set; }
		[Required]
		public string TaskTitle { get; set; }
		[Required]
		public string Description { get; set; }
		//[Required]
		//[Range(1, 1000)]
		//public double Priority { get; set; }
		[Required]
		public DateTime AssignDate { get; set; } = DateTime.Now;
		[Required]
		public DateTime DueDate { get; set; }


		[Required]
		public int StatusId { get; set; }
		[ForeignKey("StatusId")]
		[ValidateNever]
		public Status Status { get; set; }


		[Required]
		public int Priority_Id { get; set; }
		[ForeignKey("Priority_Id")]
		[ValidateNever]
		public Priority Priority { get; set; }
	}
}
