using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Data.Models;

namespace MvcStartApp.Data.Repost
{
    public class BlogRepository : IBlogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Добавляем User
        /// </summary>
        /// <param name="user"></param>
        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);
            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Получаем список User
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}