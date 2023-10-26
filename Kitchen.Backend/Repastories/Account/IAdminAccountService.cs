using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.Account
{
    public interface IAdminAccountService
    {
        Task<StateResponse<Admin>> SignUpAsync(Admin entity);
        Task<StateResponse<Admin>> LogInAsync(string login, string password);
        Task<StateResponse<bool>> DalateAsync(string login, string password);
        Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync();
        Task<StateResponse<Admin>> GetByIdAsync(int id);
    }
}
