using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Repository
{
    public class ProjectUserRepo:Repository<ProjectInfoUsers>,IProjectUsersRepo
    {
        public ProjectUserRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<ProjectInfoUsers> GetALlIncludeProjectAndResourseperson()
        {
            return db.ProjectInfoUserses
                .Include(a => a.ApplicationUsers)
                .Include(p => p.ProjectInfo).ToList();
        }
    }
}
