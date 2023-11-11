using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Stock;

namespace Kitchen.Backend.Repastories.Stock
{
    public interface IKgProductService
    {
        Task<StateResponse<KgProduct>> AddKgProductAsync(KgProduct entity);
        Task<StateResponse<KgProduct>> PlusKgProductAsync(string name, int number);
        Task<StateResponse<KgProduct>> MinusKgProductAsync(string name, int number);
        Task<StateResponse<IEnumerable<KgProduct>>> GetAllKgProductAsync();
        Task<StateResponse<KgProduct>> GetByKgProductNameAsync(string name);
        Task<StateResponse<bool>> DalateKgProductAsync(int id, string name);
        Task<StateResponse<bool>> UpdateKgProductAsync(string name, KgProduct entity);
    }
}
