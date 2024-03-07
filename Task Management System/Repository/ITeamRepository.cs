using System.Collections;
using Task_Management_System.Models;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Repository
{
    public interface ITeamRepository : IRepository<Teams>
    {
        //void Add(TeamVM team);
        //void Delete(int id);
        //Task<IEnumerable<string>> GetAllTeams();
        //Task<Teams> GetTeams(int team_Id);
        void Update(Teams teams);
    }
}
