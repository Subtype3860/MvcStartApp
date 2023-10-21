using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Data;
using MvcStartApp.Data.Models;
using MvcStartApp.Data.Repost;

namespace MvcStartApp.Controllers;

public class UsersController : Controller
{
    private readonly IBlogRepository _repository;
    private readonly BlogContext _context;

    public UsersController(IBlogRepository repository, BlogContext context)
    {
        _repository = repository;
        _context = context;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var model = await _repository.GetUsers();
        return View(model);
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        user.Id = Guid.NewGuid();
        user.JoinDate = DateTime.Now;
        await _repository.AddUser(user);
        return View(user);
    }

    public async Task<ContentResult> AddUser(User user)
    {
        user.JoinDate = DateTime.Now;
        user.Id = Guid.NewGuid();
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Content($"Пользователь {user.FirstName}, добавлен");
    }
}