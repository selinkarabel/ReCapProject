using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //global variables in this class we named it with _ 

        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car {CarId=1, BrandId=1, ColorId=1,  DailyPrice=100000, ModelYear=2021, Description="SelloCar"},
                new Car {CarId=2, BrandId=1, ColorId=1,  DailyPrice=110000, ModelYear=2020, Description="CengoCar"},
                new Car {CarId=3, BrandId=2, ColorId=1,  DailyPrice=120000, ModelYear=2019, Description="ChivoCar"},
                new Car {CarId=4, BrandId=2, ColorId=2,  DailyPrice=250000, ModelYear=2018, Description="DodgeCar"},
                new Car {CarId=5, BrandId=2, ColorId=3,  DailyPrice=300000, ModelYear=2017, Description="TeslaCar"}

            }; //When program executes, it will be created
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(CarToDelete);
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

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
    }
}
