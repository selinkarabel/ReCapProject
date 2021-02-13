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
            //CarTest();
            //BrandTest();
            //ColorTest();

            CarDetailTest();

        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {

                Console.WriteLine("CarName" + " / " + "BrandName" + " / " + "ColorName" + " / " + "DailyPrice");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("List of colors");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Color Id:" + color.ColorId + " Color Name:" + color.ColorName);
            }

            Console.WriteLine("The color which has id number 1");
            Console.WriteLine(colorManager.GetById(1).Data.ColorName);

            //Console.WriteLine("Adding a new color");
            //colorManager.Add(new Color { ColorName = "Blue" });

            //Console.WriteLine("Update a color");
            //colorManager.Update(new Color { ColorId = 1002, ColorName = "Pink" });

            //Console.WriteLine("Delete a color");
            //colorManager.Delete(new Color { ColorId = 1002 });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("List of brands");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Brand id:" + brand.BrandId + " Brand Name:" + brand.BrandName);
            }

            Console.WriteLine("The brand which has id number 3");
            Console.WriteLine(brandManager.GetById(3).Data.BrandName);

            //Console.WriteLine("Adding new brand");
            //Brand newBrand = new Brand();
            //newBrand.BrandName = "Fords";
            //brandManager.Add(newBrand);

            //Console.WriteLine("Update a brand");
            //brandManager.Update(new Brand { BrandId = 1002, BrandName = "Ford" });

            //Console.WriteLine("Delete a brand");
            //brandManager.Delete(new Brand { BrandId = 1002});
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of the car that color id is 1");
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("The car which has id number 3");
            Console.WriteLine((carManager.GetById(3)).Data.CarName);



            Console.WriteLine("List of the car that brand id is 3");
            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("List of cars");
            foreach(var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id:" + car.CarId + " CarName:"  + car.CarName + " Car Description:" + car.Description);
            }

            Console.WriteLine("\n");

            var result = carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 00, ModelYear = 2021, Description = "New Hybrid", CarName = "5" });
            Console.WriteLine(result.Message);


            Console.WriteLine("\n");

            var result2 = carManager.Update(new Car { CarId = 6, BrandId = 3, ColorId = 3, DailyPrice = 125, ModelYear = 2014, Description = "Manuel S", CarName = "Car4" });
            Console.WriteLine(result2.Message);

            // carManager.Delete(new Car { CarId = 7 });
        }
    }
}
