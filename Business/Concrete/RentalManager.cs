using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalSevice
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (!(rental.ReturnDate == null))
            {
                return new ErrorResult(Messages.NotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);  
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>();    
        }

        public IDataResult<Rental> GetRentalByCarId(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(r=>r.CarId==id));
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccesDataResult <Rental>(_rentalDal.Get(r=>r.Id==id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.Updated);
        }

        public IDataResult<List<RentalDatailDto>> GetRentalDetails()
        {
           
            return new SuccesDataResult<List<RentalDatailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
