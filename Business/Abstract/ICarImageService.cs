using System.Collections.Generic;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService :IEntity
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarDetailDto>> GetByCarId(int carId);
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
