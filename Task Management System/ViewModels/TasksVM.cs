using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModels
{
	public class TasksVM
	{
		public Tasks Tasks { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> AssignByList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> AssignToList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> StatusList { get; set; }
		[ValidateNever] 
		public IEnumerable<SelectListItem> PriorityList { get; set; }
	}
}
