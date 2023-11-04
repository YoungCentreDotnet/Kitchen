using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Account
{
    public class UserAccountService : IUserAccountService
    {
        private readonly KitchenDbContext _kitchen;

        public UserAccountService(KitchenDbContext kitchen)
        {
            _kitchen = kitchen;

        }
        public async Task<StateResponse<bool>> DalateAsync(string login, string password)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {
                    _kitchen.Users.Remove(entityData);
                    await _kitchen.SaveChangesAsync();
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

        public async Task<StateResponse<IEnumerable<User>>> GetAllDataAsync()
        {

            StateResponse<IEnumerable<User>> stateResponse = new StateResponse<IEnumerable<User>>();
            try
            {
                var entityData = await _kitchen.Users.ToListAsync();
                if (entityData is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = entityData;
                }
                if (stateResponse is not null)
                {
                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = entityData;

                }


            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = null;

            }
            return stateResponse;
        }

        public async Task<StateResponse<User>> GetByIdAsync(int id)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {
                var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (entityData is not null)
                {
                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = new User();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new User();

            }
            return stateResponse;
        }

        public async Task<StateResponse<User>> LogInAsync(string login, string password)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {
                var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {

                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = new User();

                }

            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new User();

            }
            return stateResponse;
        }

        public async Task<StateResponse<User>> SignUpAsync(User entity)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Id == entity.Id);
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
                    await _kitchen.Users.AddAsync(entity);
                    await _kitchen.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status201Created;
                    stateResponse.Message = nameof(StatusCodes.Status201Created);
                    stateResponse.Data = entity;
                }

            }
            catch
            {

                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new User();
            }
            return stateResponse;
        }
        public async Task<StateResponse<bool>> UpdateAsync(int id, User entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _kitchen.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (upd is not null && entity is not null)
                {
                    _kitchen.Users.Update(entity);
                    await _kitchen.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = true;
                }
                if (upd is null || entity is null)
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

