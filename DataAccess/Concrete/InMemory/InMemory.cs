using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemory : ICarDal
    {
        List<Car> _cars;

        public InMemory()
        {
            _cars = new List<Car> { 
            new Car {Id=1,ColorId=2,BrandId=3, DailyPrice=25000,Name="Camaro",Description="Camaro Cherolet SS",ModelYear="2008"},
            new Car {Id=2,ColorId=3,BrandId=4, DailyPrice=12500,Name="Mazda",Description="Mazda",ModelYear="2008"},
            new Car {Id=3,ColorId=2,BrandId=5, DailyPrice=32000,Name="İ8",Description="BMW i8",ModelYear="2008"}
            };
        }

        public void Add(Car car)
        {
          _cars.Add(car);
            Console.WriteLine("Eklendi");
        }

        public void Delete(Car car)
        {
            //Car carToDelete= null;
            //foreach (var c in _cars)
            //{
            //    if (c.Id==car.Id)
            //    {
            //        carToDelete = c;
            //    }
               
            //}
            Car carToDelete= _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Silindi");
        }

        public List<Car> GetAll()
        {
           return _cars;    
        }

        public List<Car> GetById(int Id)
        {
            List<Car> list = new List<Car>();
            foreach (var c in _cars)
            {
                if (c.Id == Id)
                {
                    list.Add(c);
                }
               

            }
            Console.WriteLine("Listelendi");
            return list;          
           
        }

        public void Update(Car car)
        {
           Car carToUpdate=_cars.SingleOrDefault(c=> c.Id == car.Id);
            //carToUpdate.Id= car.Id;
            carToUpdate.Name = car.Name;
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId= car.ColorId;          
            carToUpdate.Description=car.Description;
            carToUpdate.DailyPrice=car.DailyPrice;           

        }

        public void Try(int Id1)
        {
            Console.WriteLine(Id1);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
