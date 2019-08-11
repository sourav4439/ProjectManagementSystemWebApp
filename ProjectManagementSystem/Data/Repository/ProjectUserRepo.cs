using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public ICollection<ProjectInfoUsers> GetprojectByUserId(string userId)
        {
           return db.ProjectInfoUserses.Include(p => p.ProjectInfo)
                .Where(u => u.ApplicationUserId == userId).ToList();
        }

        public ICollection<ProjectInfoUsers> GetuserbyprojectId(int projectId)
        {
            return db.ProjectInfoUserses
                .Include(u=>u.ApplicationUsers)
                .Where(p => p.ProjectInfoId == projectId).ToList();
        }

        public bool IsAssigned(string userid, int projectid)
        {
            return db.ProjectInfoUserses.Any(p => p.ApplicationUserId == userid && p.ProjectInfoId == projectid);
        }
    }
}
