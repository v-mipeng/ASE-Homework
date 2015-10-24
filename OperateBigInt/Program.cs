using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigIntOperator;
using System.Diagnostics;

namespace OperateBigInt
{
    class Program
    {
         static void Main(String[] args)
        {
            string left;
            string right;
             while(true)
             {
                 Console.WriteLine("input left element: ");
                 left = Console.ReadLine();
                 Console.WriteLine("input right element: ");
                 right = Console.ReadLine();
                 Stopwatch watch = new Stopwatch();
                 watch.Start();
                 Pair<String, String> pair = BasicOperator.Divide(left, right);
                 Console.Out.WriteLine("");
                 Console.Out.WriteLine(pair.first);
                 Console.Out.WriteLine("");
                 Console.Out.WriteLine(pair.second);
                 //Console.Out.WriteLine(BasicOperator.Divide("1928756468456131564654599832456465455484984546548974984659983245646545548498454654897498465192875646845613156465459983245646545548498454654897498465", "99832456465455484984546548974984651928756468456131564654599832456465455484984546548974984651928756468456131564654599832456465455484984546548974984659983245646545548498454654897498465192875646845613156465459983245646545548498454654897498465"));
                 //Console.Out.WriteLine(BasicOperator.Multiply(left, right));
                 watch.Stop();
                 TimeSpan ts = watch.Elapsed;
                 Console.WriteLine("RunTime " + ts.Milliseconds + "ms");
                 //Console.Out.WriteLine(BasicOperator.Minus("19287564684561315646545", "9983245646545548498454654897498465"));
              }
            Console.ReadKey();
        }
    }
}
