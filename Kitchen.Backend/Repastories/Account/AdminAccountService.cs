using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Account
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly KitchenDbContext _kitchen;

        public AdminAccountService(KitchenDbContext kitchen)
        {
            _kitchen = kitchen;

        }
        public async Task<StateResponse<bool>> DalateAsync(string login, string password)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _kitchen.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {
                    _kitchen.Admins.Remove(entityData);
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

        public async Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync()
        {
            
            StateResponse<IEnumerable<Admin>> stateResponse = new StateResponse<IEnumerable<Admin>>();
            try
            {
                var entityData = await _kitchen.Admins.ToListAsync();
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

        public async Task<StateResponse<Admin>> GetByIdAsync(int id)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var entityData = await _kitchen.Admins.FirstOrDefaultAsync(p => p.Id == id);
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
                    stateResponse.Data = new Admin();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }

        public async Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var entityData = await _kitchen.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
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
                    stateResponse.Data = new Admin();

                }

            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }

        public async Task<StateResponse<Admin>> SignUpAsync(Admin entity)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            var entityData = await _kitchen.Admins.FirstOrDefaultAsync(p => p.Id == entity.Id);
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
                    await _kitchen.Admins.AddAsync(entity);
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
                stateResponse.Data = new Admin();
            }
            return stateResponse;

        }
        public async Task<StateResponse<bool>> UpdateAsync(int id, Admin entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _kitchen.Admins.FirstOrDefaultAsync(p => p.Id == id);
                if (upd is not null && entity is not null)
                {
                    upd.FirsName = entity.FirsName;
                    upd.LastName = entity.LastName;
                    upd.Login = entity.Login;
                    upd.Password = entity.Password;
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
