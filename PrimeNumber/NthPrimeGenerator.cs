using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.IO;

namespace BigIntOperator
{
    // for up bound 10^8
    public class NthPrimeGenerator
    {
        static List<Pair<uint, int>> primeTable = null;              // first: value and second:number bounded by value

        public NthPrimeGenerator()
        {
                 if(primeTable==null)
                 {
                     GeneratePrimeTable();
                 }
        }

        public uint GetNthPrime(int Nth)
        {
            if (Nth > 664579)
            {
                int index = GetLowerBound(Nth);
                Pair<uint, int> lowerBound = primeTable[index];
                if (lowerBound.second == Nth)
                {
                    return lowerBound.first;
                }
                else
                {
                    int currentNum = lowerBound.second;
                    uint begin = lowerBound.first+1;
                    int primeNeedNum = Nth - currentNum;
                    List<uint> list;
                    uint end;

                    while(primeNeedNum>0)
                    {
                        end = begin +(uint)( primeNeedNum*Math.Log(begin)*1.2);
                        list = GetPrimes(begin, end);
                        if(list.Count>primeNeedNum)
                        {
                            return list[(int)primeNeedNum - 1];
                        }
                        else
                        {
                            begin = end + 1;
                            primeNeedNum = primeNeedNum - list.Count;
                        }
                    }
                }
            }
            else
            {   // with basic method

                int primeNeedNum = Nth ;
                uint begin = 1;
                uint end;
                 List<uint> list;

                 while (primeNeedNum > 0)
                 {
                     list = GetPrimes(begin, end = begin + (uint)(primeNeedNum * Math.Log(begin+2) * 1.2));
                     if (list.Count >= primeNeedNum)
                     {
                         return list[primeNeedNum - 1];
                     }
                     else
                     {
                         begin = end + 1;
                         primeNeedNum = primeNeedNum - list.Count;
                     }
                 }
            }
            return 0;
        }

        private List<uint> GetPrimes(uint begin,uint end)
        {
            if (begin != 1)
            {
                List<uint> lowPrimes = GetPrimes(1, (uint)Math.Sqrt(end));
                List<uint> primes = new List<uint>((int)(end / Math.Log(end) * 1.2));
                uint startPoint;
                byte[] flag = new byte[end-begin+1];
                for (uint i = 0; i < flag.Length;i++ )
                {
                    flag[i] = 1;
                }

                    foreach (uint prime in lowPrimes)
                    {
                        startPoint = (begin / prime + 1) * prime - begin;
                        if(startPoint==prime)
                        {
                            flag[0] = 0;
                        }
                        while (startPoint <= end - begin)
                        {
                            flag[startPoint] = 0;
                            startPoint += prime;
                        }
                    }
                for(uint i=0;i<flag.Length;i++)
                {
                    if (flag[i] == 1)
                    {
                        primes.Add(i + begin);
                    }
                }
                return primes;
            }
            else
            {
                byte[] flag = new byte[end+1]; 
                List<uint> list = new List<uint>((int)(end/Math.Log(end)*1.25));
                uint current = 2;
                list.Add(2);
                uint j;

                for(uint i=2;i<flag.Length;i++)
                {
                    flag[i] = 1;
                }
                while((j=(uint)Math.Pow(current,2))<=end)
                {
                        while(j<=end)
                        {
                            flag[j] = 0;
                            j = j + current;
                        }
                    while(flag[++current]==0)
                    {
                        continue;
                    }
                }
                for(uint i=3;i<flag.Length;i++)
                {
                     if(flag[i]==1)
                     {
                      list.Add(i);
                     }
                }
                return list;
            }

        }

