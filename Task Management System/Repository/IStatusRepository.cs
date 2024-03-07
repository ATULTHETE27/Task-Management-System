using Task_Management_System.Models;

namespace Task_Management_System.Repository
{
	public interface IStatusRepository : IRepository<Status>
	{
		void Update(Status obj);
	}
}
