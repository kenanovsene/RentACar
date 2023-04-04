using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
          _carDal = carDal;
        }
        [ValidationAspect(typeof(ValidationAspect))]
        public IResult Add(Car car)
        {
            if (car.Name.Length<=3||car.DailyPrice<0)
            {
                return new ErrorResult(Messages.IncorrectDataEntry);
            }
           _carDal.Add(car);
            return new SuccesResult(Messages.Added);  

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
           return new SuccesDataResult<List<Car>>( _carDal.GetAll());

        }

        public List<CarDetailDto> GetAllDetail()
        {
            return new List<CarDetailDto>(_carDal.GetCarDetails());
        }

        public IDataResult< Car> GetById(int id)
        {
            return new SuccesDataResult< Car>(_carDal.Get(p=>p.Id == id));
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car); 
            return new SuccesResult(Messages.Updated);
        }

        IDataResult<List<CarDetailDto>> ICarService.GetAllDetail()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
