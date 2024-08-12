using Microsoft.AspNetCore.Mvc;
using PassManagement.Models;
using System.Diagnostics;

namespace PassManagement.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/error")]
        public IActionResult Error()
        {
            return Problem("Произошла ошибка");
        }
    }
}
