using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

            _cars = new List<Car> {
                new Car { Id=1,BrandId=1,ModelYear=2019,DailyPrice=460000,Description="Tesla Model S"},
                new Car { Id=2,BrandId=4,ModelYear=2021,DailyPrice=650000,Description="Merdeces Benz G Class"},
                new Car { Id=3,BrandId=2,ModelYear=2016,DailyPrice=450000,Description="BMW"},
                new Car { Id=4,BrandId=3,ModelYear=2018,DailyPrice=1200000,Description="Range Rover"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete;

            carDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList(); ;
        }

        public void Update(Car car)
        {
            Car carUpdate;

            carUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}
