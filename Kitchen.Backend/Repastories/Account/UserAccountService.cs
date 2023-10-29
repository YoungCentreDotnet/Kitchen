using Kitchen.Backend.DataLayer;
using LinqToDB;
using Kitchen.Backend.Model;

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
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = false;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = false;

            }
            return stateResponse;
        }
        ///////////////////////////////////
        public async Task<StateResponse<User>> GetByIdAsync(int id)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {
                var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (entityData is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new User();

                }
            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new User();

            }
            return stateResponse;
        }
        /////////////////////////////////////////////
        public async Task<StateResponse<User>> LogInAsync(string login, string password)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {
                var entityData = await _kitchen.Users.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {

                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new User();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new User();

            }
            return stateResponse;
        }
        ////////////////////////////////////////////////
        public async Task<StateResponse<User>> SignUpAsync(User entity)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {

                if (entity is not null)
                {
                    await _kitchen.AddAsync(entity);
                    await _kitchen.SaveChangesAsync();

                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entity;

                }
                if (entity is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new User();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new User();

            }
            return stateResponse;
        }
        /////////////////////////////////////////////////////
        Task<StateResponse<IEnumerable<User>>> IUserAccountService.GetAllDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
