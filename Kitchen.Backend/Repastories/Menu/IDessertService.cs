using Kitchen.Backend.Model.Menu;

namespace Kitchen.Backend.Repastories.Menu
{
    public interface IDessertService
    {
        Task<StateResponse<Dessert>> AddDessertAsync(Dessert entity);
        Task<StateResponse<Dessert>> PlusDessertAsync(string name, int number);
        Task<StateResponse<Dessert>> MinusDessertAsync(string name, int number);
        Task<StateResponse<IEnumerable<Dessert>>> GetAllDessertAsync();
        Task<StateResponse<Dessert>> GetByDessertNameAsync(string name);
        Task<StateResponse<bool>> DalateDessertAsync(string type, string name);
        Task<StateResponse<bool>> UpdateDessertAsync(string type, string name, Dessert entity);
    }
}
