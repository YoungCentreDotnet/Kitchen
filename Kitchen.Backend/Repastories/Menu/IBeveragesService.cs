using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;

namespace Kitchen.Backend.Repastories.Menu
{
    public interface IBeveragesService
    {
        Task<StateResponse<Beverages>> AddBeveragesAsync(Beverages entity);
        Task<StateResponse<Beverages>> PlusBeveragesAsync(string name, int number);
        Task<StateResponse<Beverages>> MinusBeveragesAsync(string name, int number);
        Task<StateResponse<IEnumerable<Beverages>>> GetAllBeveragesAsync();
        Task<StateResponse<Beverages>> GetByBeveragesNameAsync(string name);
        Task<StateResponse<bool>> DalateBeveragesAsync(int id, string name);
        Task<StateResponse<bool>> UpdateBeveragesAsync(string name, Beverages entity);
    }
}
