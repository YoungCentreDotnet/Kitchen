using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.Account
{
    public interface ITableAccountService
    {
        Task<StateResponse<Table>> AddAsync(Tuple entity);
      
    }
}
