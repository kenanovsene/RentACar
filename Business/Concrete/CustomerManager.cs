using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccesResult();
        }

        public IResult Delete(Customer customer)
        {
           _customerDal.Delete(customer);   
            return new SuccesResult();
        }

        public IDataResult<Customer> GetCustomerId(int id)
        {
            return new SuccesDataResult<Customer>(_customerDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Update(Customer customer)
        {
           _customerDal.Update(customer);
            return new SuccesResult();
        }
    }
}
