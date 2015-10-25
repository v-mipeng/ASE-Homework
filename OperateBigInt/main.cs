using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigIntOperator;
using System.Diagnostics;

namespace OperateBigInt
{
    class main
    {
         static void Main(String[] args)
        {
          
            string left;
            string right;
            string operation;
            string result;
            Pair<String, String> pair;
             while(true)
             {
                 operation = Console.ReadLine();
                 if(operation.ToLower().Equals("test"))
                 {
                     Test();
                     Console.Clear();
                     continue;
                 }
                 if (operation.ToLower().Equals("exit"))
                 {
                     break;
                 }
                 left = Console.ReadLine();
                 right = Console.ReadLine();
                 switch(operation.ElementAt(0))
                 {
                     case '+':
                         result = BasicOperator.Plus(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '-':
                           result = BasicOperator.Minus(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '*':
                         result = BasicOperator.Multiply(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '/':
                         pair = BasicOperator.Divide(left, right);
                         Console.Out.WriteLine(pair.first);
                         Console.Out.WriteLine(pair.second);
                         break;
                     default:
                         Console.WriteLine("Program doesn't support this operation!");
                         break;
                 }
                 Console.WriteLine();
              }
        }

        private static void Test()
         {
             Console.Clear();
             string left;
             string right;
             string result;
             string operation;
             Pair<String, String> pair;
             Stopwatch watch = new Stopwatch();
             long ts;

             while (true)
             {
                 Console.WriteLine("input operation label(+,-,*,/): ");
                 operation = Console.ReadLine();
                 if (operation.ToLower().Equals("exit"))
                 {
                     break;
                 }
                 if (!CheckOperation(operation))
                 {
                     Console.WriteLine("Invalid operation!");
                     Console.WriteLine("");
                     continue;
                 }
                 Console.WriteLine("input left operand: ");
                 left = Console.ReadLine();
                 if (!BasicOperator.IsValidNum(left))
                 {
                     Console.WriteLine("Invalid operand!");
                     Console.WriteLine("");
                     continue;
                 }
                 Console.WriteLine("input right operand: ");
                 right = Console.ReadLine();
                 if (!BasicOperator.IsValidNum(right))
                 {
                     Console.WriteLine("Invalid operand!");
                     Console.WriteLine("");
                     continue;
                 }
                 watch.Start();
                 switch (operation.ElementAt(0))
                 {
                     case '+':
                         result = BasicOperator.Plus(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '-':
                         result = BasicOperator.Minus(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '*':
                         result = BasicOperator.Multiply(left, right);
                         Console.Out.WriteLine(result);
                         break;
                     case '/':
                         pair = BasicOperator.Divide(left, right);
                         Console.Out.WriteLine(pair.first);
                         Console.Out.WriteLine(pair.second);
                         break;
                 }
                 watch.Stop();
                 ts = watch.ElapsedMilliseconds;
                 Console.WriteLine("RunTime for this operation: " + ts + "ms");
                 Console.WriteLine("");
             }
         }
        private static bool CheckOperation(string operate)
        {
            char operation = operate.ElementAt(0);
            if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
            {
                return true;
            }
            return false;
        }
    }
}
