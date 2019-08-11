using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;


namespace ProjectManagementSystem.Data.Repository
{
    public class TaskRepo:Repository<Task>,ITaskRepo
    {
        public TaskRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
