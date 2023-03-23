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
        public List<Car> garage = new List<Car>(); //коллекция автомобилей 4

    }
    public class Washer //3
    {
        public delegate void WashCars(Car car); //6

        public WashCars washCars = new WashCars(wash);
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

            lada.CarName = "Lada Granta"; //даём ему имя
            matiz.CarName = "Daewoo Matiz";
            reno.CarName = "Renault Logan";

            Garage garage = new Garage();
            garage.garage.Add(lada); //кидаем в гараж
            garage.garage.Add(matiz);
            garage.garage.Add(reno);

            Washer washer = new Washer();

            foreach (var car in garage.garage)
            {
                washer.washCars(car); //моем
            }
            Console.ReadKey();
        }
    }
}