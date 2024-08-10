using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PassManagement.Models
{
    public class PersonDto
    {
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Номер телефона")]
        public string NumberPhone { get; set; }

        [Display(Name = "Тип документа")]
        public string DocumentType { get; set; }

        [Display(Name = "Номер документа")]
        public string NumberDocument { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime DateOfIssue { get; set; }

        [Display(Name = "Кем выдан документ")]
        public string WhoIssuedDocument { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Товар")]
        public string Product { get; set; }

        [Display(Name = "Фото")]
        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }
    }
}
