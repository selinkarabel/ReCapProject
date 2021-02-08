using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {

        //another way for Car Add but it is not generic
        //context.Cars.Add(entity);
        //context.SaveChanges();

        //another way for Car Delete but it is not generic
        //context.Cars.Remove(context.Cars.SingleOrDefault(p => p.CarId == entity.CarId));
        //context.SaveChanges();

        //another way for Car update but it is not generic
        //var carToUpdate = context.Cars.SingleOrDefault(p=>p.CarId==entity.CarId);
        //carToUpdate.ColorId = entity.ColorId;
        //carToUpdate.BrandId = entity.BrandId;
        //carToUpdate.DailyPrice = entity.DailyPrice;
        //carToUpdate.ModelYear = entity.ModelYear;
        //carToUpdate.Description = entity.Description;
        //carToUpdate.CarName = entity.CarName;
        //context.SaveChanges();
    }
}
