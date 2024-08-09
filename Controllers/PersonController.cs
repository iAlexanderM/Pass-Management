using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassManagement.Data;
using PassManagement.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PassManagement.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ApplicationDbContext context, ILogger<PersonController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] PersonDto personDto)
        {
            if (personDto.Photo == null || personDto.Photo.Length == 0)
            {
                ModelState.AddModelError("PhotoPath", "Фото обязательно");
                return View(personDto);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Сохранение фото
                    var photoPath = Path.Combine("wwwroot/images", Guid.NewGuid().ToString() + Path.GetExtension(personDto.Photo.FileName));

                    _logger.LogInformation($"Сохранение файла в {photoPath}");

                    using (var stream = new FileStream(photoPath, FileMode.Create))
                    {
                        await personDto.Photo.CopyToAsync(stream);
                    }

                    personDto.PhotoPath = Path.Combine("/images/", Path.GetFileName(photoPath));

                    // Создание и сохранение объекта Person
                    var person = new Person
                    {
                        LastName = personDto.LastName,
                        FirstName = personDto.FirstName,
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

                    _context.Persons.Add(person);
                    _logger.LogInformation("Анкета добавлена в контекст базы данных");
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Изменения сохранены в базе данных");

                    return RedirectToAction("Index", "Person");
                }
                catch (Exception ex)
                {
                    // Логирование ошибок
                    _logger.LogError(ex, "Ошибка при сохранении анкеты.");
                    ModelState.AddModelError("", "Произошла ошибка при сохранении данных. Попробуйте снова.");
                }
            }

            // Логирование ошибок валидации
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.LogWarning(error.ErrorMessage);
            }

            return View(personDto);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            var personDto = new PersonDto
            {
                LastName = person.LastName,
                FirstName = person.FirstName,
                Patronymic = person.Patronymic,
                Birthdate = person.Birthdate,
                NumberPhone = person.NumberPhone,
                DocumentType = person.DocumentType,
                NumberDocument = person.NumberDocument,
                DateOfIssue = person.DateOfIssue,
                WhoIssuedDocument = person.WhoIssuedDocument,
                Address = person.Address,
                Product = person.Product,
                PhotoPath = person.PhotoPath
            };

            return View(personDto);
        }

        // GET: Person/Index
        public async Task<IActionResult> Index()
        {
            var persons = await _context.Persons.ToListAsync();
            return View(persons);
        }
    }
}

