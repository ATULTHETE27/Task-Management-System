using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Context;
using Task_Management_System.Models;
using Task_Management_System.Repository;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Controllers
{
    public class PriorityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PriorityController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;

        }
		public IActionResult AllPriority()
		{
			List<Priority> priorityList = _unitOfWork.Priority.GetAll().ToList();
			return View(priorityList);
		}

		//GET
		public IActionResult Upsert(int? id)
        {
            
            if (id == null || id == 0)
            {
                return View(new Priority());
            }
            else
            {
				Priority prioritysobj = _unitOfWork.Priority.GetFirstOrDefault(u => u.Priority_Id == id);
                return View(prioritysobj);

                //update Tasks
            }


        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Priority obj)
        {

            if (ModelState.IsValid)
            {

                if (obj.Priority_Id == 0)
                {
                    _unitOfWork.Priority.Add(obj);
                }
                else
                {
                    _unitOfWork.Priority.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Task created successfully";
                return RedirectToAction("AllTeams");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Priority.GetFirstOrDefault(u => u.Priority_Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Priority.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Priority> priorityList = _unitOfWork.Priority.GetAll().ToList();
            return Json(new { data = priorityList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete1(int? id)
        {
            var obj = _unitOfWork.Priority.GetFirstOrDefault(u => u.Priority_Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Priority.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }

}
 