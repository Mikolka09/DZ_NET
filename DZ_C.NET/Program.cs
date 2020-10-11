using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace DZ_C.NET
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();


            Console.SetCursorPosition(20,10);
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ИГРУ \"ПЬЯНИЦА\"!!!");
            Thread.Sleep(2000);
            Game game = new Game();
            Console.Clear();
            game.CreateListPlayers();
            game.Reshuffling();
            game.DistributionOfCards();
            game.StartGame();




            Console.Read();
        }
    }
}
