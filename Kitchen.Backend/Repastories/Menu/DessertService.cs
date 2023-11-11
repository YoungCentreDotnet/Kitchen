using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model.Menu;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Menu
{
    public class DessertService: IDessertService
    {
        private readonly KitchenDbContext _menu;

        public DessertService(KitchenDbContext menu)
        {
            _menu = menu;

        }


        public async Task<StateResponse<Dessert>> AddDessertAsync(Dessert entity)
        {

            StateResponse<Dessert> stateResponse = new StateResponse<Dessert>();
            var entityData = await _menu.Desserts.FirstOrDefaultAsync(p => p.Id == entity.Id || p.Name == entity.Name);
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
                    await _menu.Desserts.AddAsync(entity);
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
                stateResponse.Data = new Dessert();
            }
            return stateResponse;

        }

        public async Task<StateResponse<bool>> DalateDessertAsync(int id,string name)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _menu.Desserts.FirstOrDefaultAsync(p => p.Id == id && p.Name == name);
                if (entityData is not null)
                {
                    _menu.Desserts.Remove(entityData);
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

        public async Task<StateResponse<IEnumerable<Dessert>>> GetAllDessertAsync()
        {
            StateResponse<IEnumerable<Dessert>> stateResponse = new StateResponse<IEnumerable<Dessert>>();
            try
            {
                var entityData = await _menu.Desserts.ToListAsync();
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
        public async Task<StateResponse<Dessert>> GetByDessertNameAsync(string name)
        {
            StateResponse<Dessert> stateResponse = new StateResponse<Dessert>();
            try
            {
                var entityData = await _menu.Desserts.FirstOrDefaultAsync(p => p.Name == name);
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
                    stateResponse.Data = new Dessert();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Dessert();

            }
            return stateResponse;
        }

        public async Task<StateResponse<Dessert>> MinusDessertAsync(string name, int number)
        {
            StateResponse<Dessert> stateResponse = new StateResponse<Dessert>();
            try
            {
                var upd = await _menu.Desserts.FirstOrDefaultAsync(p => p.Name == name);
                if (upd is not null)
                {
                    upd.Number -= number;
                    await _menu.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = upd;
                }
                if (upd is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = new Dessert();
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Dessert();
            }
            return stateResponse;
        }

        public async Task<StateResponse<Dessert>> PlusDessertAsync(string name, int number)
        {
            StateResponse<Dessert> stateResponse = new StateResponse<Dessert>();
            try
            {
                var upd = await _menu.Desserts.FirstOrDefaultAsync(p => p.Name == name);
                if (upd is not null)
                {
                    upd.Number += number;
                    await _menu.SaveChangesAsync();
                    stateResponse.Code = StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = upd;
                }
                if (upd is null)
                {
                    stateResponse.Code = StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = new Dessert();
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Dessert();
            }
            return stateResponse;
        }

        public async Task<StateResponse<bool>> UpdateDessertAsync(string name, Dessert entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _menu.Desserts.FirstOrDefaultAsync(p => p.Name == name);
                if (upd is not null && entity is not null)
                {
                    upd.Name = entity.Name;
                    upd.Price = entity.Price;
                    upd.Number = entity.Number;
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

