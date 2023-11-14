using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Post;

namespace Kitchen.Backend.Repastories.Posts
{
    public interface IPostService
    {
        Task<StateResponse<Post>> AddPostAsync(Post entity);
        Task<StateResponse<bool>> DalatePostAsync(int id, string postfoto);

    }
}
