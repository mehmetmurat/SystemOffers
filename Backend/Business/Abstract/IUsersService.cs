using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUsersService
    {
        IDataResult<Users> Get(int userId);
        IDataResult<List<Users>> GetList();
        IResult Add(Users user);
        IResult Delete(Users user);
        IResult Update(Users user);
        IResult UpdateWithExcludeProperty(Users user, string[] excludePropertyNames);
    }
}
