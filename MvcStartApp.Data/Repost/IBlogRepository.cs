using System.Threading.Tasks;
using MvcStartApp.Data.Models;

namespace MvcStartApp.Data.Repost
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}