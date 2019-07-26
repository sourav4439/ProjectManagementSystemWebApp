using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ItAdminController : Controller
    {
        private readonly UserManager<ApplicationUsers> _usermanager;
        private readonly SignInManager<ApplicationUsers> _signinmanager;
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _role;

        public ItAdminController(UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext db)
        {
            _usermanager = userManager;
            _signinmanager = signInManager;
            _db = db;
            _role = roleManager;
        }
      
        // GET: ItAdmin
        public ActionResult Index()
        {
            var alluser = _usermanager.Users.ToList();
            return View(alluser);
        }

        // GET: ItAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItAdmin/Create
        public ActionResult AddUser()
        {
            ViewBag.designation=_role.Roles.Select(r=> new SelectListItem{Value = r.Id,Text = r.Name}).ToList();
            return View();
        }

     
        [HttpPost] 
        public async Task<IActionResult> AddUser(UserInfoViewModel model )
        {
          var role= await _role.FindByIdAsync(model.RoleId);

            if (ModelState.IsValid)
            {
              
                var user = new ApplicationUsers
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Designation = role.Name,
                   Status = model.Status,
                   PasswordHash = model.Password
                   

                   
                };


                var result = await _usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                  await _usermanager.AddToRoleAsync(user,role.Name);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        
        public ActionResult UpdateUser(int id)
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItAdmin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}