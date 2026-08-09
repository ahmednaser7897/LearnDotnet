using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class Indexers
    {
        public static void Run()
        {
            Console.WriteLine("-------- Indexers Basics----------");
            var ip1 = new IP(111, 334, 566, 455);
            Console.WriteLine(ip1.Address);
            //this is an object not array but we used Indexers with it
            Console.WriteLine(ip1[3]);
            ip1[2] = 5454;
            Console.WriteLine(ip1.Address);
            Console.WriteLine("-------- Normal String----------");
            var ip2 = new IP("345.977.17.445");
            Console.WriteLine(ip2.Address);
            Console.WriteLine("-------- String With Spaces----------");
            var ip3 = new IP("34 5.9 77.17.44 5");
            Console.WriteLine(ip3.Address);
            Console.WriteLine("-------- String With letters ----------");
            var ip4 = new IP("34 5.9 77.er.44 5");
            Console.WriteLine(ip4.Address);
            Console.WriteLine("-------- String With wrong Length ----------");
            var ip5 = new IP("34 5.9 77.555");
            Console.WriteLine(ip5 .Address);
        }
    }
    class IP
    {
        private int[] segments = new int[4];
        public IP(string ip)
        {
            var ips = ip.Trim().Replace(" ","").Split('.');
            if (ips.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (int.TryParse((ips[i].Trim().Replace(" ", "")), out int value))
                    {
                        segments[i] = value;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Format Not Int");
                        break;
                    }
                }
            }
            else 
            {
                Console.WriteLine("Wrong Format Length");
            }
        }
        public IP(int segment1, int segment2, int segment3, int segment4)
        {
            segments[0] = segment1;
            segments[1] = segment2;
            segments[2] = segment3;
            segments[3] = segment4;
        }
        public string Address => string.Join(".", segments);
        //we can use Indexers to make opject looks like iterables(string , array,.. )
        // we applay this on a iterables item in the class
        public int this[int index]
        {
            get
            {
                return segments[index];
            }
            set
            {
                segments[index] = value;
            }
        }
    }
}
