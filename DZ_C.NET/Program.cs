using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    partial class Car
    {
        static string Type;
        static string TypeGas;
        private string Brand;
        private float Volume;
        private int Horsepower;
        private int Date = 0;

        public int MyDate
        {
            get { return Date; }
            set { Date = value; }
        }


        public int MyHorsepower
        {
            get { return Horsepower; }
            set { Horsepower = value; }
        }

        public float MyVolume
        {
            get { return Volume; }
            set { Volume = value; }
        }

        public string MyBrand
        {
            get { return Brand; }
            set { Brand = value; }
        }

        static Car()
        {
            Type = "Passenger";
            TypeGas = "Dizel";
        }

        public Car():this("No Brand", 0, 0) {}

        public Car(string b)
        {
            Brand = b;
        }
        
        public Car(string b, float v, int h)
        {
            Brand = b;
            Volume = v;
            Horsepower = h;
        }

        public void Assembly()
        {
            Console.WriteLine("Производим сборку выбранной модели Автомобиля!!!");
        }

        public void Tests()
        {
            Console.WriteLine("Производим испытания Автомобиля: \n\n" +
                              "1. Провнряем зажигание (заводим авто).\n" +
                              "2. Проверяем в движении на минимальных скоростях.\n" +
                              "3. Проверяем в движении на максимальных скоростях.\n" +
                              "4. Проверяем торможение обычное и экстренное.\n" +
                              "5. Остановка авто и составление заключения испытаний.\n");
        }

        public void Defective()
        {
            Console.WriteLine("Автомобиль не прошедший испытаний отправляется на выявление дефектов и доработку!!!");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Car car1 = new Car("Audi", 2.8F, 300);
            Car car2 = new Car("Reno", 2.1F, 200);
            Car car3 = new Car("Fiat", 1.5F, 150);
            Car car4 = new Car("Lada", 2.2F, 200);
            Car car5 = new Car("Ford", 2.6F, 250);
            Car car6 = new Car("Geely", 2.1F, 150);

            Car[] arr = new Car[6];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[0] = car1;
                arr[1] = car2;
                arr[2] = car3;
                arr[3] = car4;
                arr[4] = car5;
                arr[5] = car6;
            }

            foreach (var item in arr)
            {
                item.Print();
                Console.WriteLine();
            }

            int d = 2020;
            car1.DateTime(ref d);
            car1.Print();






            Console.Read();
        }
    }
}
