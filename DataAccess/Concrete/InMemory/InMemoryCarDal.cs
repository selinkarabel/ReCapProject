using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //global variables in this class we named it with _ 

        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car {Id=1, BrandId=1, ColorId=1,  DailyPrice=100000, ModelYear=2021, Description="SelloCar"},
                new Car {Id=2, BrandId=1, ColorId=1,  DailyPrice=200000, ModelYear=2020, Description="CengoCar"},
                new Car {Id=3, BrandId=2, ColorId=1,  DailyPrice=300000, ModelYear=2019, Description="ChivoCar"},
                new Car {Id=4, BrandId=2, ColorId=2,  DailyPrice=400000, ModelYear=2018, Description="HelloCar"},
                new Car {Id=5, BrandId=2, ColorId=3,  DailyPrice=500000, ModelYear=2017, Description="TeslaCar"}

            }; //When program executes, it will be created
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}
