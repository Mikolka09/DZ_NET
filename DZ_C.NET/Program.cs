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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;


namespace DZ_C.NET
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            LogerNew log = new LogerNew();

            Console.WriteLine("BUILDING HOUSE\n" +
                              "--------------\n");
            House[] house = new House[11];
            Team[] teams = new Team[40];
            for (int i = 0; i < teams.Length; i++)
            {
                System.Random rand = new Random();
                int k = rand.Next(0, 2);

                if (k == 0)
                    teams[i] = new Worker();
                else
                    teams[i] = new TeamLeader();
                Thread.Sleep(50);
            }
            new Team().Work();
            Console.WriteLine("=======================\n");
            Console.WriteLine();

            void Report(House[] dom, int hd, LogerNew lg)
            {
                if (hd == 0)
                {
                    Console.WriteLine("Nothing built!");
                    lg.Writer("Nothing built!");
                }
                else
                {
                    for (int i = 0; i < hd; i++)
                    {
                        if (dom[i].GetType() == new Basement().GetType())
                        {
                            Console.WriteLine("Basement build!");
                            lg.Writer("Basement build!");
                        }
                        else if (dom[i].GetType() == new Walls().GetType())
                        {
                            Console.WriteLine("Walls build!");
                            lg.Writer("Walls build!");
                        }
                        else if (dom[i].GetType() == new Door().GetType())
                        {
                            Console.WriteLine("Door build!");
                            lg.Writer("Door build!");
                        }
                        else if (dom[i].GetType() == new Window().GetType())
                        {
                            Console.WriteLine("Window build!");
                            lg.Writer("Window build!");
                        }
                        else if (dom[i].GetType() == new Roof().GetType())
                        {
                            Console.WriteLine("Roof build!");
                            lg.Writer("Roof build!");
                        }
                    }
                }

            }

            int w = 0;
            int h = 0;
            while (house[10] == null)
            {
                if (house[0] == null)
                {
                    if (teams[w].GetType() == new Worker().GetType())
                    {
                        new Worker().Work();
                        house[h] = new Basement();
                        new Basement().Building();
                        h++;
                        w++;
                    }
                    else if (teams[w].GetType() == new TeamLeader().GetType())
                    {
                        new TeamLeader().Work();
                        Report(house, h, log);
                        w++;
                    }

                }
                else if (teams[w].GetType() == new Worker().GetType())
                {
                    if (house[h - 1].GetType() == new Basement().GetType())
                    {
                        new Worker().Work();
                        house[h] = new Walls();
                        new Walls().Building();
                        h++;
                        w++;
                    }
                    else if (house[h - 1].GetType() == new Walls().GetType())
                    {
                        int countW = 0;
                        for (int i = 0; i < h; i++)
                        {
                            if (house[i].GetType() == new Walls().GetType())
                                countW++;
                        }
                        if (countW < 4)
                        {
                            new Worker().Work();
                            house[h] = new Walls();
                            new Walls().Building();
                            h++;
                            w++;
                        }
                        else
                        {
                            new Worker().Work();
                            house[h] = new Door();
                            new Door().Building();
                            h++;
                            w++;
                        }
                    }
                    else if (house[h - 1].GetType() == new Door().GetType())
                    {
                        new Worker().Work();
                        house[h] = new Window();
                        new Window().Building();
                        h++;
                        w++;
                    }
                    else if (house[h - 1].GetType() == new Window().GetType())
                    {
                        int countW = 0;
                        for (int i = 0; i < h; i++)
                        {
                            if (house[i].GetType() == new Window().GetType())
                                countW++;
                        }
                        if (countW < 4)
                        {
                            new Worker().Work();
                            house[h] = new Window();
                            new Window().Building();
                            h++;
                            w++;
                        }
                        else
                        {
                            new Worker().Work();
                            house[h] = new Roof();
                            new Roof().Building();
                            h++;
                            w++;
                        }
                    }
                }
                else if (teams[w].GetType() == new TeamLeader().GetType())
                {
                    new TeamLeader().Work();
                    Report(house, h, log);
                    w++;
                }
                Console.WriteLine("=======================\n");
            }
            house[10].Building();






            //Payment.SerializationAll  = false;
            //Payment pay = new Payment(2,3,5,2);
            //Console.WriteLine(pay);


            //SoapFormatter soap = new SoapFormatter();
            //using (Stream fs = File.Create("pay.soap"))
            //{
            //    soap.Serialize(fs, pay);
            //}

            //XmlSerializer xml = new XmlSerializer(typeof(Payment));
            //using (Stream fs = File.Create("pay.xml"))
            //{
            //    xml.Serialize(fs, pay);
            //}


            //BinaryFormatter bin = new BinaryFormatter();

            //using (Stream fs = File.Create("pay.bin"))
            //{
            //    bin.Serialize(fs, pay);
            //}


            Console.Read();
        }
    }
}
