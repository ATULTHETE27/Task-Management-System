namespace Task_Management_System.ViewModels
{
	public class UserModel
	{
		public string Employee_Id { set; get; }
		public string Employee_Name { set; get; }
		public List<string>? Employee_Role { set; get; }
		public string? Role { set; get; }
	}
}
