using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStoreClientRest
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClientGameStore client = new RestClientGameStore();
            client.Start();

            Console.ReadLine();
        }
    }
}
