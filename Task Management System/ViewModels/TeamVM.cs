namespace Task_Management_System.ViewModels
{
	public class TeamVM
	{
		public Guid Team_Id { get; set; }
		public string Team_Name { get; set; }
	}
}


//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.ComponentModel.DataAnnotations;
//using System.Xml.Linq;
//using Task_Management_System.Models;

//namespace Task_Management_System.ViewModels
//{
//    public class TeamVM
//    {
//        public Teams Teams { get; set; }
//        public int Team_Id { get; set; }


//        [RegularExpression(@"^[A-Za-z][A-Za-z0-9@#%.&\*]*$", ErrorMessage = "Enter the name of Team")]
//        [Required]
//        [Display(Name = "Team")]
//        public string? Team_Name { get; set; }
//        [ValidateNever]
//        public IEnumerable<SelectListItem>? TeamsList { get; set; }

//    }
//}
