using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Context;
using Task_Management_System.Repository;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Controllers
{
    public class TasksController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _hostEnvironment;


        public TasksController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_hostEnvironment = hostEnvironment;

		}
		public IActionResult AllTasks()
        {
            var tasksList = _unitOfWork.Tasks.GetAll(includeProperties: "Status");
            return View(tasksList);
        }
        //GET
        public IActionResult Upsert(int? id)
		{
			TasksVM tasksVM = new()
			{
				Tasks = new(),
				StatusList = _unitOfWork.Status.GetAll().Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				}),

				PriorityList = _unitOfWork.Priority.GetAll().Select(i => new SelectListItem
				{
					Text = i.Priority_Name,
					Value = i.Priority_Id.ToString()
				}),

			};



			if (id == null || id == 0)
			{
				return View(tasksVM);
			}
			else
			{
				tasksVM.Tasks = _unitOfWork.Tasks.GetFirstOrDefault(u => u.Id == id);
				return View(tasksVM);

				//update Tasks
			}


		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(TasksVM obj, IFormFile? file)
		{

			if (ModelState.IsValid)
			{
				string wwwRootPath = _hostEnvironment.WebRootPath;
				
				if (obj.Tasks.Id == 0)
				{
					_unitOfWork.Tasks.Add(obj.Tasks);
				}
				else
				{
					_unitOfWork.Tasks.Update(obj.Tasks);
				}
				_unitOfWork.Save();
				TempData["success"] = "Task created successfully";
				return RedirectToAction("AllTasks");
			}
			return View(obj);
		}

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Tasks.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Tasks.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #region API CALLS
        [HttpGet]
		public IActionResult GetAll()
		{
			var tasksList = _unitOfWork.Tasks.GetAll(includeProperties: "Status");
			return Json(new { data = tasksList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete1(int? id)
		{
			var obj = _unitOfWork.Tasks.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.Tasks.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}

}

