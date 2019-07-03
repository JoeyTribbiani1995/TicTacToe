using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class UserService : IUserService
    {

        private static ConcurrentBag<UserModel> _userStore;
        public UserService()
        {
            _userStore = new ConcurrentBag<UserModel>();
        }

        public Task<UserModel> GetUserByEmail(string email)
        {
            return Task.FromResult(_userStore.FirstOrDefault(user => user.Email == email));
        }

        public Task<bool> RegisterUser(UserModel userModel)
        {
            _userStore.Add(userModel);
            return Task.FromResult(true);
        }

        public Task UpdateUser(UserModel userModel)
        {
            _userStore = new ConcurrentBag<UserModel>( _userStore.Where(user => user.Email != userModel.Email))
             {
                userModel
             };
            return Task.CompletedTask;
        }
    }
}
