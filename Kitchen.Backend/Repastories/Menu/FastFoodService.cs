using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model.Menu;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Menu
{
    public class FastFoodService: IFastFoodService
    {
        private readonly KitchenDbContext _menu;

        public FastFoodService(KitchenDbContext menu)
        {
            _menu = menu;

        }


        public async Task<StateResponse<FastFood>> AddFastFoodAsync(FastFood entity)
        {

            StateResponse<FastFood> stateResponse = new StateResponse<FastFood>();
            var entityData = await _menu.FastFoods.FirstOrDefaultAsync(p => p.Id == entity.Id);
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
                    await _menu.FastFoods.AddAsync(entity);
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
                stateResponse.Data = new FastFood();
            }
            return stateResponse;

        }

        public async Task<StateResponse<bool>> DalateFastFoodAsync(string type, string name)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _menu.FastFoods.FirstOrDefaultAsync(p => p.Type == type && p.Name == name);
                if (entityData is not null)
                {
                    _menu.FastFoods.Remove(entityData);
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

        public async Task<StateResponse<IEnumerable<FastFood>>> GetAllFastFoodAsync()
        {
            StateResponse<IEnumerable<FastFood>> stateResponse = new StateResponse<IEnumerable<FastFood>>();
            try
            {
                var entityData = await _menu.FastFoods.ToListAsync();
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
        public async Task<StateResponse<FastFood>> GetByFastFoodNameAsync(string name)
        {
            StateResponse<FastFood> stateResponse = new StateResponse<FastFood>();
            try
            {
                var entityData = await _menu.FastFoods.FirstOrDefaultAsync(p => p.Name == name);
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
                    stateResponse.Data = new FastFood();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new FastFood();

            }
            return stateResponse;
        }

        public async Task<StateResponse<bool>> UpdateFastFoodAsync(string type, string name, FastFood entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _menu.FastFoods.FirstOrDefaultAsync(p => p.Type == type && p.Name == name);
                if (upd is not null && entity is not null)
                {
                    upd.Name = entity.Name;
                    upd.Price = entity.Price;
                    upd.Discreption = entity.Discreption;
                    await _menu.SaveChangesAsync();
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

