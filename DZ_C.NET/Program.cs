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

        class Currency
        {
            public int r030 { get; set; }
            public string txt { get; set; }
            public float rate { get; set; }
            public string cc { get; set; }
            public string date { get; set; }

            public override string ToString()
            {
                return $"Code = {r030.ToString().PadLeft(4)}   Name = {txt.PadRight(35)} " +
                       $"Rate = {rate.ToString().PadRight(10)}  Abrivatur = {cc.PadRight(5)}" +
                       $"Exchangedate = {date.PadRight(10)}";
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Clear();

            Console.WriteLine("КУРС ВАЛЮТ НБУ");
            Console.WriteLine("--------------");
            Console.WriteLine();

            XmlDocument doc = new XmlDocument();
            doc.Load("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");

            XmlNodeList list1 = doc.GetElementsByTagName("r030");
            XmlNodeList list2 = doc.GetElementsByTagName("txt");
            XmlNodeList list3 = doc.GetElementsByTagName("rate");
            XmlNodeList list4 = doc.GetElementsByTagName("cc");
            XmlNodeList list5 = doc.GetElementsByTagName("exchangedate");

            Vector v = new Vector(2,5);
            Console.WriteLine(v);

            Console.Read();
        }
    }
}
