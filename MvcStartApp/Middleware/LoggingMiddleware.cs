using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MvcStartApp.Data.Models;
using MvcStartApp.Data.Repost;
using MvcStartApp.Models;

namespace MvcStartApp.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestRepository _repository;
    /// <summary>
    ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
    /// </summary>
    public LoggingMiddleware(RequestDelegate next, IRequestRepository repository)
    {
        _next = next;
        _repository = repository;
    }
    /// <summary>
    ///  Необходимо реализовать метод Invoke  или InvokeAsync
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        await LogDb(context);
        // Передача запроса далее по конвейеру
        await _next.Invoke(context);
    }
    private async Task LogDb(HttpContext context)
    {
        var model = new Request
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            Url = context.Request.Host.Value + context.Request.Path
        };
        await _repository.AddRequest(model);
    }
    
}