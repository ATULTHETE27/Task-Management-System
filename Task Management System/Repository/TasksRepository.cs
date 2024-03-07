using System.ComponentModel.DataAnnotations;
using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;


namespace Task_Management_System.Repository
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository

    {
        private ApplicationDbContext _db;

        public TasksRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Tasks obj)
        {
            var objFromDb = _db.Tasks.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.TaskTitle = obj.TaskTitle;
                objFromDb.Description = obj.Description;
                objFromDb.Priority_Id = obj.Priority_Id;
                objFromDb.AssignDate = obj.AssignDate;
                objFromDb.DueDate = obj.DueDate;
                objFromDb.StatusId = obj.StatusId;
            }
        }
    }
}
