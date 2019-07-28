using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectManagerController : Controller
    {
        private readonly IProjectmanagerRepo _projectmanagerRepo;
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly IProjectUsersRepo _projectUsersRepo;
        private readonly UserManager<ApplicationUsers> _userManager;

        public ProjectManagerController(IProjectmanagerRepo projectmanagerRepo,
            IHostingEnvironment iHostingEnvironment,
            IProjectUsersRepo projectUsersRepo,UserManager<ApplicationUsers> userManager)
        {
            _projectmanagerRepo = projectmanagerRepo;
            _iHostingEnvironment = iHostingEnvironment;
            _projectUsersRepo = projectUsersRepo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var project = _projectmanagerRepo.GetAll();
            return View(project);
        }


        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProject(ProjectInfo projectInfo)
        {
            string uploadfilename = null;
            if (projectInfo.Uploadfile != null)
            {
                string userphotofolder = Path.Combine(_iHostingEnvironment.WebRootPath,"ProjectFile");
                uploadfilename = Guid.NewGuid().ToString() + "_" + projectInfo.Name+"_" + projectInfo.Uploadfile.FileName;
                string filepath = Path.Combine(userphotofolder, uploadfilename);
                projectInfo.Uploadfile.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            projectInfo.UploadFilePath = uploadfilename;
            if (ModelState.IsValid)
            {
                _projectmanagerRepo.Create(projectInfo);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditProject(int id)
        {
          var project=  _projectmanagerRepo.GetById(id);
            return View(project);
        }
        [HttpPost]
        public IActionResult EditProject(ProjectInfo projectInfo)
        {
            string uploadfilename = null;
            if (projectInfo.Uploadfile != null)
            {
                string userphotofolder = Path.Combine(_iHostingEnvironment.WebRootPath, "ProjectFile");
                uploadfilename = Guid.NewGuid().ToString() + "_"+projectInfo.Name+"_" + projectInfo.Uploadfile.FileName;
                string filepath = Path.Combine(userphotofolder, uploadfilename);
                projectInfo.Uploadfile.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            projectInfo.UploadFilePath = uploadfilename;
            if (ModelState.IsValid)
            {
                _projectmanagerRepo.Update(projectInfo);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult AssignResourcePerson()
        {
            ViewBag.ApplicationUserId=_userManager.Users.Select(u=>new SelectListItem{Value = u.Id,Text = u.Name}).ToList();
            ViewBag.ProjectInfoId = _projectmanagerRepo.GetAll().Select(p=>new SelectListItem{Value = p.Id.ToString(),Text = p.Name}).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AssignResourcePerson([Bind("ApplicationUserId,ProjectInfoId")] ProjectInfoUsers pusers)
        {
           
            if (ModelState.IsValid)
            {
              _projectUsersRepo.Create(pusers);
              return RedirectToAction("AssignResourcePersonList");
            }
            ViewBag.ApplicationUserId = _userManager.Users.Select(u => new SelectListItem { Value = u.Id, Text = u.Name }).ToList();
            ViewBag.ProjectInfoId = _projectmanagerRepo.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();

            return View(pusers);
        }
        [HttpGet]
        public IActionResult AssignResourcePersonList()
        {
            var allassifnproject = _projectUsersRepo.GetALlIncludeProjectAndResourseperson();
            return View(allassifnproject);
        }




    }
}