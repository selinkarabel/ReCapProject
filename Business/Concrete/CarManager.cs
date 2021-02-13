using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        private bool checkCarNameValue(Car car)
        {
            bool checkValue = true;

            if (car.CarName.Length <= 2)
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

        public IResult Add(Car car)
        {
            if (checkCarNameValue(car) == true & checkCarDailyPriceValue(car) == true)
            {
                _carDal.Add(car);

                return new SuccessResult(Messages.CarAdded);
            }
            else if(!checkCarNameValue(car))
            {
                if (!checkCarDailyPriceValue(car))
                {
                    return new ErrorResult(Messages.CarDailyPriceInvalid);
                }

                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (!checkCarDailyPriceValue(car))
            {
                if (!checkCarNameValue(car))
                {
                    return new ErrorResult(Messages.CarNameInvalid);
                }

                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            else
            {
                return new ErrorResult(Messages.ContactSysAdmin);
            }
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            //business codes

            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max),Messages.CarListed);
        }
    }
}
