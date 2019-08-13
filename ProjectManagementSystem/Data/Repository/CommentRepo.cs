using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data.Interfaces;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Repository
{
    public class CommentRepo:Repository<Comment>,ICommentRepo
    {
        public CommentRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
