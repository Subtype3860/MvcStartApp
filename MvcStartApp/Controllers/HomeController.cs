using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Data;
using MvcStartApp.Data.Models;
using MvcStartApp.Data.Repost;
using MvcStartApp.Models;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult>  Index()
        {
            //Создаём пользователя
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иванов",
                LastName = "Иван",
                JoinDate = DateTime.Now
            };
            //Добавляем пользователя
            await _repository.AddUser(user);
            // Выведем результат в консоль
            Console.WriteLine($"User with id {user.Id}, named {user.FirstName} was successfully added on");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
