using Task_Management_System.Models;

namespace Task_Management_System.Repository
{
    public interface IPriorityRepository : IRepository<Priority>
    {
        void Update(Priority obj);
    }
}
