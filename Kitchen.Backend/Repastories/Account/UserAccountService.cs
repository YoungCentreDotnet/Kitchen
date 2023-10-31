﻿using Kitchen.Backend.DataLayer;
using Kitchen.Backend.Model;
using LinqToDB;

namespace Kitchen.Backend.Repastories.Account
{
    public class UserAccountService: IUserAccountService
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

        public async Task<StateResponse<IEnumerable<User>>> GetAllDataAsync()
        {

            StateResponse<IEnumerable<User>> stateResponse = new StateResponse<IEnumerable<User>>();
            try
            {
                var entityData = await _kitchen.Users.ToListAsync();
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = entityData;
                }
                if (stateResponse is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }


            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
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

        public async Task<StateResponse<User>> SignUpAsync(User entity)
        {
            StateResponse<User> stateResponse = new StateResponse<User>();
            try
            {

                if (entity is not null)
                {
                    await _kitchen.AddAsync(entity);
                    await _kitchen.SaveChangesAsync();

                    stateResponse.Code = (int)StatusResponse.Created;
                    stateResponse.Message = nameof(StatusResponse.Created);
                    stateResponse.Data = entity;

                }
                else if (entity is null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = new User();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new User();

            }
            return stateResponse
            ;
        }
    }
}
