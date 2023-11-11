using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Stock;
using Kitchen.Backend.Repastories.Menu;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Stock
{
    public class KgProductService : IKgProductService
    {
        private readonly KitchenDbContext _menu;

        public KgProductService(KitchenDbContext menu)
        {
            _menu = menu;

        }


        public async Task<StateResponse<KgProduct>> AddKgProductAsync(KgProduct entity)
        {

            StateResponse<KgProduct> stateResponse = new StateResponse<KgProduct>();
            var entityData = await _menu.KgProducts.FirstOrDefaultAsync(p => p.Id == entity.Id || p.ProductName == entity.ProductName);
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
                    await _menu.KgProducts.AddAsync(entity);
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
                stateResponse.Data = new KgProduct();
            }
            return stateResponse;

        }

        public async Task<StateResponse<bool>> DalateKgProductAsync(int id, string name)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _menu.KgProducts.FirstOrDefaultAsync(p => p.Id == id && p.ProductName == name);
                if (entityData is not null)
                {
                    _menu.KgProducts.Remove(entityData);
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

        public async Task<StateResponse<IEnumerable<KgProduct>>> GetAllKgProductAsync()
        {
            StateResponse<IEnumerable<KgProduct>> stateResponse = new StateResponse<IEnumerable<KgProduct>>();
            try
            {
                var entityData = await _menu.KgProducts.ToListAsync();
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
        public async Task<StateResponse<KgProduct>> GetByKgProductNameAsync(string name)
        {
            StateResponse<KgProduct> stateResponse = new StateResponse<KgProduct>();
            try
            {
                var entityData = await _menu.KgProducts.FirstOrDefaultAsync(p => p.ProductName == name);
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
                    stateResponse.Data = new KgProduct();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new KgProduct();

            }
            return stateResponse;
        }

        public async Task<StateResponse<KgProduct>> MinusKgProductAsync(string name, int number)
        {
            StateResponse<KgProduct> stateResponse = new StateResponse<KgProduct>();
            try
            {
                var upd = await _menu.KgProducts.FirstOrDefaultAsync(p => p.ProductName == name);
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
                    stateResponse.Data = new KgProduct();
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new KgProduct();
            }
            return stateResponse;
        }

        public async Task<StateResponse<KgProduct>> PlusKgProductAsync(string name, int number)
        {
            StateResponse<KgProduct> stateResponse = new StateResponse<KgProduct>();
            try
            {
                var upd = await _menu.KgProducts.FirstOrDefaultAsync(p => p.ProductName == name);
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
                    stateResponse.Data = new KgProduct();
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new KgProduct();
            }
            return stateResponse;
        }

        public async Task<StateResponse<bool>> UpdateKgProductAsync(string name, KgProduct entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _menu.KgProducts.FirstOrDefaultAsync(p => p.ProductName == name);
                if (upd is not null && entity is not null)
                {
                    upd.ProductName = entity.ProductName;
                    upd.DateReceived = entity.DateReceived;
                    upd.StorageDate = entity.StorageDate;
                    upd.Number = entity.Number;
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
