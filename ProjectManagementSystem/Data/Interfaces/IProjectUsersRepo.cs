using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Interfaces
{
   public interface IProjectUsersRepo:IRepository<ProjectInfoUsers>
   {
       ICollection<ProjectInfoUsers> GetALlIncludeProjectAndResourseperson();
       ICollection<ProjectInfoUsers> GetprojectByUserId(string userId);
       ICollection<ProjectInfoUsers> GetuserbyprojectId(int projectId);
       bool IsAssigned(string userid, int projectid);
   }
}
