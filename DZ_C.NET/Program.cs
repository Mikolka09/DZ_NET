using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //ВСТРЕЧА 1

            //Задание 1
            //int n = 0;  //количество введенных пробелов
            //Console.WriteLine("Введите символы: ");
            //while(!Console.ReadLine().StartsWith("."))  //Считывает символы пока не введем точку
            //{
            //    if (Console.ReadLine().StartsWith(" "))
            //        n++;
            //}
            //Console.WriteLine($"Количество пробелов = {n}");

            //Задание 2
            Console.WriteLine("Введите номер трамвайного билета (6-ть цифр): ");
            int n = Convert.ToInt32(Console.ReadLine());
            int n1, n2, n3, n4, n5, n6;
            n6 = n % 10;
            n5 = (n / 10) % 10;
            n4 = (n / 100) % 10;
            n3 = (n / 1000) % 10;
            n2 = (n / 10000) % 10;
            n1 = n / 100000;
            if ((n1 + n2 + n3) == (n4 + n5 + n6))
                Console.WriteLine("Данный билет является счастливым!!!");
            else
                Console.WriteLine("Данный билет не является счастливым!");

            //Задание 3
            char st = Convert.ToChar(Console.ReadLine());
            

            Console.Read();
        }
    }
}
