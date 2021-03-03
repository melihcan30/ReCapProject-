using Business.Concrete;
using DataAccess.Concete.InMemory;
using System;

namespace ConsoleUII
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("Araba Id  Marka Id  Renk Id  Günlük Ücret  Açıklama \n--------------------------------------------------------------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "         " + car.BrandId + "         " + car.ColorId + "         " + car.DailyPrice + "         " + car.Description);
            }

            Console.ReadLine();
        }
    }
}
