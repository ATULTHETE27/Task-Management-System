using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;

namespace Task_Management_System.Repository
{
	public class StatusRepository : Repository<Status>, IStatusRepository
	{
		private ApplicationDbContext _db;

		public StatusRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Status obj)
		{
			_db.Status.Update(obj);
		}
	}
}