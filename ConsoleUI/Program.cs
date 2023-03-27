// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
namespace ConsoleUI
{
    class Program
    { 
    static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemory());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }
         
        }
    }

}

