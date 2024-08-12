using PassManagement.Data;
using PassManagement.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PassManagement.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPersonAsync(PersonDto personDto)
        {
            var person = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Patronymic = personDto.Patronymic,
                Birthdate = personDto.Birthdate,
                NumberPhone = personDto.NumberPhone,
                DocumentType = personDto.DocumentType,
                NumberDocument = personDto.NumberDocument,
                DateOfIssue = personDto.DateOfIssue,
                WhoIssuedDocument = personDto.WhoIssuedDocument,
                Address = personDto.Address,
                Product = personDto.Product,
                PhotoPath = personDto.PhotoPath
            };

            _context.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonDto> GetPersonDtoByIdAsync(int id)
        {
            return await _context.Persons
                .Where(p => p.Id == id)
                .Select(p => new PersonDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Patronymic = p.Patronymic,
                    Birthdate = p.Birthdate,
                    NumberPhone = p.NumberPhone,
                    DocumentType = p.DocumentType,
                    NumberDocument = p.NumberDocument,
                    DateOfIssue = p.DateOfIssue,
                    WhoIssuedDocument = p.WhoIssuedDocument,
                    Address = p.Address,
                    Product = p.Product,
                    PhotoPath = p.PhotoPath
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            return await _context.Persons
                .Select(p => new PersonDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Patronymic = p.Patronymic,
                    Birthdate = p.Birthdate,
                    NumberPhone = p.NumberPhone,
                    DocumentType = p.DocumentType,
                    NumberDocument = p.NumberDocument,
                    DateOfIssue = p.DateOfIssue,
                    WhoIssuedDocument = p.WhoIssuedDocument,
                    Address = p.Address,
                    Product = p.Product,
                    PhotoPath = p.PhotoPath
                })
                .ToListAsync();
        }
    }
}
