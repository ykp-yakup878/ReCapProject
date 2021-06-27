using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> getClaims(User user);
        //List<User> GetAll();
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
        //void Update(User user);
        //void Delete(User user);
    }
}
