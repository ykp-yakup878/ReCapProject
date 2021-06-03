using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, ReCapProjectContext>, IFindeksDal
    {
        public List<FindeksDetailDto> GetFindeksDetail(Expression<Func<FindeksDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from f in context.Findeks
                             join u in context.Users on f.UserId equals u.Id
                             select new FindeksDetailDto()
                             {
                                 FindeksId = f.Id,
                                 UserId=u.Id,
                                 FindeksScore=f.FindeksScore,
                                 UserName=u.FirstName+" "+u.LastName
                             };
                return filter == null ? result.ToList():result.Where(filter).ToList();
            }
        }
    }
}
