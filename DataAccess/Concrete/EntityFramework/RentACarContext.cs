using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySQL("server=localhost;database=rentacardb;user=root;password=''");
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=rentacardb; user=root; password=''; Persist Security Info=False; Connect Timeout=300;SSL Mode=None");
           // "DArchMySqlContext": "server=localhost; port=3306; database=KidsisDevDb; user=root; password=''; Persist Security Info=False; Connect Timeout=300;SSL Mode=None"
  
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}