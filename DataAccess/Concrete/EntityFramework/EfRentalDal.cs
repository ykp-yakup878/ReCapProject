using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                    join u in context.Users
                        on r.CustomerId equals u.Id
                    join b in context.Cars
                        on r.CarId equals b.CarId
                    select new RentalDetailDto()
                    {
                        RentalId = r.Id,
                        BrandName = b._Description,
                        FullName = u.FirstName + " " + u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();

            }
        }
    }
}
