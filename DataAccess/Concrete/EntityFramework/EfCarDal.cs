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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                //another way
                //context.Cars.Add(entity);
                //context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

                //another way
                //context.Cars.Remove(context.Cars.SingleOrDefault(p => p.CarId == entity.CarId));
                //context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                //another way
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
    }
}
