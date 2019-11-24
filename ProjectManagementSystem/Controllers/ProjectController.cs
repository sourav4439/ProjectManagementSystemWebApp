using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;
using Task = ProjectManagementSystem.Models.Task;

namespace ProjectManagementSystem.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IProjectUsersRepo _projectUsersRepo;
        private readonly IProjectmanagerRepo _projectmanagerRepo;
        private readonly ITaskRepo _taskRepo;
        private readonly ICommentRepo _commentRepo;

        public ProjectController(UserManager<ApplicationUsers> userManager,
            IProjectUsersRepo projectUsersRepo,
            IProjectmanagerRepo projectmanagerRepo,ITaskRepo taskRepo,ICommentRepo commentRepo)
        {
            _userManager = userManager;
            _projectUsersRepo = projectUsersRepo;
            _projectmanagerRepo = projectmanagerRepo;
            _taskRepo = taskRepo;
            _commentRepo = commentRepo;
        }
        public IActionResult ViewProjects()
        {
           var userId= _userManager.GetUserId(User);

           var projectview = _projectUsersRepo.GetprojectByUserId(userId);
           
            return View(projectview);
        }
        [HttpGet]
        public IActionResult ProjectDetails(int id)
        {
            var project = _projectmanagerRepo.GetById(id);
            return View(project);
        }
        [HttpGet]
        public IActionResult CreateTask(int projectid)
        {
           var userId= _userManager.GetUserId(User);
            ViewBag.GetUserId=userId;
            ViewBag.Projectid=projectid;

            ViewBag.ApplicationUserId = _projectUsersRepo.GetuserbyprojectId(projectid)
                   .Select(u => new SelectListItem { Value = u.ApplicationUsersId, Text = u.ApplicationUsers.Name })
                   .ToList();
            ViewBag.ProjectInfoId = _projectUsersRepo.GetprojectByUserId(userId).Select(p => new SelectListItem { Value = p.ProjectInfoId.ToString(), Text = p.ProjectInfo.Name }).ToList();
               return View();
          
            
        }
        [HttpPost]
        public IActionResult CreateTask([Bind("ApplicationUsersId,ProjectinfoId","Description"," DueDate", "Priority")] Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.Create(task);
                return RedirectToAction("ProjectDetails","Project",new {id= task.ProjectinfoId});
            }

            return RedirectToAction("CreateTask", new {projectid = task.ProjectinfoId});
        }
        [HttpGet]
        public IActionResult AddComment()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.ProjectInfoId = _projectUsersRepo.GetprojectByUserId(userId).Select(p => new SelectListItem { Value = p.ProjectInfoId.ToString(), Text = p.ProjectInfo.Name }).ToList();
            
            return View();
           
        }
        [HttpPost]
        public IActionResult AddComment([Bind("ProjectInfoId", "TaskId", "Commentdetails","DateTime", "ApplicationUsersId")]Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepo.Create(comment);
                return RedirectToAction("ViewAllCommentByTaskId",new{id=comment.TaskId});
            }
            return View(comment);
        }
        [HttpGet]
        public IActionResult ViewAllCommentByTaskId(int id)
        {
            var comments = _commentRepo.GetCommentsByTaskId(id);
            return View(comments);

        }

        public JsonResult GetTaskByProjectId(int id)
        {
            var subtag = _taskRepo.GetTaskByProjectId(id);
            return Json(subtag);
        }

    }
}