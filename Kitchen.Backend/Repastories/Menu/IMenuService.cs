using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;

namespace Kitchen.Backend.Repastories.Menu
{
    public interface IMenuService
    {
        Task<StateResponse<Beverages>> AddFoodAsync(Beverages entity);
        Task<StateResponse<Beverages>> PlusFoodAsync(string name, int number);
        Task<StateResponse<Beverages>> MinusFoodAsync(string name, int number);
        Task<StateResponse<IEnumerable<Beverages>>> GetAllAsync();
        Task<StateResponse<Beverages>> GetByNameAsync(string name);
        Task<StateResponse<bool>> DalateFoodAsync(string type, string name);
        Task<StateResponse<bool>> UpdateAsync(string type, string name, Beverages entity);
    }
}
