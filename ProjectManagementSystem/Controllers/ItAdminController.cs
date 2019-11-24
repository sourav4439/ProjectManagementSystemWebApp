using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "ItAdmin")]
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

      

        // GET: ItAdmin/Create
        public ActionResult AddUser()
        {
            ViewBag.designation = _role.Roles.Select(r => new SelectListItem { Value = r.Id, Text = r.Name }).ToList();
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

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
          var user= await _usermanager.FindByIdAsync(id);
          if (user.Designation=="ItAdmin")
          {
              return ViewBag.massage = "You can not Able to Update Or Delete This User "+user.Name;
          }
          else
          {
              ViewBag.designation = _role.Roles.Select(r => new SelectListItem { Value = r.Id, Text = r.Name }).ToList();
              var role = _role.Roles.SingleOrDefault(r => r.Name == user.Designation);


              UserInfoViewModel userInfo = new UserInfoViewModel
              {
                  Id = user.Id,
                  Name = user.Name,
                  Status = user.Status,
                  Email = user.Email,
                  Password = user.PasswordHash,
                  RoleId = role.Id



              };
              return View(userInfo);
            }
         
          
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UserInfoViewModel model)
        {
            var role = await _role.FindByIdAsync(model.RoleId);

            if (ModelState.IsValid)
            {
                var user = await _usermanager.FindByIdAsync(model.Id);

                user.UserName = model.Email;
                user.Email = model.Email;
                user.Name = model.Name;
                user.Designation = role.Name;
                user.Status = model.Status;
                user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user,model.Password);

                var result = await _usermanager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    if (await _usermanager.IsInRoleAsync(user,role.Name))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                      var oldrole= await _usermanager.GetRolesAsync(user);
                      await _usermanager.RemoveFromRolesAsync(user, oldrole);

                        var r= await _usermanager.AddToRoleAsync(user, user.Designation);

                        if (r.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                   
                }
                
            }
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            
                if (user == null)
                {
                    ViewBag.errormassage = "uuser Not Found";
                    return View("NotFound");
                }

                else
                {
                    if (user.Designation == "ItAdmin")
                    {
                        return ViewBag.massage = "You can not Able to Update Or Delete This User " + user.Name;
                    }
                    else
                    {
                    var result = await _usermanager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("Index");
                }
            }
        }





    }

}