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

            BasicOperator.Multiply("324".ToArray(), "432".ToArray());
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
                    // Test();
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
//                      case '+':
//                          result = BasicOperator.Plus(left, right);
//                          Console.Out.WriteLine(result);
//                          break;
//                      case '-':
//                            result = BasicOperator.Minus(left, right);
//                          Console.Out.WriteLine(result);
//                          break;
//                      case '*':
//                          result = BasicOperator.Multiply(left, right);
//                          Console.Out.WriteLine(result);
//                          break;
//                      case '/':
//                          pair = BasicOperator.Divide(left, right);
//                          Console.Out.WriteLine(pair.first);
//                          Console.Out.WriteLine(pair.second);
//                          break;
//                      default:
//                          Console.WriteLine("Program doesn't support this operation!");
                     default:
                         break;
                 }
                 Console.WriteLine();
              }
        }

//         private static void Test()
//          {
//              Console.Clear();
//              string left;
//              string right;
//              string result;
//              string operation;
//              Pair<String, String> pair;
//              Stopwatch watch = new Stopwatch();
//              long ts;
// 
//              while (true)
//              {
//                  Console.WriteLine("input operation label(+,-,*,/): ");
//                  operation = Console.ReadLine();
//                  if (operation.ToLower().Equals("exit"))
//                  {
//                      break;
//                  }
//                  if (!CheckOperation(operation))
//                  {
//                      Console.WriteLine("Invalid operation!");
//                      Console.WriteLine("");
//                      continue;
//                  }
//                  Console.WriteLine("input left operand: ");
//                  left = Console.ReadLine();
//                  if(left.Contains("G "))
//                  {
//                      try
//                      {
//                          left = GenerateInput(int.Parse(left.Substring(2)));
//                      }
//                      catch   (Exception e)
//                      {
//                          Console.WriteLine("Invalid input!");
//                          continue;
//                      }
//                  }
//                  if (!BasicOperator.IsValidNum(left))
//                  {
//                      Console.WriteLine("Invalid operand!");
//                      Console.WriteLine("");
//                      continue;
//                  }
//                  Console.WriteLine("input right operand: ");
//                  right = Console.ReadLine();
//                  if (right.Contains("G "))
//                  {
//                      try
//                      {
//                          right = GenerateInput(int.Parse(right.Substring(2)));
//                      }
//                      catch (Exception e)
//                      {
//                          Console.WriteLine("Invalid input!");
//                          continue;
//                      }
//                  }
//                  if (!BasicOperator.IsValidNum(right))
//                  {
//                      Console.WriteLine("Invalid operand!");
//                      Console.WriteLine("");
//                      continue;
//                  }
//                  watch.Start();
//                  switch (operation.ElementAt(0))
//                  {
//                      case '+':
//                          result = BasicOperator.Plus(left, right);
//                          watch.Stop();
//                          Console.Out.WriteLine(string.Format("{0}+{1}={2}",left,right,result));
//                          break;
//                      case '-':
//                          result = BasicOperator.Minus(left, right);
//                          watch.Stop();
//                          Console.Out.WriteLine(string.Format("{0}-{1}={2}", left, right, result));
//                          break;
//                      case '*':
//                          result = BasicOperator.Multiply(left, right);
//                          watch.Stop();
//                          Console.Out.WriteLine(string.Format("{0}*{1}={2}", left, right, result));
//                          break;
//                      case '/':
//                          pair = BasicOperator.Divide(left, right);
//                          watch.Stop();
//                          Console.Out.WriteLine(string.Format("{0}/{1}={2}", left, right, pair.first));
//                          Console.Out.WriteLine(string.Format("{0}%{1}={2}", left, right, pair.second));
//                          break;
//                  }
//                  ts = watch.ElapsedMilliseconds;
//                  Console.WriteLine("RunTime for this operation: " + ts + "ms");
//                  Console.WriteLine("");
//              }
//          }
        private static bool CheckOperation(string operate)
        {
            char operation = operate.ElementAt(0);
            if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
            {
                return true;
            }
            return false;
        }
        private static string GenerateInput(int length)
        {
            List<char> buffer = new List<char>(length);
            Random random = new Random();
              buffer.Add((char)random.Next('1','9'));
            for(int i=1;i<length;i++)
            {
                buffer.Add((char)random.Next('0', '9'));
            }
            return new string(buffer.ToArray());
        }
    }

}
