using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.Account
{
    public interface IUserAccountService
    {
        Task<StateResponse<User>> SignUpAsync(User entity);
        Task<StateResponse<User>> LogInAsync(string login, string password);
        Task<StateResponse<bool>> DalateAsync(string login, string password);
        Task<StateResponse<IEnumerable<User>>> GetAllDataAsync();
        Task<StateResponse<User>> GetByIdAsync(int id);
    }
}
