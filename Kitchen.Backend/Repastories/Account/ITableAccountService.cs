using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.Account
{
    public interface ITableAccountService
    {
        Task<StateResponse<Tables>> AddAsync(Tables entity);
        Task<StateResponse<bool>> DalateAsync(string login, string password);
        Task<StateResponse<IEnumerable<Tables>>> GetAllDataAsync();
        Task<StateResponse<Tables>> GetByIdAsync(int id);
        Task<StateResponse<bool>> UpdateAsync(int id, Tables entity);

    }
}
