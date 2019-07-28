using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectManagementSystem.Models
{
    public class ProjectInfoUsers
    {

        [Required]
        public string ApplicationUserId { get; set; }
        
        public virtual ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        public int ProjectInfoId { get; set; }
        
        public virtual ProjectInfo ProjectInfo { get; set; }
        
    }
}
