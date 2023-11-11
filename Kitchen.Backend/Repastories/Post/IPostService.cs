using Kitchen.Backend.Model;

namespace Kitchen.Backend.Repastories.Post
{
    public interface IPostService
    {
        Task<StateResponse<Post>> SignUpAsync(Admin entity);
        Task<StateResponse<Admin>> LogInAsync(string login, string password);
        Task<StateResponse<bool>> DalateAsync(string login, string password);
        Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync();
        Task<StateResponse<Admin>> GetByIdAsync(int id);
        Task<StateResponse<bool>> UpdateAsync(int id, Admin entity);
    }
}
