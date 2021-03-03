using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(CheckCarImageCount(entity.Id));
            if (result != null)
            {
                return result;
            }

            string createPath = ImagePath(entity.Id);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);

            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.CarId == entity.Id);
            File.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage entity)
        {
            string createPath = ImagePath(entity.Id);
            File.Copy(entity.ImagePath, createPath);
            File.Delete(entity.ImagePath);
            entity.ImagePath = createPath;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfId(carId));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }

            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.Id == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePaths.ImageDefaultPath } });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);


        }

        private IResult[] CheckIfId(int carId)
        {
            throw new NotImplementedException();
        }
        #region Car Image Business Codes

        private string ImagePath(int carId)
        {
            string GuidKey = Guid.NewGuid().ToString();
            return FilePaths.ImageFolderPath + GuidKey + ".jpeg";
        }

        #endregion Car Image Business Codes

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }
            return new SuccessResult();
        }

   

        #endregion Car Image Business Rules
    }
}
