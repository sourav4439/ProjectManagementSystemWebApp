using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Repository
{
    public class CommentRepo:Repository<Comment>,ICommentRepo
    {
        public CommentRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Comment> GetCommentsByTaskId(int id)
        {
           return db.Comments.Where(t => t.TaskId == id)
               .Include(p=>p.ProjectInfo)
               .Include(t=>t.Task)
               .Include(u=>u.ApplicationUsers)
               .ToList();
        }
    }
}
