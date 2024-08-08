using System;
using System.ComponentModel.DataAnnotations;

namespace PassManagement.Models
{
    public class Pass
    {
        public int Id { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}