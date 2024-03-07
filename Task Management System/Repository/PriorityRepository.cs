using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;

namespace Task_Management_System.Repository
{
    public class PriorityRepository : Repository<Priority>, IPriorityRepository
    {
        private ApplicationDbContext _db;

        public PriorityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Priority obj)
        {
            _db.Priority.Update(obj);
        }
    }
}
