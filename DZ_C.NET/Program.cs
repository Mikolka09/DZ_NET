using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApplication1;
using Loger;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Xml;


namespace DZ_C.NET
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Clear();

            Vector v = new Vector(2, 5);
            Console.WriteLine(v);

            Console.Read();
        }
    }
}
