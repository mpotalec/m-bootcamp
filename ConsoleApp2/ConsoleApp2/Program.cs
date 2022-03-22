using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {
            Car objCar = new Car();
            objCar.year = 1996;
            objCar.type = "Volvo";
            objCar.color = "blue";
            Console.WriteLine(objCar.type);
            Console.WriteLine(objCar.year);
            Console.WriteLine(objCar.color);
            objCar.fullSpeed();
       

            Model objModel = new Model();
            Console.WriteLine(objModel.year);//ocitava iz parenta Car (Inheritance)
            objModel.type = "Audi";
            objModel.horsePower = 100;
            Console.WriteLine(objModel.type); //override modela iz Volvo u Audi (Polymorphism)
            Console.WriteLine(objModel.horsePower); //dodavanje nove klase u childu
            objModel.fullSpeed(); //metoda u prvom childu(Car:Model)
            Console.WriteLine("This " + objCar.type + " is made in " + objCar.year+ " and this car is called "+objModel.type+". It has "+objModel.horsePower+" horsepower!");

            Honk objHonk = new Honk();
            objHonk.honkSound();
            

            List<CarModel> CarModels = new List<CarModel>();

            CarModels.Add(new CarModel
            {
                CarName = "BMW",
                Cost = 10000
            });

            CarModels.Add(new CarModel
            {
                CarName = "Citroen",
                Cost = 3000
            });
            foreach (var carVar in CarModels)
            {
                Console.WriteLine(carVar.CarName);
                Console.WriteLine(carVar.Cost);
            }
            CarModels.Insert(2, new CarModel  //dodavanje nove stavke u listu
            {
                CarName = "Fiat",
                Cost = 7000
            });
            foreach (var carVar in CarModels)
            {
                Console.WriteLine(carVar.CarName);
                Console.WriteLine(carVar.Cost);
            }
            Console.WriteLine("Lets create new car model!");
           
            Car newCarModel = new Car();
            
            Console.WriteLine("Enter model name: ");
            string model = Console.ReadLine();
            newCarModel.type = model;

            Console.WriteLine("Enter color: ");
            newCarModel.color = Console.ReadLine();
        }
    }
}
