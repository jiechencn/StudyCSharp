using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeightRandom
{
    class Program
    {
        static IDictionary<string, int> servers = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            servers.Add("192.168.0.1", 6);
            servers.Add("192.168.0.2", 1);
            servers.Add("192.168.0.3", 5);
            servers.Add("192.168.0.4", 2);
            servers.Add("192.168.0.5", 8);
            servers.Add("192.168.0.6", 1);
            servers.Add("192.168.0.7", 7);
            servers.Add("192.168.0.8", 1);

            for (int i=0; i<1000; i++)
            {
                Console.WriteLine("server : {0}", GetRandomMachine()) ;
            }


            Console.Read();

            

        }
        public static string GetRandomMachine()
        {
            int allWeight = servers.Sum(server => server.Value);
            int randomNum = new Random().Next(allWeight);
            foreach (var server in servers)
            {
                randomNum -= server.Value;
                if (randomNum <=0)
                {
                    return server.Key;
                }
            }
            return "";
        }
    }
}
