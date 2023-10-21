using System.Threading.Tasks;
using MvcStartApp.Data.Models;

namespace MvcStartApp.Data.Repost;

public interface IRequestRepository
{
    Task AddRequest(Request request);
    Task<Request[]> GetRequest();
}