using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UsersService : IUsersService
    {

        private IUsersDal _IUsersDal;
        public UsersService(IUsersDal usersDal)
        {
            _IUsersDal = usersDal;
        }

        public IResult Add(Users user)
        {
            try
            {
                _IUsersDal.Add(user);
                return new SuccessResult(message: Contants.Messages.AddMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
            
        }

        public IResult Delete(Users user)
        {
            try
            {
                _IUsersDal.Delete(user);
                return new SuccessResult(message: Contants.Messages.DeleteMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }          
        }

        public IDataResult<Users> Get(int userId)
        {
            return new SuccessDataResult<Users>(_IUsersDal.Get(filter: x => x.Id == userId));
        }

        public IDataResult<List<Users>> GetList()
        {
            return new SuccessDataResult<List<Users>>(_IUsersDal.GetList().ToList());
        }

        public IResult Update(Users user)
        {            
            try
            {
                _IUsersDal.Update(user);
                return new SuccessResult(message: Contants.Messages.UpdateMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult UpdateWithExcludeProperty(Users user, string[] excludePropertyNames)
        {
            try
            {
                _IUsersDal.UpdateWithExcludeProperty(user, excludePropertyNames);
                return new SuccessResult(message: Contants.Messages.UpdateMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }
}
