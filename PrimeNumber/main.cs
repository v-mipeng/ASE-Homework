using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigIntOperator;
using System.Diagnostics;

namespace PrimeNumber
{
    class main
    {
        static NthPrimeGenerator primeGenerator = new NthPrimeGenerator();
        static void Main(String[] args)
        {
           
            int Nth = 0;
            uint result;
            string operation;
            while (true)
            {
                operation = Console.ReadLine();
                if (operation.ToLower().Equals("test"))
                {
                    Test();
                    Console.Clear();
                    continue;
                }
                if (operation.ToLower().Equals("exit"))
                {
                    break;
                }
                try
                {
                    Nth = int.Parse(operation);
                }                                              
                catch(Exception e)
                {
                    Console.WriteLine("Invalid input!");
                }
                result = primeGenerator.GetNthPrime(Nth);
                Console.WriteLine(result);
                }
        }

        private static void Test()
        {
            Console.Clear();
            int Nth = 0;
            uint result;
            string operation;

            Stopwatch watch = new Stopwatch();
            long ts;

            while (true)
            {
                Console.WriteLine("input N to get Nth prime:");
                operation = Console.ReadLine();
                if (operation.ToLower().Equals("exit"))
                {
                    break;
                }
                try
                {
                    Nth = int.Parse(operation);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                }
                watch.Start();
               result =  primeGenerator.GetNthPrime(Nth);
                watch.Stop();
                ts = watch.ElapsedMilliseconds;
                watch.Reset();
                Console.WriteLine(string.Format("The {0}th prime number is:{1}" ,Nth,result));
                Console.WriteLine("RunTime for this operation: " + ts + "ms");
                Console.WriteLine("");
            }
        }
    }
}
