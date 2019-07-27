using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.Internal;

namespace ProjectManagementSystem.Models
{
    public class ProjectInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CodeName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Possible Start Date")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "Possible End Date")]
        public string Enddate { get; set; }
        [Required]
        [Display(Name = "Duration (in Days)")]
        public string Duration { get; set; }
       
        public string UploadFilePath { get; set; }
        [Required]
        public string Status { get; set; }

        [NotMapped]
        [Display(Name = "Upload File")]
        [Required]
        public IFormFile Uploadfile { get; set; }

    }
}
