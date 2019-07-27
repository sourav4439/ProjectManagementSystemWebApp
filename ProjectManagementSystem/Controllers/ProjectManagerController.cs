using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectManagerController : Controller
    {
        private readonly IProjectmanagerRepo _projectmanagerRepo;
        private readonly IHostingEnvironment _iHostingEnvironment;

        public ProjectManagerController(IProjectmanagerRepo projectmanagerRepo,IHostingEnvironment iHostingEnvironment)
        {
            _projectmanagerRepo = projectmanagerRepo;
            _iHostingEnvironment = iHostingEnvironment;
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


    }
}