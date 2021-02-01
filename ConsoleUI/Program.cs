using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());//new InMemoryCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id : " + item.Id);
                Console.WriteLine("Marka Id : " + item.BrandId);
                Console.WriteLine("Model(Yıl) : " + item.ModelYear);
                Console.WriteLine("GünlükFiyat : " + item.DailyPrice);
                Console.WriteLine("Açıklama : " + item.Description);
                Console.WriteLine("-----------------------");

            }
        }
    }
}
