using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto 
                             { CarId = c.CarId, 
                                 BrandName = b.BrandName, 
                                 DailyPrice = c.DailyPrice, 
                                 CarName = c._Description,
                                 ColorName=cl.ColorName,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
                      
        }
        public List<CarDetailDto> GetCarsByBrand(int id)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from c in context.Cars
                    where c.BrandId==id
                    join b in context.Brands 
                        on c.BrandId equals b.BrandId
                    join cl in context.Colors
                        on c.ColorId equals cl.ColorId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        CarName = c._Description,
                        ColorName = cl.ColorName,
                        ModelYear = c.ModelYear
                    };
                return result.ToList();
            }
        }
    }
}
