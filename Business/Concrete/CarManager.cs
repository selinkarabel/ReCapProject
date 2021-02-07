using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //this layer calls data access

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        private bool checkCarDescriptionValue(Car car)
        {
            bool checkValue = true;

            if (car.Description.Length <= 2)
                checkValue = false;

            return checkValue;
        }

        private bool checkCarDailyPriceValue(Car car)
        {
            bool checkValue = true;

            if (car.DailyPrice == 0)
                checkValue = false;

            return checkValue;
        }

        public void Add(Car car)
        {
            if (checkCarDescriptionValue(car) == true & checkCarDailyPriceValue(car) == true)
            {
                _carDal.Add(car);
            }
            else if(!checkCarDescriptionValue(car))
            {
                if (!checkCarDailyPriceValue(car))
                {
                    Console.WriteLine("Adding a new car process failed --> Daily Price of the car can not be equal to 0 !");
                }
                
                Console.WriteLine("Adding a new car process failed --> Description of the car must be min 2 characters!");
            }
            else if (!checkCarDailyPriceValue(car))
            {
                if (!checkCarDescriptionValue(car))
                {
                    Console.WriteLine("Adding a new car process failed --> Description of the car must be min 2 characters!");
                }
                
                Console.WriteLine("Adding a new car process failed --> Daily Price of the car can not be equal to 0 !");
            }
            else
            {
                Console.WriteLine("Adding a new car process failed --> PLS contact with system admin..");
            }
        }

        public List<Car> GetAll()
        {
            //business codes

            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
