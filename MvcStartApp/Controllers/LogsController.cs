using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Data.Repost;
using MvcStartApp.Models;

namespace MvcStartApp.Controllers;

public class LogsController : Controller
{
    private readonly IRequestRepository _repository;

    public LogsController(IRequestRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await _repository.GetRequest();
        return View(model);
    }
}