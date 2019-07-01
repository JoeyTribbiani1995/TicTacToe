using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class UserService : IUserService
    {
        public Task<bool> RegisterUser(UserModel userModel)
        {
            return Task.FromResult(true);
        }
    }
}
