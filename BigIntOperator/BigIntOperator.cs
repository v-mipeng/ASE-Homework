using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BigIntOperator
{
    public class BasicOperator
    {

        public static String Plus(String left, String right)
        {
            if (IsValidInput(left, right))
            {
                char[] buffer = left.Length>right.Length?left.ToArray() : right.ToArray();
                char[] smallNum = left.Length > right.Length ? right.ToArray() : left.ToArray();
                int carry = 0;
                int i;
                int temp;

                for (i = 1; i <= buffer.Length; i++)
                {
                    if (i > smallNum.Length)
                    {
                        if (carry == 0)
                        {
                            break;
                        }
                        else
                        {
                            if ((temp = buffer[buffer.Length - i] - 48 + carry) < 10)
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp);
                                carry = 0;
                            }
                            else
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp % 10);
                                carry = 1;
                            }
                        }
                    }
                    else
                    {
                        if ((temp = buffer[buffer.Length - i] + smallNum[smallNum.Length - i] - 96 + carry) < 10)
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp);
                            carry = 0;
                        }
                        else
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp % 10);
                            carry = 1;
                        }
                    }
                }
                if(carry==0)
                {
                    return new string(buffer);
                }
                else
                {
                    return String.Format("1{0}", buffer);
                }
            }
            else
            {
                throw new Exception("Input is valid!");
            }
        }

        private static char[] Plus(char[] left, char[] right)
        {
   
                char[] buffer = left.Length > right.Length ? left : right;
                char[] smallNum = left.Length > right.Length ? right : left;
                int carry = 0;
                int i;
                int temp;

                for (i = 1; i <= buffer.Length; i++)
                {
                    if (i > smallNum.Length)
                    {
                        if (carry == 0)
                        {
                            break;
                        }
                        else
                        {
                            if ((temp = buffer[buffer.Length - i] - 48 + carry) < 10)
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp);
                                carry = 0;
                            }
                            else
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp % 10);
                                carry = 1;
                            }
                        }
                    }
                    else
                    {
                        if ((temp = buffer[buffer.Length - i] + smallNum[smallNum.Length - i] - 96 + carry) < 10)
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp);
                            carry = 0;
                        }
                        else
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp % 10);
                            carry = 1;
                        }
                    }
                }
                if (carry == 0)
                {
                    return buffer;
                }
                else
                {
                    char[] result = new char[buffer.Length+1];
                    result[0] = '1';
                    buffer.CopyTo(result, 1);
                    return result;
                }
           
        }


        public static String Minus (String left, String right)
        {
            if (IsValidInput(left, right))
            {
                bool isMinus = false;

                char[] buffer;
                char[] smallNum;
                if (left.Length < right.Length)
                {
                    isMinus = true;
                    buffer = right.ToArray();
                    smallNum = left.ToArray();
                }
                else
                {
                    buffer = left.ToArray();
                    smallNum = right.ToArray();
                }
                int carry = 0;
                int i;
                int temp;

                for (i = 1; i <= buffer.Length; i++)
                {
                    if (i > smallNum.Length)
                    {
                        if (carry == 0)
                        {          
                            break;
                        }
                        else
                        {
                            if ((temp = buffer[buffer.Length - i] - 48 + carry) < 0)
                            {
                                buffer[buffer.Length - i] = (char)('0' + 10+temp);
                                carry = -1;
                            }
                            else
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp );
                                carry = 0;
                            }
                        }
                    }
                    else
                    {
                        if ((temp = buffer[buffer.Length - i] - smallNum[smallNum.Length - i] + carry) < 0)
                        {
                            buffer[buffer.Length - i] = (char)('0' +10+ temp);
                            carry = -1;
                        }
                        else
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp);
                            carry = 0;
                        }
                    }
                }

                if(carry== -1 && !isMinus)
                {
                    // left is smaller than right
                    return "-"+Minus(right,left);
                }
                if (isMinus)
                {
                    return "-" + new string(buffer);
                }
                else if (buffer[0] != '0')
                {
                    // left is bigger than right
                    return new string(buffer);
                }
                else
                {
                    return new string(buffer.Skip(1).ToArray());
                }
            }
            else
            {
                throw new Exception("Input is valid!");
            }
        }


        private static char[] Minus(char[] left, char[] right)
        {

                bool isMinus = false;

                char[] buffer;
                char[] smallNum;
                if (left.Length < right.Length)
                {
                    isMinus = true;
                    buffer = new char[right.Length];
                    right.CopyTo(buffer,0);
                    smallNum = new char[left.Length];
                    left.CopyTo(smallNum, 0);
                }
                else
                {
                    buffer = new char[left.Length];
                    left.CopyTo(buffer, 0);
                    smallNum = new char[right.Length];
                    right.CopyTo(smallNum, 0);
                }
                int carry = 0;
                int i;
                int temp;

                for (i = 1; i <= buffer.Length; i++)
                {
                    if (i > smallNum.Length)
                    {
                        if (carry == 0)
                        {
                            break;
                        }
                        else
                        {
                            if ((temp = buffer[buffer.Length - i] - 48 + carry) < 0)
                            {
                                buffer[buffer.Length - i] = (char)('0' + 10 + temp);
                                carry = -1;
                            }
                            else
                            {
                                buffer[buffer.Length - i] = (char)('0' + temp);
                                carry = 0;
                            }
                        }
                    }
                    else
                    {
                        if ((temp = buffer[buffer.Length - i] - smallNum[smallNum.Length - i] + carry) < 0)
                        {
                            buffer[buffer.Length - i] = (char)('0' + 10 + temp);
                            carry = -1;
                        }
                        else
                        {
                            buffer[buffer.Length - i] = (char)('0' + temp);
                            carry = 0;
                        }
                    }
                }

                if (carry == -1 && !isMinus)
                {
                    // left is smaller than right
                    char[] tempChar = Minus(right, left);
                    char[] result = new char[tempChar.Length + 1];
                    tempChar.CopyTo(result, 1);
                    result[0] = '-';
                    return result;
                }
                if (isMinus)
                {
                    char[] result = new char[buffer.Length + 1];
                    buffer.CopyTo(result, 1);
                    result[0] = '-';
                    return result;
                }
                else if (buffer[0] != '0')
                {
                    // left is bigger than right
                    return buffer;
                }
                else
                {
                    for (i = 1; i<buffer.Length;i++ )
                    {
                        if(buffer[i]!='0')
                        {
                            return buffer.Skip(i).ToArray();
                        }
                    }
                    return null;
                }
        }


        public static String Multiply(String left, String right)
        {
            if (IsValidInput(left, right))
            {
                char[] largeNum = left.Length > right.Length ? left.ToArray() : right.ToArray();
                char[] smallNum = left.Length > right.Length ? right.ToArray() : left.ToArray();
                char[] result = null;

                for (int i = smallNum.Length - 1; i >= 0; i--)
                {
                    if (result == null)
                    {
                        result = Multiply(largeNum, smallNum[i], smallNum.Length - 1 - i);
                    }
                    else
                    {
                        result = Plus(result, Multiply(largeNum, smallNum[i], smallNum.Length - 1 - i));
                    }
                }
                return new string(result);
            }
            else
            {
                throw new Exception("Input is valid!");
            }
        }

        private static char[] Multiply(char[] left, char right, int offset)
        {
            char[] temp = Multiply(left, right);
            if(offset ==0)
            {
                return temp;
            }
            char[] result = new char[temp.Length + offset];
            temp.CopyTo(result,0);
            int i;
            for (i = temp.Length; i < result.Length; i++ )
            {
                result[i] = '0';
            }
            return result;
        }

        private static char[] Multiply(char[] leftCopy, char right)
        {
            char[] left = new char[leftCopy.Length];
            leftCopy.CopyTo(left, 0);
            int carray = 0;
            int i;
            int temp = 0;
            int rightValue = right-48;

            for (i = left.Length - 1; i >= 0;i-- )
            {
                temp = (left[i] - '0') * rightValue + carray;
                carray = temp/10;
                left[i] =(char)('0'+ temp - carray * 10);
            }        
            if(carray>0)
            {
                char[] result;
                result = new char[left.Length + 1];
                result[0] = (char)('0' + carray);
                left.CopyTo(result, 1);
                return result;
            }
            return left;
        }


        public static  Pair<String,String> Divide(String left, String right)
        {
            if (IsValidInput(left, right))
            {
                Pair<char[], char[]> temp = Divide(left.ToArray(), right.ToArray());
                Pair<String, String> pair = new Pair<String, String>();
                pair.first = new string(temp.first);
                pair.second = new string(temp.second);
                return pair;
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }

        public static Pair<char[], char[]> Divide(char[] left, char[] right)
        {
            Pair<char[], char[]> pair = new Pair<char[], char[]>();
            char[] zero = new char[1];
            zero[0] = '0';
            if (left.Length < right.Length)
            {
                pair.first = zero;
                pair.second = left;
                return pair;
            }
            char[] leftArray = left.ToArray();
            char[] rightArray = right.ToArray();
            int temp;
            if ((temp = Compare(leftArray, rightArray)) == -1)
            {
                pair.first = zero;
                pair.second = left;
                return pair;
            }
            else if (temp == 0)
            {
                char[] one = new char[1];
                one[0] = '1';
                pair.first = one;
                pair.second = zero;
                return pair;
            }
            // left(32) > right(12)
            if (leftArray.Length == rightArray.Length)
            {
                pair = DivideParallel(leftArray, rightArray);
                return pair;
            }
            else      // left(324) > right(12)
            {
                Pair<char[], char[]> staticPair = new Pair<char[], char[]>();
                staticPair.first = zero;
                staticPair.second = zero;
                Pair<char[], char[]> tempPair;

                for (int i = left.Length - right.Length; i >=0; i--)
                {
                    rightArray = Multiply(right, '1', i);
                    tempPair = DivideParallel(leftArray, rightArray);
                    staticPair.first = Plus(staticPair.first, Multiply(tempPair.first, '1', i));
                    leftArray = tempPair.second;
                }
                staticPair.second = leftArray;
                return staticPair;
            }
        }

        protected static Pair<char[], char[]> DivideParallel(char[] left, char[] right)
        {

                Pair<char[], char[]> pair = new Pair<char[], char[]>();
                char[] zero = new char[1];
                 zero[0] = '0';
                 char[] one = new char[1];
                 one[0] = '1';
                 char[] variable = new char[1];
                 variable[0] = '0';
                 int temp = 0;
                if ((temp = Compare(left, right) )== -1)
                {
                    pair.first = zero;
                    pair.second = left;
                    return pair;
                }
                else if(temp==0)
                {
                    pair.first = one;
                    pair.second = zero;
                    return pair;
                }
            int leftFirstBit , rightFirstBit;
                if(left.Length==right.Length)        // left(32) > right(12)
                {
                    leftFirstBit = left[0] - '0';
                    rightFirstBit = right[0] - '0';
                }
               else      // left(121) > right(32)
                {
                    leftFirstBit = (left[0]-'0')*10+left[1]-'0';
                    rightFirstBit = right[0] - '0';
                }
                int factor = leftFirstBit / rightFirstBit;
                int i;
                char[] tempChar;

                if (factor == 1)
                {
                    pair.first = one;
                    pair.second = Minus(left, right);
                    return pair;
                }
                for (i = factor; i >= 1; i--)  // 二分查找也行  (condition: 32/19)
                {
                    if ((temp = Compare(left, tempChar = Multiply(right, (char)(i + '0')))) > 0)    // TODO: optimize this part
                    {
                        variable[0] = (char)('0' + i);
                        pair.first = variable;
                        pair.second = Minus(left, tempChar);
                        return pair;
                    }
                    else if (temp == 0)
                    {
                        variable[0] = (char)(i + '0');
                        pair.first = variable;
                        pair.second = zero;
                        return pair;
                    }
                }
                return null;
        }

        /* if left>right, return 1 else if left<right return -1 else return 0
         */
        protected static int Compare(char[] left, char[] right)
        {
            if(left.Length>right.Length)
            {
                return 1;
            }
            else if(left.Length<right.Length)
            {
                return -1;
            }
            else
            {
                for(int i=0;i<left.Length;i++)
                {
                    if(left[i]>right[i])
                    {
                        return 1;
                    }
                    else if(left[i]<right[i])
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        /**check if the two element inputs are valid
         */
        protected static bool IsValidInput(String input1,String input2)
        {
            if(IsValidNum(input1) && IsValidNum(input2))
            {
                return true;
            }
            return false;
        }
        /** check if input is a valid decimal number
         */
        protected static bool IsValidNum(String input)
        {
         
            if(input==null)
            {
                return false;
            }
            if (input.ElementAt(0) == '0')
               {
                   return false;
               }
            String pattern = @"\D";
            Regex regex = new Regex(pattern);

            if(regex.IsMatch(input))
            {
                return false;
            }
            return true;
        }

    }
}
