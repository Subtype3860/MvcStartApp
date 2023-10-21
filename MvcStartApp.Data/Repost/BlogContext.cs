using Microsoft.EntityFrameworkCore;
using MvcStartApp.Data.Models;

namespace MvcStartApp.Data.Repost;

public class BlogContext : DbContext
{
    // Ссылка на таблицу Users
    public DbSet<User> Users { get; set; }
    // Ссылка на таблицу UserPosts
    public DbSet<UserPost> UserPosts { get; set; }
    //Сылка на таблицу Request
    public DbSet<Request> Requests { get; set; }


    // Логика взаимодействия с таблицами в БД
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
