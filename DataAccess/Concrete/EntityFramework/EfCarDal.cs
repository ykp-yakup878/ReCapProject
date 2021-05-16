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
                                 ModelYear = c.ModelYear,
                                 
                             };
                return result.ToList();
            }
                      
        }
        public List<CarDetailDto> GetCarsByBrand(int brandId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from c in context.Cars
                    where c.BrandId==brandId
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
        public List<CarDetailDto> GetCarsByColor(int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from c in context.Cars
                    where c.ColorId == colorId
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

        public List<CarImageDetailDto> GetCarImageDetail(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                    where c.CarId==carId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join cl in context.Colors
                        on c.ColorId equals cl.ColorId
                    join ci in context.CarImages
                        on c.CarId equals ci.CarId
                    select new CarImageDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        CarName = c._Description,
                        ColorName = cl.ColorName,
                        ModelYear = c.ModelYear,
                        ImagePath = ci.ImagePath
                    };
                return result.ToList();
            }
        }
    }
}
