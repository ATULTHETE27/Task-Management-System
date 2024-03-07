using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System.Repository
{
    public interface IUnitOfWork
    {
        ITasksRepository Tasks { get; }
		IPriorityRepository Priority { get; }
		IStatusRepository Status { get; }
        ITeamRepository Teams { get; }
        void Save();
    }
}
