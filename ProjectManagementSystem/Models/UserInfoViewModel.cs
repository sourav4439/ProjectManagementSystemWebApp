using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Models
{
    public class UserInfoViewModel
    {
        [Required]
        [StringLength(15)]

        public string Name { get; set; }
        [Required]

        public bool Status { get; set; }
        [Required]

        public Designation Designation { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Default password")]
        public string Password { get; set; }

    }

    public enum Designation
    {
        ItAdmin,
        Projectmanager,
        TeamLead,
        QaEngineer,
        UxEngineer,
        Developer,
        

    }
}
