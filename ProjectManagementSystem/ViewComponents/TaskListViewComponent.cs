using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data.Interfaces;

namespace ProjectManagementSystem.ViewComponents
{
    public class TaskListViewComponent:ViewComponent
    {
        private readonly ITaskRepo _taskRepo;

        public TaskListViewComponent(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var tasklist =await _taskRepo.GetAllTaskByProjectId(id);
            return View(tasklist);
        }
    }
}
