using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PassManagement.Models
{
    public class PersonDto
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string NumberPhone { get; set; }

        [Required]
        public string DocumentType { get; set; }

        [Required]
        public string NumberDocument { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public string WhoIssuedDocument { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string PhotoPath { get; set; }
    }
}
