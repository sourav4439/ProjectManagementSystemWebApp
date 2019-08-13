using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManagementSystem.Models.Task;

namespace ProjectManagementSystem.Data.Interfaces
{
   public interface ITaskRepo:IRepository<Task>
   {

       System.Threading.Tasks.Task<ICollection<Task>> GetAllTaskByProjectId(int id);
   }
}
