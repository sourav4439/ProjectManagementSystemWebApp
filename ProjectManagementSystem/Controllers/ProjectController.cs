using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IProjectUsersRepo _projectUsersRepo;

        public ProjectController(UserManager<ApplicationUsers> userManager,IProjectUsersRepo projectUsersRepo)
        {
            _userManager = userManager;
            _projectUsersRepo = projectUsersRepo;
        }
        public IActionResult ViewProjects()
        {
           var userId= _userManager.GetUserId(User);

           var projectview = _projectUsersRepo.GetprojectByUserId(userId);
           
            return View(projectview);
        }
    }
}