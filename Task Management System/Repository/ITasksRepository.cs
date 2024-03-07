using Task_Management_System.Models;

namespace Task_Management_System.Repository
{
    public interface ITasksRepository : IRepository<Tasks>
    {
        void Update(Tasks obj);
    }
}
