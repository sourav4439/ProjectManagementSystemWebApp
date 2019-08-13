using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;


namespace ProjectManagementSystem.Data.Repository
{
    public class TaskRepo:Repository<Task>,ITaskRepo
    {
        public TaskRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async System.Threading.Tasks.Task<ICollection<Task>> GetAllTaskByProjectId(int id)
        {
           return await db.Tasks.Where(p=>p.ProjectinfoId==id).Include(u=>u.ApplicationUsers).ToListAsync();

        }
        public  ICollection<Task> GetTaskByProjectId(int id)
        {
            return  db.Tasks.Where(p => p.ProjectinfoId == id).ToList();

        }
    }
}
