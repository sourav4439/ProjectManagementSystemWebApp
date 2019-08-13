using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Models;
using Task = ProjectManagementSystem.Models.Task;

namespace ProjectManagementSystem.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUsers>
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<ProjectInfo> ProjectInfos { get; set; }

        public DbSet<ProjectInfoUsers> ProjectInfoUserses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectInfoUsers>().HasKey(pu => new { pu.ApplicationUserId, pu.ProjectInfoId });

           builder.Entity<ProjectInfoUsers>()
                .HasOne<ApplicationUsers>(a => a.ApplicationUsers)
                .WithMany(s => s.ProjectInfoUserses)
                .HasForeignKey(sc => sc.ApplicationUserId);


            builder.Entity<ProjectInfoUsers>()
                .HasOne<ProjectInfo>(p => p.ProjectInfo)
                .WithMany(p => p.ProjectInfoUserses)
                .HasForeignKey(pc => pc.ProjectInfoId);
        }
    }
}
