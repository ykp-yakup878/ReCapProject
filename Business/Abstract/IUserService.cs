using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> getClaims(User user);
        //List<User> GetAll();
        User GetByMail(string email);
        void Add(User user);
        //void Update(User user);
        //void Delete(User user);
    }
}
