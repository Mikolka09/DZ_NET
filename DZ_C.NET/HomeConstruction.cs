using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DZ_C.NET
{
    interface IWorker
    {
        void Work();
    }

    interface IPart
    {
        void Building();
    }

    class House : IPart
    {
        public void Building()
        {
            Console.WriteLine("\t\t\tHOUSE BUILD!!!\n" +
                              "\t\t\t--------------");
            Console.WriteLine();
            string domik = @"
                           (   )
                          (    )
                           (    )
                          (    )
                            )  )
                           (  (                  /\
                            (_)                 /  \  /\
                    ________[_]________      /\/    \/  \
           /\      /\        ______    \    /   /\/\  /\/\
          /  \    //_\       \    /\    \  /\/\/    \/    \
   /\    / /\/\  //___\       \__/  \    \/
  /  \  /\/    \//_____\       \ |[]|     \
 /\/\/\/       //_______\       \|__|      \
/      \      /XXXXXXXXXX\                  \
        \    /_I_II  I__I_\__________________\
               I_I|  I__I_____[]_|_[]_____I
               I_II  I__I_____[]_|_[]_____I
               I II__I  I     XXXXXXX     I
            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
            Console.WriteLine(domik);

        }
    }

    class Basement : House, IPart
    {
        public void Building()
        {
            Console.WriteLine("Building Basement!");
        }
    }

    class Walls : House, IPart
    {
        public void Building()
        {
            Console.WriteLine("Building Walls!");
        }
    }

    class Door : House, IPart
    {
        public void Building()
        {
            Console.WriteLine("Building Door!");
        }
    }

    class Window : House, IPart
    {
        public void Building()
        {
            Console.WriteLine("Building Window!");
        }
    }

    class Roof : House, IPart
    {
        public void Building()
        {
            Console.WriteLine("Building Roof!");
        }
    }

    class Team : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Teams completed!");
        }
    }

    class Worker : Team, IWorker
    {

        public void Work()
        {
            Console.WriteLine("Worker Building!");
        }
    }

    class TeamLeader : Team, IWorker
    {
        public void Work()
        {
            Console.WriteLine("Form a Report:\n" +
                              "--------------");
        }
    }
}
