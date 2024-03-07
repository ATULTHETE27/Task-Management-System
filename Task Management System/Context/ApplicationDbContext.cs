using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Task_Management_System.Areas.Identity.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Context
{
    public class ApplicationDbContext : IdentityDbContext<Task_Management_SystemUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
		public DbSet<Status> Status { get; set; }
		public DbSet<Priority> Priority { get; set; }
		public DbSet<Teams> Teams { get; set; }
        public DbSet<UserTeams> UserTeams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tasks>().HasData(
            new Tasks
            {
                Id = 1,
                TaskTitle = "C#",
                Description = "C# language",
                Priority_Id = 1,
                AssignDate = DateTime.Now,
                DueDate = DateTime.Now,

                StatusId = 1
            }
            );

            modelBuilder.Entity<Status>().HasData(
            new Status
            {
                Id = 1,
                Name = "Pending"
            }
            );

            modelBuilder.Entity<Status>().HasData(
            new Status
            {
                Id = 2,
                Name = "In Process"
            }
            );
            modelBuilder.Entity<Status>().HasData(
            new Status
            {
                Id = 3,
                Name = "Completed"
            }
            );

			modelBuilder.Entity<Priority>().HasData(
			new Priority
			{
				Priority_Id = 1,
				Priority_Name = "High"
			}
			);

			modelBuilder.Entity<Priority>().HasData(
			new Priority
			{
				Priority_Id = 2,
				Priority_Name = "Low"
			}
			);
			modelBuilder.Entity<Priority>().HasData(
			new Priority
			{
				Priority_Id = 3,
				Priority_Name = "Medium"
			}
			);
			
            //modelBuilder.Entity<Teams>().HasData(
            //new Teams
            //{
            //    Team_Id = 1,
            //    Team_Name = "Team 1"
            //}
            //);

            //modelBuilder.Entity<Teams>().HasData(
            //new Teams
            //{
            //    Team_Id = 2,
            //    Team_Name = "Team 2"
            //}
            //);

            //modelBuilder.Entity<Teams>().HasData(
            //new Teams
            //{
            //    Team_Id = 3,
            //    Team_Name = "Team 3"
            //}
            //);

        }

    }
}
