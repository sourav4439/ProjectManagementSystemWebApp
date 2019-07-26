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
            return View();
        }

        // GET: ItAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItAdmin/Create
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: ItAdmin/Create
        [HttpPost] 
        public async Task<IActionResult> AddUser(UserInfoViewModel model )
        {
            if (ModelState.IsValid)
            {
              
                var user = new ApplicationUsers
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                   Designation = model.Designation.ToString(),
                   Status = model.Status,
                   PasswordHash = model.Password
                   

                   
                };


                var result = await _usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                 await _role.CreateAsync(new IdentityRole(user.Designation));

                  await _usermanager.AddToRoleAsync(user, user.Designation);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        // GET: ItAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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