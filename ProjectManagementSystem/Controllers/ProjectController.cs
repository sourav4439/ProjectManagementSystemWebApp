using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProjectController : Controller
    {
        
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IProjectUsersRepo _projectUsersRepo;
        private readonly IProjectmanagerRepo _projectmanagerRepo;
        private readonly ITaskRepo _taskRepo;

        public ProjectController(UserManager<ApplicationUsers> userManager,
            IProjectUsersRepo projectUsersRepo,
            IProjectmanagerRepo projectmanagerRepo,ITaskRepo taskRepo)
        {
            _userManager = userManager;
            _projectUsersRepo = projectUsersRepo;
            _projectmanagerRepo = projectmanagerRepo;
            _taskRepo = taskRepo;
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
                   .Select(u => new SelectListItem { Value = u.ApplicationUserId, Text = u.ApplicationUsers.Name })
                   .ToList();
            ViewBag.ProjectInfoId = _projectUsersRepo.GetprojectByUserId(userId).Select(p => new SelectListItem { Value = p.ProjectInfoId.ToString(), Text = p.ProjectInfo.Name }).ToList();
               return View();
          
            
        }
        [HttpPost]
        public IActionResult CreateTask([Bind("ApplicationUserId,ProjectinfoId","Description"," DueDate", "Priority")] Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.Create(task);
                return RedirectToAction("ProjectDetails","Project",new {id=task.ProjectinfoId});
            }

            return View();
        }
    }
}