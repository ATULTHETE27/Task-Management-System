using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Management_System.Areas.Identity.Data;

namespace Task_Management_System.Models
{
	public class UserTeams
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[ForeignKey("Task_Management_SystemUser")]
		public string User_Id { get; set; }
		[Required]
		[ForeignKey("Teams")]
		public Guid Team_Id { get; set; }
	}
}
