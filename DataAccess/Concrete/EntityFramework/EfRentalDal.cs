using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public Rental GetLastValue(Rental rental)
        {
            using (RentACarContext context=new RentACarContext())
            {

                return context.Rentals.OrderBy(p => p.Id).LastOrDefault(p => p.CarId == rental.CarId);
            }
        }

        public List<RentalDatailDto> GetRentalDetails()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             join cust in context.Customers
                             on r.CustomerId equals cust.Id
                             join user in context.Users
                             on cust.UserId equals user.Id
                             select new RentalDatailDto
                             {
                                 RentalId = r.Id,
                                 BrandId = b.Id,
                                 CarId = c.Id,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 BrandName = b.Name,
                                 ModelName = c.Name,
                                 CustomerId = cust.Id,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }

        public bool isReturn(Rental rental)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = context.Rentals.OrderBy(P => P.Id).LastOrDefault(p => p.CarId == rental.CarId);
                if (result.RentDate == null) 
                {
                    return false;
                }
                return true;
            }
        }
    }
}
