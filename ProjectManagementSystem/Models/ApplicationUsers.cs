using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagementSystem.Models
{
    public class ApplicationUsers:IdentityUser
    {
        public ApplicationUsers() : base() { }
       

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Designation { get; set; }

       
    }
}
