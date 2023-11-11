using Kitchen.Backend.Model.Menu;

namespace Kitchen.Backend.Repastories.Menu
{
    public interface IFastFoodService
    {
        Task<StateResponse<FastFood>> AddFastFoodAsync(FastFood entity);
        Task<StateResponse<IEnumerable<FastFood>>> GetAllFastFoodAsync();
        Task<StateResponse<FastFood>> GetByFastFoodNameAsync(string name);
        Task<StateResponse<bool>> DalateFastFoodAsync(string type, int id, string name);
        Task<StateResponse<bool>> UpdateFastFoodAsync(string type, string name, FastFood entity);
    }
}
