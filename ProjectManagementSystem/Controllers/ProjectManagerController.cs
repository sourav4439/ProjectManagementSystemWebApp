﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}