        private void GeneratePrimeTable()
        {
            primeTable = new List<Pair<uint, int>>();
            Pair<uint, int> pair = new Pair<uint, int>();
            for(int i=0;i<upBounds.Length;i++)
            {
                pair = new Pair<uint, int>();
                pair.first = upBounds[i];
                pair.second = primeNumber[i];
                primeTable.Add(pair);
            }
        }
        private void LoadPrimeTable()
        {
            primeTable = new List<Pair<uint, int>>();
            String path = "D:/Codes/Project/C#/BigIntOperator/BigIntOperator/data/Prime number table smaller.txt";
            StreamReader streamReader = new StreamReader(path);
            String line;
            String[] array;
            Pair<uint, int> pair = new Pair<uint, int>();

            while ((line = streamReader.ReadLine()) != null)
            {
                pair = new Pair<uint, int>();
                array = line.Split('\t');
                pair.first = ParseScienceDecimal(array[0]);
                pair.second = int.Parse(array[1]);
                primeTable.Add(pair);
            }
            streamReader.Close();
            StorePrimeTable();
        }
        private uint ParseScienceDecimal(String scienceDecimal)
        {
            String[] array;
            char[] charArray ;
            char[] array2;
            int bitNum = 0;
             uint index = 0;

            array = scienceDecimal.Split("e+".ToArray());
            charArray = array[0].ToArray();
            if(array[2].ElementAt(0)=='0')
            {
                bitNum = array[2].ElementAt(1) - '0'+1;
            }
            else
            {
                bitNum = int.Parse(array[2]);
            }
            array2 = new char[bitNum];
            if (bitNum < charArray.Length - 1)
            {
                for (int i = 0; i < bitNum; i++)
                {
                    if (charArray[index] == '.')
                    {
                        index++;
                    }
                    array2[i] = (charArray[index++]);
                }
            }
            else
            {
                array2[0] = charArray[0];
                for(int i=2;i<charArray.Length;i++)
                {
                    array2[i-1] = charArray[i];
                }
                for(int i=charArray.Length-1;i<bitNum;i++)
                {
                    array2[i] = '0';
                }
            }
            string str = new string(array2);
            return uint.Parse(str);
        }
        private int GetLowerBound(int Nth)
        {
            // 二分查找法
            int downIndex = 0;
            int upIndex = (int)primeTable.Count ;
            int currentIndex = upIndex / 2;
            int temp;

            while (currentIndex > downIndex)
            {
                if ((temp = Nth-primeTable[currentIndex].second) > 0)
                {
                    downIndex = currentIndex;
                    currentIndex = (downIndex + upIndex) / 2;
                }
                else  if(temp<0)
                {
                    upIndex = currentIndex;
                    currentIndex = (downIndex + upIndex) / 2;
                }
                else
                {
                    return currentIndex;
                }
            }
            return currentIndex;

        }
   
        private void StorePrimeTable()
        {
            String filePath = "D:/Codes/Project/C#/BigIntOperator/BigIntOperator/data/Prime number table smaller copy.txt";
            StreamWriter writer = new StreamWriter(filePath);

              foreach(Pair<uint,int> pair in primeTable)
              {
                  writer.WriteLine(pair.first + "\t" + pair.second);
              }
              writer.Close();
        }

        static uint[] upBounds = new uint[]
        {
  10,
30,
50,
70,
90,
100,
200,
300,
400,
500,
600,
700,
800,
900,
1000,
2000,
3000,
4000,
5000,
6000,
7000,
8000,
9000,
10000,
20000,
30000,
40000,
50000,
60000,
70000,
80000,
90000,
100000,
200000,
300000,
400000,
500000,
600000,
700000,
800000,
900000,
1000000,
2000000,
3000000,
4000000,
5000000,
6000000,
7000000,
8000000,
9000000,
10000000,
20000000,
30000000,
40000000,
50000000,
60000000,
70000000,
80000000,
90000000,
100000000,
200000000,
300000000,
400000000,
500000000,
600000000,
700000000,
800000000,
900000000,
1000000000,
2000000000
        };
        static int[] primeNumber = new int[]{
            4,
10,
15,
19,
24,
25,
46,
62,
78,
95,
109,
125,
139,
154,
168,
303,
430,
550,
669,
783,
900,
1007,
1117,
1229,
2262,
3245,
4203,
5133,
6057,
6935,
7837,
8713,
9592,
17984,
25997,
33860,
41538,
49098,
56543,
63951,
71274,
78498,
148933,
216816,
283146,
348513,
412849,
476648,
539777,
602489,
664579,
1270607,
1857859,
2433654,
3001134,
3562115,
4118064,
4669382,
5216954,
5761455,
11078937,
16252325,
21336326,
26355867,
31324703,
36252931,
41146179,
46009215,
50847534,
98222287
        };
    }

 
}
