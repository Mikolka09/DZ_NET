using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    public delegate void FinishDelegate();
    public abstract class Car
    {
        public int speed { get; set; }
        public string name { get; set; }    

        public abstract void GoCar();

    }

    class SportCar : Car
    {
        public SportCar()
        {
            speed = 150;
            name = "sportCar";
        }
        public override void GoCar()
        {
            Console.WriteLine("Go Car!");
        }

        public event FinishDelegate finishEvent;
    }

    class PassengerCar : Car
    {
        public PassengerCar()
        {
            speed = 120;
            name = "passengerCar";
        }
        public override void GoCar()
        {
            Console.WriteLine("Go Car!");
        }
        public event FinishDelegate finishEvent;
    }

    class CargoCar : Car
    {
        public CargoCar()
        {
            speed = 100;
            name = "cargoCar";
        }
        public override void GoCar()
        {
            Console.WriteLine("Go Car!");
        }
        public event FinishDelegate finishEvent;
    }
    class Bus : Car
    {
        public Bus()
        {
            speed = 80;
            name = "bus";
        }
        public override void GoCar()
        {
            Console.WriteLine("Go Car!");
        }
        public event FinishDelegate finishEvent;
    }



}
