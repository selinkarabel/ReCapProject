using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of the car that color id is 1");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("List of the car that car id is 3");
            foreach (var car in carManager.GetById(3))
            {
                Console.WriteLine(car.Description);
            }


            Console.WriteLine("List of the car that brand id is 3");
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n");
            carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 00, ModelYear = 2021, Description = "A" });
        }
    }
}
