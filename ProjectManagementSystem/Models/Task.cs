using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public int ProjectinfoId { get; set; }
        public ProjectInfo ProjectInfo { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string ApplicationUsersId { get; set; }

        public ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]
        public string Priority { get; set; }

    }
}
