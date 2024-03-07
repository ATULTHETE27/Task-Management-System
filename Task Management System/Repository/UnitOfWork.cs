using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Context;
using Task_Management_System.Models;

namespace Task_Management_System.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Tasks = new TasksRepository(_db);
            Status = new StatusRepository(_db);
			Priority = new PriorityRepository(_db);
			Teams = new TeamRepository(_db);
        }
        public ITasksRepository Tasks { get; private set; }

		public IStatusRepository Status { get; private set; }

        public ITeamRepository Teams { get; private set; }

        public IPriorityRepository Priority { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
