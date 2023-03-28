//Создать следующие классы: (1) автомобиль Car, (2) гараж Garage, (3) мойка Washer.
//(4) Гараж — это коллекция автомобилей. (5) Мойка — независимое предприятие, которое может только
//мыть автомобиль методом Wash. (6) Делегируйте помывку всех автомобилей этому предприятию.

using System;
using System.Collections.Generic;
using System.Threading;

namespace L10
{
    public class Car //1
    {
        public string CarName { get; set; } //название машины

    }
    public class Garage //2
    {
        public List<Car> listgarage = new List<Car>(); //коллекция автомобилей
    }
    public class Washer //3
    {
        public delegate void WashCars(Car car); //делегат

        public WashCars washCars = new WashCars(wash); //6
        public static void wash(Car car) //5
        {
            Console.WriteLine($" Производится промыв автомобиля {car.CarName}...");
            Thread.Sleep(1555);
            Console.WriteLine("Готово!");
            Thread.Sleep(555);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car lada = new Car(); //создаём объект
            Car matiz = new Car();
            Car reno = new Car();
            Car kia = new Car();
            Car toyota = new Car();

            lada.CarName = "Lada Granta"; //даём ему имя
            matiz.CarName = "Daewoo Matiz";
            reno.CarName = "Renault Logan";
            kia.CarName = "Kia Motors";
            toyota.CarName = "Toyota Corolla";

            Garage garage = new Garage();
            garage.listgarage.Add(lada); //кидаем в гараж
            garage.listgarage.Add(matiz);
            garage.listgarage.Add(reno);
            garage.listgarage.Add(kia);
            garage.listgarage.Add(toyota);

            Washer washer = new Washer();

            foreach (var car in garage.listgarage)
            {
                washer.washCars(car); //моем
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Все автомобили чистенькие");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
