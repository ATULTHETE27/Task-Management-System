using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Repository
{
    public class TeamRepository : Repository<Teams>, ITeamRepository
    {
        private ApplicationDbContext _db;

        public TeamRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(Teams teams)
        {
            _db.Teams.Update(teams);
        }


    }
}