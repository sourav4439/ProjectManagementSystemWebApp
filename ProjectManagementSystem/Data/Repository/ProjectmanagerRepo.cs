using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Repository
{
    public class ProjectmanagerRepo:Repository<ProjectInfo>,IProjectmanagerRepo
    {
        public ProjectmanagerRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
