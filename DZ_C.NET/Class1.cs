using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    partial class Car
    {
        public void Print()
        {
            Console.WriteLine("Созданный автомобиль: ");
            Console.WriteLine();
            Console.WriteLine($"Автомобиль МАРКА - {Brand}, Тип - {Type}, Вид топлива - {TypeGas}\n" +
                              $"Объем двигателя - {Volume}, Кол-во лошадинных сил - {Horsepower} и " +
                              $"Дата изготовления - {Date}");
        }

        public void Beep()
        {
            Console.WriteLine("Проверка сигнала!!!");
            Console.Beep();
        }

        public void DateTime(ref int d)
        {
            Date = d;
        }
    }
}
