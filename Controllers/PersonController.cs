using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassManagement.Services;
using PassManagement.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PassManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly ILogger<PersonController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PersonController(PersonService personService, ILogger<PersonController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _personService = personService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var personDto = await _personService.GetPersonDtoByIdAsync(id);

            if (personDto == null)
            {
                return NotFound();
            }

            return Ok(personDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PersonDto personDto)
        {
            if (personDto.Photo == null || personDto.Photo.Length == 0)
            {
                return BadRequest("Фото обязательно");
            }

            try
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(personDto.Photo.FileName);
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Ensure the directory exists
                Directory.CreateDirectory(uploadsFolder);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await personDto.Photo.CopyToAsync(stream);
                }

                personDto.PhotoPath = Path.Combine("/images", uniqueFileName).Replace("\\", "/");

                await _personService.AddPersonAsync(personDto);

                return CreatedAtAction(nameof(GetPerson), new { id = personDto.Id }, personDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при сохранении анкеты.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка при сохранении данных. Попробуйте снова.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var success = await _personService.DeletePersonAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _personService.GetAllPersonsAsync();
            return Ok(persons);
        }
    }
}
