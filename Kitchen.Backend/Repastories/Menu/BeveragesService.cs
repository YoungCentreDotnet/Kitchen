using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;
using LinqToDB;
using LinqToDB.Tools;
using System.Collections.Generic;

namespace Kitchen.Backend.Repastories.Menu
{
    public class BeveragesService : IBeveragesService
    {
        private readonly KitchenDbContext _menu;

        public BeveragesService(KitchenDbContext menu)
        {
            _menu = menu;

        }
        

        public async Task<StateResponse<Beverages>> AddBeveragesAsync(Beverages entity)
        {
           
            StateResponse<Beverages> stateResponse = new StateResponse<Beverages>();
            var entityData = await _menu.Beveragess.FirstOrDefaultAsync(p => p.Id == entity.Id || p.Name == entity.Name);
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
                    await _menu.Beveragess.AddAsync(entity);
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
                stateResponse.Data = new Beverages();
            }
            return stateResponse;

        }

        public async Task<StateResponse<bool>> DalateBeveragesAsync(int id,string name)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _menu.Beveragess.FirstOrDefaultAsync(p =>p.Id == id && p.Name == name);
                if (entityData is not null)
                {
                    _menu.Beveragess.Remove(entityData);
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

        public async Task<StateResponse<IEnumerable<Beverages>>> GetAllBeveragesAsync()
        {
            StateResponse<IEnumerable<Beverages>> stateResponse = new StateResponse<IEnumerable<Beverages>>();
            try
            {
                var entityData = await _menu.Beveragess.ToListAsync();
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
        public async Task<StateResponse<Beverages>> GetByBeveragesNameAsync(string name)
        {
            StateResponse<Beverages> stateResponse = new StateResponse<Beverages>();
            try
            {
                var entityData = await _menu.Beveragess.FirstOrDefaultAsync(p => p.Name == name);
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
                    stateResponse.Data = new Beverages();

                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Beverages();

            }
            return stateResponse;
        }

        public async Task<StateResponse<Beverages>> MinusBeveragesAsync(string name, int number)
        {
            StateResponse<Beverages> stateResponse = new StateResponse<Beverages>();
            try
            {
                var upd = await _menu.Beveragess.FirstOrDefaultAsync(p => p.Name == name);
                if (upd is not null )
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
                    stateResponse.Data = new Beverages(); 
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Beverages();
            }
            return stateResponse;
        }

        public async Task<StateResponse<Beverages>> PlusBeveragesAsync(string name, int number)
        {
            StateResponse<Beverages> stateResponse = new StateResponse<Beverages>();
            try
            {
                var upd = await _menu.Beveragess.FirstOrDefaultAsync(p => p.Name == name);
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
                    stateResponse.Data = new Beverages();
                }
            }
            catch
            {
                stateResponse.Code = StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
                stateResponse.Data = new Beverages();
            }
            return stateResponse;
        }

        public async Task<StateResponse<bool>> UpdateBeveragesAsync(string name, Beverages entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var upd = await _menu.Beveragess.FirstOrDefaultAsync(p => p.Name == name);
                if (upd is not null && entity is not null)
                {
                    upd.Name = entity.Name;
                    upd.Price = entity.Price;
                    upd.Number = entity.Number;
                    upd.Litr = entity.Litr;
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
