using Core.Utilities.Results.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService :IEntity
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(CarImage entity);

        IResult Update(CarImage entity);

        IResult Delete(CarImage entity);
    }
}
