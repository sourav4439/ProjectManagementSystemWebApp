using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int ProjectInfoId { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        [Required]
        public int TaskId { get; set; }
        public Task Task { get; set; }
        [Required]
        public string Commentdetails { get; set; }

    }
}
