using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    public delegate void FinishDelegate();

    public abstract class Car
    {
        public int speedMax { get; set; }
        public string name { get; set; }
        public int distance { get; set; }

        public abstract void GoCar();

    }

    class SportCar : Car
    {
        Random rand = new Random();
        public SportCar()
        {
            speedMax = 110;
            distance = 0;
            name = "SportCar";
        }
        public override void GoCar()
        {
            int distanceRace = rand.Next(1, speedMax);
            distance += distanceRace;

            if (distance >= 500)
            {
                finishEvent();
            }

        }

        public event FinishDelegate finishEvent;

        protected virtual void OnFinishEvent()
        {
            finishEvent?.Invoke();
        }
    }

    class PassengerCar : Car
    {
        Random rand = new Random();
        public PassengerCar()
        {
            speedMax = 100;
            distance = 0;
            name = "PassengerCar";
        }
        public override void GoCar()
        {
            int distanceRace = rand.Next(1, speedMax);
            distance += distanceRace;

            if (distance >= 500)
            {
                finishEvent();
            }
        }

        public event FinishDelegate finishEvent;

        protected virtual void OnFinishEvent()
        {
            finishEvent?.Invoke();
        }
    }

    class TruckCar : Car
    {
        Random rand = new Random();
        public TruckCar()
        {
            speedMax = 90;
            distance = 0;
            name = "TruckCar";
        }
        public override void GoCar()
        {
            int distanceRace = rand.Next(1, speedMax);
            distance += distanceRace;

            if (distance >= 500)
            {
                finishEvent();
            }
        }

        public event FinishDelegate finishEvent;

        protected virtual void OnFinishEvent()
        {
            finishEvent?.Invoke();
        }
    }

    class Bus : Car
    {
        Random rand = new Random();
        public Bus()
        {
            speedMax = 80;
            distance = 0;
            name = "Bus";
        }
        public override void GoCar()
        {
            int distanceRace = rand.Next(1, speedMax);
            distance += distanceRace;

            if (distance >= 500)
            {
                finishEvent();
            }
        }

        public event FinishDelegate finishEvent;

        protected virtual void OnFinishEvent()
        {
            finishEvent?.Invoke();
        }
    }

    class RaceGame
    {
        public void StartGame()
        {

            SportCar sportCar = new SportCar();
            PassengerCar passengerCar = new PassengerCar();
            TruckCar truckCar = new TruckCar();
            Bus bus = new Bus();

            sportCar.finishEvent+=()=>Console.WriteLine("Спортивный автомобиль победил!!!");
            passengerCar.finishEvent += () => Console.WriteLine("Легковой автомобиль победил!!!");
            truckCar.finishEvent += () => Console.WriteLine("Грузовой автомобиль победил!!!");
            bus.finishEvent += () => Console.WriteLine("Автобус победил!!!");

            int countSec = 1;
            Console.WriteLine("seconds\t\tsportCar\tpassangerCar\ttruckCar\tbus");
            Console.WriteLine("----------------------------------------------------------------------");

            while (true)
            {
                sportCar.GoCar();
                passengerCar.GoCar();
                truckCar.GoCar();
                bus.GoCar();

                Console.WriteLine("{0}\t\t{1}m\t\t{2}m\t\t{3}m\t\t{4}m", countSec++, sportCar.distance, passengerCar.distance, truckCar.distance, bus.distance);
                Thread.Sleep(500);
                
                if (sportCar.distance>=500)
                    break;
                if (passengerCar.distance>=500)
                    break;
                if (truckCar.distance>=500)
                    break;
                if (bus.distance>=500)
                    break;
            }

        }

    }
    

}










