﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        private readonly Random _random = new Random();
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = (from p in filter == null ? context.Cars : context.Cars.Where(filter)
                              join c in context.Colors on p.ColorId equals c.ColorId
                              join d in context.Brands on p.BrandId equals d.BrandId
                              join im in context.CarImages on p.CarId equals im.CarId
                              select new CarDetailDto
                              {
                                  BrandId = d.BrandId,
                                  BrandName = d.BrandName,
                                  ModelName = p.ModelName,
                                  ColorId = c.ColorId,
                                  ColorName = c.ColorName,
                                  DailyPrice = p.DailyPrice,
                                  Description = p.Description,
                                  ModelYear = p.ModelYear,
                                  Id = p.CarId,
                                  FindeksScore = _random.Next(1, 1900),
                                  Date = im.Date,
                                  ImagePath = im.ImagePath,
                                  ImageId = im.Id
                              }).ToList();
                return result.GroupBy(p => p.Id).Select(p => p.FirstOrDefault()).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailById(int carId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {

                var result = from p in context.Cars
                             join c in context.Colors on p.ColorId equals c.ColorId
                             join d in context.Brands on p.BrandId equals d.BrandId
                             join im in context.CarImages on p.CarId equals im.CarId
                             where p.CarId == carId
                             select new CarDetailDto
                             {
                                 BrandId = d.BrandId,
                                 BrandName = d.BrandName,
                                 ColorId = c.ColorId,
                                 ModelName = p.ModelName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 Id = p.CarId,
                                 FindeksScore = _random.Next(1, 1900),
                                 Date = im.Date,
                                 ImagePath = im.ImagePath,
                                 ImageId = im.Id
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from car in context.Cars.Where
                        (car => car.BrandId == brandId && car.ColorId == colorId)
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 Id = car.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelName = car.ModelName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from carImage in context.CarImages
                                              where (carImage.CarId == car.CarId)
                                              select carImage).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }

        public int TotalCars()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.Cars.Count();
            }
        }

        public CarDetailDto LastRentedCar()
        {
            //En Son Kiralanan Araba
            using (CarProjectContext context = new CarProjectContext())
            {
                var result =
                    (from r in context.Rentals
                     join c in context.Cars on r.CarId equals c.CarId
                     join cu in context.Customers on r.CustomerId equals cu.CustomerId
                     join b in context.Brands on c.BrandId equals b.BrandId
                     join u in context.Users on cu.UserId equals u.Id
                     join co in context.Colors on c.ColorId equals co.ColorId
                     join im in context.CarImages on c.CarId equals im.CarId
                     orderby r.Id descending
                     select new CarDetailDto
                     {
                         BrandId = b.BrandId,
                         BrandName = b.BrandName,
                         ColorId = co.ColorId,
                         ColorName = co.ColorName,
                         ModelName = c.ModelName,
                         DailyPrice = c.DailyPrice,
                         Description = c.Description,
                         ModelYear = c.ModelYear,
                         Id = c.CarId,
                         FindeksScore = _random.Next(1, 1900),
                         Date = im.Date,
                         ImagePath = im.ImagePath,
                         ImageId = im.Id
                     }).FirstOrDefault();
                return result;
            }
        }

    }
}
