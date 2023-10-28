using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Account
{
    public class UserAccountService : IUserAccountService
    {
        private readonly KitchenDbContext _kitchen;

        public UserAccountService(KitchenDbContext kitchen)
        {
            _kitchen = kitchen;

        }

        public async Task<StateResponse<bool>> DalateAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<StateResponse<IEnumerable<User>>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<StateResponse<User>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StateResponse<User>> LogInAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<StateResponse<User>> SignUpAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
