using System.Threading.Tasks;
using EphProvider.Models;

namespace EphProvider.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
