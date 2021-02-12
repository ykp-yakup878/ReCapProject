using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //brand 1=tesla
            //brand 2=mercedes
            //brand 3=bmw
            //brand 4=range rover
            //color 1=red
            //color 2=balck
            //color 3=white
            //color 4=gray

            _cars = new List<Car> {
                new Car { CarId=1,BrandId=1,ModelYear=2019,DailyPrice=460000,_Description="Tesla Model S",ColorId=1},
                new Car { CarId=2,BrandId=4,ModelYear=2021,DailyPrice=650000,_Description="Merdeces Benz G Class",ColorId=2},
                new Car { CarId=3,BrandId=2,ModelYear=2016,DailyPrice=450000,_Description="BMW",ColorId=3},
                new Car { CarId=4,BrandId=3,ModelYear=2018,DailyPrice=1200000,_Description="Range Rover",ColorId=4}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete;

            carDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList(); ;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carUpdate;

            carUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate._Description = car._Description;
        }
    }
}
