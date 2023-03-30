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

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Name);
            //}

        }
        //private static void CarsInfoListed(CarManager carManager)
        //{
        //    var result = carManager.G;
        //    if (result.Success == true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine($"Araba Adı: {car.CarName}\n" +
        //                $"Araba Günlük Fiyatı: {car.DailyPrice}\n" +
        //                $"Araba Markası: {car.BrandName}\n" +
        //                $"Araba Rengi: {car.ColorName}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
    }
}



