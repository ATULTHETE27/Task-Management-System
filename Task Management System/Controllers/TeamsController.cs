using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Areas.Identity.Data;
using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Task_Management_SystemUser> _usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TeamsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, ApplicationDbContext context, UserManager<Task_Management_SystemUser> usermanager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _context = context;
            _usermanager = usermanager;
            _roleManager = roleManager;
        }
        //public IActionResult AllTeams()
        //{
        //   List<Teams> teamsList = _unitOfWork.Teams.GetAll().ToList();
        //    return View(teamsList);
        //}
        ////GET
        //public IActionResult Upsert(int? id)
        //{
        //    //TeamVM teamVM = new()
        //    //{
        //    //    Teams = new(),
        //    //    TeamsList = _unitOfWork.Teams.GetAll().Select(i => new SelectListItem
        //    //    {
        //    //        Text = i.Team_Name,
        //    //        Value = i.Team_Id.ToString()
        //    //    }),



        //    //};



        //    if (id == null || id == 0)
        //    {
        //        return View(new Teams());
        //    }
        //    else
        //    {
        //        Teams teamsobj = _unitOfWork.Teams.GetFirstOrDefault(u => u.Team_Id == id);
        //        return View(teamsobj);

        //        //update Tasks
        //    }


        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(Teams obj)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        if (obj.Team_Id == 0)
        //        {
        //            _unitOfWork.Teams.Add(obj);
        //        }
        //        else
        //        {
        //            _unitOfWork.Teams.Update(obj);
        //        }
        //        _unitOfWork.Save();
        //        TempData["success"] = "Team created successfully";
        //        return RedirectToAction("AllTeams");
        //    }
        //    else
        //    {
        //        return View(obj);
        //    }
        //}

        //public IActionResult Delete(int? id)
        //{
        //    var obj = _unitOfWork.Teams.GetFirstOrDefault(u => u.Team_Id == id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    _unitOfWork.Teams.Remove(obj);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });

        //}

        //#region API CALLS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<Teams> teamsList = _unitOfWork.Teams.GetAll().ToList();
        //    return Json(new { data = teamsList });
        //}

        ////POST
        //[HttpDelete]
        //public IActionResult Delete1(int? id)
        //{
        //    var obj = _unitOfWork.Teams.GetFirstOrDefault(u => u.Team_Id == id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    _unitOfWork.Teams.Remove(obj);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });

        //}
        //#endregion

        public IActionResult ManageTeams()
        {
            var teams = _context.Teams.ToList();



            var team = teams.Select(u => new TeamVM { Team_Id = u.Team_Id, Team_Name = u.Team_Name }).ToList();

            return View(team);
        }

        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(TeamVM team)
        {
            Teams teamtoadd = new Teams();
            teamtoadd.Team_Id = team.Team_Id;
            teamtoadd.Team_Name = team.Team_Name;
            _context.Teams.Add(teamtoadd);
            _context.SaveChanges();
            return RedirectToAction("ManageTeams");
        }

        public async Task<IActionResult> ShowTeamDetails(Guid Teamid)
        {
            var tmp = _context.UserTeams.Where(u => u.Team_Id == Teamid).Select(u => u.User_Id).ToList();

            var emp = _usermanager.Users.Where(t => tmp.Contains(t.Id)).ToList();

            //var teamAssign = new TeamAssign { Assignuser = emp.Select(u => new UserModel { EmployeeId = u.Id, EmployeeName = u.Name,EmployeeRole= _usermanager .GetRolesAsync(u)}).ToList(), TeamId = Teamid };

            //return View(teamAssign);

            var usermodel = new List<UserModel>();

            foreach (var user in emp)
            {

                var roles = await _usermanager.GetRolesAsync(user);
                usermodel.Add(new UserModel
                {
                    Employee_Id = user.Id,
                    Employee_Name = user.Name,
                    Employee_Role = (List<string>)roles,


                });
            }
            var teamAssign = new TeamAssign { Assign_User = usermodel, Team_Id = Teamid };


            return View(teamAssign);
        }

        public IActionResult TeamAssign(Guid id)
        {
            //var employees = _usermanager.Users.ToList();

            var tmp = _context.UserTeams.Select(u => u.User_Id).ToList();

            var employees = _usermanager.Users.Where(t => !tmp.Contains(t.Id)).ToList();

            var teamAssign = new TeamAssign { Assign_User = employees.Select(u => new UserModel { Employee_Id = u.Id, Employee_Name = u.Name }).ToList(), Team_Id = id };

            return View(teamAssign);
        }

        [HttpPost]
        public IActionResult TeamAssign(TeamAssign teamasign, List<string> selectedEmployees)
        {

            if (selectedEmployees != null)
            {
                foreach (var employeeId in selectedEmployees)
                {
                    var newrel = new UserTeams
                    {
                        Team_Id = teamasign.Team_Id,
                        User_Id = employeeId
                    };
                    _context.UserTeams.Add(newrel);
                }
                _context.SaveChanges();
            }

            return RedirectToAction("ManageTeams");
        }

        [HttpPost]
        public IActionResult RemoveEmp(Guid TeamId, string EmployeeId)
        {
            var memberToRemove = _context.UserTeams.FirstOrDefault(m => m.User_Id == EmployeeId);
            if (memberToRemove != null)
            {
                _context.UserTeams.Remove(memberToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("ShowTeamDetails", new { Teamid = TeamId });
        }

        //public IActionResult EditRole(UserModel empId)
        //{
        //	var rolelist=_roleManager.Roles.Select(x => x.Name).ToList();

        //	empId.EmployeeRole = rolelist;
        //	return View(empId);
        //}

        public async Task<IActionResult> EditRole(string empId)
        {
            var user = await _usermanager.FindByIdAsync(empId);
            var rolelist = _roleManager.Roles.Select(x => x.Name).ToList();
            UserModel userModel = new UserModel { Employee_Id = user.Id, Employee_Name = user.Name, Employee_Role = rolelist };

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(string EmployeeId, string Role)
        {
            var user = await _usermanager.FindByIdAsync(EmployeeId);
            if (user == null)
            {
                // Handle user not found error
                return NotFound();
            }

            var currentRoles = await _usermanager.GetRolesAsync(user);
            var result = await _usermanager.RemoveFromRolesAsync(user, currentRoles);

            if (!result.Succeeded)
            {
                // Handle error
                return BadRequest(result.Errors);
            }

            // Add the new role
            result = await _usermanager.AddToRoleAsync(user, Role);

            if (!result.Succeeded)
            {
                // Handle error
                return BadRequest(result.Errors);
            }
            _context.SaveChanges();

            return RedirectToAction("ManageTeams"); // Redirect to wherever you want
        }
    }

}
 