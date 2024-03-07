using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Utility;

namespace Task_Management_System.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly ApplicationDbContext _db;

        public DbInitializer(

            ApplicationDbContext db)
        {

            _db = db;
        }


        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //create roles if they are not created
           
            return;
        }
    }
}
