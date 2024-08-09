using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PassManagement.Models
{
    public class PersonDto
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthdate { get; set; }

        public string NumberPhone { get; set; }

        public string DocumentType { get; set; }

        public string NumberDocument { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string WhoIssuedDocument { get; set; }

        public string Address { get; set; }

        public string Product { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }
    }
}
