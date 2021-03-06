﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());//new InMemoryCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            
            
            //RentalTest(rentalManager);
            
            
            //CustomerCrud(customerManager);

            //UserCrud(userManager);

            //CarTest(carManager);

            //ColorCrud(colorManager);

            //CarAddTest();

            //CarBrandFilterTest(carManager);

            //CarColorFilterTest(carManager);

            //LinqTest(carManager);

        }

        private static void RentalTest(RentalManager rentalManager)
        {
            //rentalManager.Add(new Rental {CarId=2,CustomerId=2,RentDate=new DateTime(2021,2,16),ReturnDate= new DateTime(2021, 2, 20) });
            //foreach (var rental in rentalManager.GetAll())
            //{
            //    Console.WriteLine(rental.Id);
            //    Console.WriteLine(rental.CarId);
            //    Console.WriteLine(rental.CustomerId);
            //    Console.WriteLine(rental.RentDate);
            //    Console.WriteLine(rental.ReturnDate);
            //}
        }

        private static void CustomerCrud(CustomerManager customerManager)
        {
            //customerManager.Add(new Customer {UserId=1,CompanyName="X Şirket" });
            //customerManager.Delete(customerManager.GetById(2));
            //customerManager.Update(new Customer {Id=1, UserId=1,CompanyName="XYZ Şirket"});
            //Console.WriteLine(customerManager.GetById(1).CompanyName);
            //foreach (var customer in customerManager.GetAll())
            //{
            //    Console.WriteLine(customer.Id);
            //    Console.WriteLine(customer.UserId);
            //    Console.WriteLine(customer.CompanyName);
            //}
        }

        private static void UserCrud(UserManager userManager)
        {
            //userManager.Add(new User {FirstName="Celil",LastName="Mutlu",Email="celil@mail.com",_Password="123456" });
            //userManager.Delete(userManager.GetById(3));
            //userManager.Update(new User {Id=1, FirstName = "Celil", LastName = "Güz", Email = "celil@mail.com", _Password = "123456"});
            //Console.WriteLine(userManager.GetById(2).FirstName);
            //foreach (var user in userManager.GetAll())
            //{
            //    Console.WriteLine(user.Id);
            //    Console.WriteLine(user.FirstName);
            //    Console.WriteLine(user.LastName);
            //    Console.WriteLine(user.Email);
            //    //Console.WriteLine(user._Password);
            //    Console.WriteLine("////////");
            //}
        }

        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetCarDetail();
            foreach (var item in result.Data)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Id : " + item.CarId);
                Console.WriteLine("Marka Id : " + item.BrandName);
                Console.WriteLine("Renk Id : " + item.ColorName);
                //Console.WriteLine("Model(Yıl) : " + item.ModelYear);
                Console.WriteLine("GünlükFiyat : " + item.DailyPrice);
                //Console.WriteLine("Açıklama : " + item._Description);
                Console.WriteLine("-----------------------");
            }
            //carManager.Update(new Car { CarId = 2003, BrandId = 1005, ColorId = 2, DailyPrice = 750, ModelYear = 2018, _Description = "Reanult F" });
            //carManager.Delete(carManager.GetById(3002));
        }

        private static void ColorCrud(ColorManager colorManager)
        {
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine(item.ColorName);
            //}

            colorManager.Add(new Color { ColorName = "Purple" });
            colorManager.Update(new Color { ColorId = 2002, ColorName = "Brown" });
            //colorManager.Delete(colorManager.GetById(2002));
        }

        private static void CarBrandFilterTest(CarManager carManager)
        {
            //markaya göre filtreleme
            
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("Id : " + car.CarId);
                //Console.WriteLine("Marka Id : " + car.BrandId);
                //Console.WriteLine("Renk Id : " + car.ColorId);
                //Console.WriteLine("Model(Yıl) : " + car.ModelYear);
                //Console.WriteLine("GünlükFiyat : " + car.DailyPrice);
                //Console.WriteLine("Açıklama : " + car._Description);
                Console.WriteLine("-----------------------");
            }
        }

        private static void CarColorFilterTest(CarManager carManager)
        {
            //renge göre filtreleme
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine("Id : " + car.CarId);
                //Console.WriteLine("Marka Id : " + car.BrandId);
                //Console.WriteLine("Renk Id : " + car.ColorId);
                //Console.WriteLine("Model(Yıl) : " + car.ModelYear);
                //Console.WriteLine("GünlükFiyat : " + car.DailyPrice);
                //Console.WriteLine("Açıklama : " + car._Description);
                Console.WriteLine("-----------------------");
            }
        }

        private static void CarAddTest()
        {
            //CarManager carManager1 = new CarManager(new EfCarDal());
            //ekleme
            //carManager1.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = 2020, _Description = "B", DailyPrice = 1200000 });
            //carManager1.Add(new Car { BrandId = 4, ColorId = 5, ModelYear = 2017, _Description = "Tesla", DailyPrice = 750000 });
            //carManager1.Add(new Car { BrandId = 1005, ColorId = 2, ModelYear = 2018, _Description = "Renault", DailyPrice = 1000 });
        }

        private static void LinqTest(CarManager carManager)
        {
            //  foreach (var item in carManager.GetAll())
            //  {
            //      Console.WriteLine("Id : " + item.Id);
            //      Console.WriteLine("Marka Id : " + item.BrandId);
            //      Console.WriteLine("Renk Id : " + item.ColorId);
            //      Console.WriteLine("Model(Yıl) : " + item.ModelYear);
            //      Console.WriteLine("GünlükFiyat : " + item.DailyPrice);
            //      Console.WriteLine("Açıklama : " + item.Description);
            //      Console.WriteLine("-----------------------");

            //  }

            //  List<Brand> brands = new List<Brand> {
            //      new Brand{BrandId=2,BrandName="Mercedes"},
            //      new Brand{BrandId=1,BrandName="Rolls Royce"},
            //      new Brand{BrandId=3,BrandName="BMW"}
            //  };
            //  List<Colors> colors = new List<Colors> {
            //      new Colors{ColorId=1,ColorName="Red"},
            //      new Colors{ColorId=2,ColorName="Black"},
            //      new Colors{ColorId=3,ColorName="White"},
            //      new Colors{ColorId=4,ColorName="Gray"},
            //  };
            //  List<Car> cars = new List<Car> {
            //      new Car{Id=1,ModelYear=2019,Description="Tesla",DailyPrice=1500000,BrandId=2},
            //      new Car{Id=1,ModelYear=2019,Description="Mercedes",DailyPrice=1500000,BrandId=2},
            //      new Car{Id=2,ModelYear=2018,Description="Bmw",DailyPrice=1200000,BrandId=3},
            //      new Car{Id=3,ModelYear=2021,Description="Rolls Royce",DailyPrice=2500000,BrandId=1},
            //  };

            //  var result = cars.Any(p => p.Description == "bmsw");
            //  Console.WriteLine(result);

            //  var result = cars.Find(p => p.Id == 3);
            //  Console.WriteLine(result.Description);

            //  var result = cars.FindAll(p => p.Description.Contains("m"));
            //  Console.WriteLine(result);//Liste Dönüyor
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine(item.Description);
            //  }

            //  var result = cars.Where(p => p.Description.Contains("m")).OrderBy(p => p.DailyPrice);
            //  var result = cars.Where(p => p.Description.Contains("m")).OrderBy(p => p.DailyPrice).ThenByDescending(p => p.Description);//orderby daki aynı değerlerden birkaç tane varsa bu sefer thenby'a göre sıralam yapsın yoksa thenby çalışmaz.
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine(item.Description);
            //  }

            //  var result = from p in cars
            //               select p;
            //  var result = from p in cars
            //               where p.DailyPrice > 1500000 //&& p.ıd vs.
            //               select p;
            //  var result = from p in cars
            //               where p.DailyPrice > 1400000
            //               orderby p.DailyPrice descending//, p.ModelYear ascending descending
            //               select p;
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine(item.Description);
            //  }

            //  var result = from p in cars
            //               where p.DailyPrice > 1400000
            //               orderby p.DailyPrice descending
            //               select new CarDto { CarId = p.Id, BrandId = p.BrandId, Description = p.Description, ModelYear = p.ModelYear };
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine(item.Description);
            //  }

            //  //ilişkili tasarım
            //  var result = from c in cars
            //               join b in brands
            //on c.BrandId equals b.BrandId       //where orderby kullanılabilir bu sıradan
            //               select new CarDto { CarId = c.Id, Description = c.Description, ModelYear = c.ModelYear, BrandName = b.BrandName };
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine("{0} --- {1}", item.Description, item.BrandName);
            //  }
        }


    }
    //class CarDto
    //{
    //    public int CarId { get; set; }
    //    //public int BrandId { get; set; }
    //    public string BrandName { get; set; }
    //    public string Description { get; set; }
    //    public int ModelYear { get; set; }
    //}
}
