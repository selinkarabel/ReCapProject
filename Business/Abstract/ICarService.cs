using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //coding which methods are needed..
    public interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        void Delete(Car car);
        void Update(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}
