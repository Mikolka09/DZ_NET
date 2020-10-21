using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Loger;

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
        private LogerNew log = new LogerNew();
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
            log.Writer(domik);
           
        }
    }

    class Basement : House, IPart
    {
        private LogerNew log = new LogerNew();
        public void Building()
        {
            Console.WriteLine("Building Basement!");
            log.Writer("Building Basement!");
        }
    }

    class Walls : House, IPart
    {
        private LogerNew log = new LogerNew();
        public void Building()
        {
            Console.WriteLine("Building Walls!");
            log.Writer("Building Walls!");
        }
    }

    class Door : House, IPart
    {
        private LogerNew log = new LogerNew();
        public void Building()
        {
            Console.WriteLine("Building Door!");
            log.Writer("Building Door!");
        }
    }

    class Window : House, IPart
    {
        private LogerNew log = new LogerNew();
        public void Building()
        {
            Console.WriteLine("Building Window!");
            log.Writer("Building Window!");
        }
    }

    class Roof : House, IPart
    {
        private LogerNew log = new LogerNew();
        public void Building()
        {
            Console.WriteLine("Building Roof!");
            log.Writer("Building Roof!");
        }
    }

    class Team : IWorker
    {
        private LogerNew log = new LogerNew();
        public void Work()
        {
            Console.WriteLine("Teams completed!");
            log.Writer("Teams completed!");
        }
    }

    class Worker : Team, IWorker
    {
        private LogerNew log = new LogerNew();
        public void Work()
        {
            Console.WriteLine("Worker Building!");
            log.Writer("Worker Building!");
        }
    }

    class TeamLeader : Team, IWorker
    {
        private LogerNew log = new LogerNew();
        public void Work()
        {
            Console.WriteLine("Form a Report:\n" +
                              "--------------");
            log.Writer("Form a Report:\n" +
                       "--------------");
        }
    }
}
