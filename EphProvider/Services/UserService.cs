using System.Threading.Tasks;
using EphProvider.Data;
using EphProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace EphProvider.Services
{
    public class UserService : IUserService
    {
        private readonly EphProviderContext _dbContext;

        public UserService(EphProviderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
