using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagementSystem.Models
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(15)]

        public string Name { get; set; }

        [Required]
        public string Status { get; set; }
       
        public IdentityRole Role { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string RoleId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Default password")]
        public string Password { get; set; }

    }

    
}
