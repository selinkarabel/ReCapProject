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
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("The car which has id number as 3");
            Console.WriteLine((carManager.GetById(3)).CarName);
            


            Console.WriteLine("List of the car that brand id is 3");
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\n");
            carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 00, ModelYear = 2021, Description = "New Hybrid", CarName= "5" });

            carManager.Update(new Car { CarId = 6, BrandId = 3, ColorId = 3, DailyPrice = 125, ModelYear = 2014, Description = "Manuel S", CarName = "Car4" });

            // carManager.Delete(new Car { CarId = 7 });


        }
    }
}
