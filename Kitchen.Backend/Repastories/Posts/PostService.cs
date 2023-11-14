using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Post;
using LinqToDB;
using System.Xml.Linq;

namespace Kitchen.Backend.Repastories.Posts
{
    public class PostService : IPostService
    {
        private readonly KitchenDbContext _menu;

        public PostService(KitchenDbContext menu)
        {
            _menu = menu;

        }
        public async Task<StateResponse<Post>> AddPostAsync(Post entity)
        {
            StateResponse<Post> stateResponse = new StateResponse<Post>();
            var entityData = await _menu.Posts.FirstOrDefaultAsync(p => p.Id == entity.Id || p.PostFoto == entity.PostFoto);
            try
            {
                if (entityData is not null)
                {
                    stateResponse.Code = StatusCodes.Status302Found;
                    stateResponse.Message = nameof(StatusCodes.Status302Found);
                    stateResponse.Data = entity;
                }
                else if (entityData is null && entity is not null)
                {
                    await _menu.Posts.AddAsync(entity);
                    await _menu.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status201Created;
                    stateResponse.Message = nameof(StatusCodes.Status201Created);
                    stateResponse.Data = entity;
                }

            }
            catch
            {

                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Post();
            }
            return stateResponse;

        }
    

        public async Task<StateResponse<bool>> DalatePostAsync(int id, string postfoto)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _menu.Posts.FirstOrDefaultAsync(p => p.Id == id && p.PostFoto == postfoto);
                if (entityData is not null)
                {
                    _menu.Posts.Remove(entityData);
                    await _menu.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status202Accepted;
                    stateResponse.Message = nameof(StatusCodes.Status202Accepted);
                    stateResponse.Data = true;

                }
                if (entityData is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = false;

                }

            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = false;

            }
            return stateResponse;
        }
    
    }
}
