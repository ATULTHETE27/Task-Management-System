using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModels
{
	public class TeamAssign
	{
		public Guid Team_Id { get; set; }


		public List<UserModel> Assign_User { get; set; }

	}
}
