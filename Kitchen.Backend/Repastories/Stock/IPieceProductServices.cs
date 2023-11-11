using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Stock;

namespace Kitchen.Backend.Repastories.Stock
{
    public interface IPieceProductServices
    {
        Task<StateResponse<PieceProduct>> AddPieceProductAsync(PieceProduct entity);
        Task<StateResponse<PieceProduct>> PlusPieceProductAsync(string name, int number);
        Task<StateResponse<PieceProduct>> MinusPieceProductAsync(string name, int number);
        Task<StateResponse<IEnumerable<PieceProduct>>> GetAllPieceProductAsync();
        Task<StateResponse<PieceProduct>> GetByPieceProductNameAsync(string name);
        Task<StateResponse<bool>> DalatePieceProductAsync(int id, string name);
        Task<StateResponse<bool>> UpdatePieceProductAsync(string name, PieceProduct entity);
    }
}
