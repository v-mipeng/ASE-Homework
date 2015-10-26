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
                char[] buffer = left.Length > right.Length ? left.ToArray() : right.ToArray();
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
                if (carry == 0)
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

        /**This is plus valid method and will not change the field of left and right!
        */
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
                char[] result = new char[buffer.Length + 1];
                result[0] = '1';
                buffer.CopyTo(result, 1);
                return result;
            }

        }

        public static String Minus(String left, String right)
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
                    return "-" + Minus(right, left);
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

        /**This is a valid minus method and will not change the field of left and right!
         */
        private static char[] Minus(char[] left, char[] right)
        {

            bool isMinus = false;

            char[] buffer;
            char[] smallNum;
            if (left.Length < right.Length)
            {
                isMinus = true;
                buffer = new char[right.Length];
                right.CopyTo(buffer, 0);
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
                for (i = 1; i < buffer.Length; i++)
                {
                    if (buffer[i] != '0')
                    {
                        return buffer.Skip(i).ToArray();
                    }
                }
                return null;
            }
        }

        //         public static String Multiply(String left, String right)
        //         {
        //             if (IsValidInput(left, right))
        //             {
        //                 char[] largeNum = left.Length > right.Length ? left.ToArray() : right.ToArray();
        //                 char[] smallNum = left.Length > right.Length ? right.ToArray() : left.ToArray();
        //                 char[] result = null;
        // 
        //                 for (int i = smallNum.Length - 1; i >= 0; i--)
        //                 {
        //                     if (result == null)
        //                     {
        //                         result = Multiply(largeNum, smallNum[i], smallNum.Length - 1 - i);
        //                     }
        //                     else
        //                     {
        //                         result = Plus(result, Multiply(largeNum, smallNum[i], smallNum.Length - 1 - i));
        //                     }
        //                 }
        //                 return new string(result);
        //             }
        //             else
        //             {
        //                 throw new Exception("Input is valid!");
        //             }
        //         }
        public static String Multiply(string left, string right)
        {
            if (IsValidInput(left, right))
            {
                char[] array = Multiply(left.ToArray(), right.ToArray());
                return new string(array);
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }

        /**This is a valid minus method and will not change the field of left and right!
         */
//         public static char[] Multiply(char[] left, char[] right)
//         {
//             char[] largeNum = left.Length > right.Length ? left : right;
//             char[] smallNum = left.Length > right.Length ? right : left;
//             char[] result = new char[left.Length + right.Length];
//             result[0] = '0';
//             int largePoint = largeNum.Length;
//             int i, j, k, l;
//             int temp;
//             int value;
//             int carry = 0;
// 
//             largeNum.CopyTo(result, 1);
//             for (i = largeNum.Length + 1; i < result.Length; i++)
//             {
//                 result[i] = '0';
//             }
//             value = smallNum[0];
//             for (i = largePoint; i > 0; i--)
//             {
//                 if ((temp = (result[i] - '0') * (value - '0') + carry) >= 10)
//                 {
//                     result[i] = (char)('0' + temp % 10);
//                     carry = temp / 10;
//                 }
//                 else
//                 {
//                     result[i] = (char)('0' + temp);
//                     carry = 0;
//                 }
//             }
//             result[0] = (char)(result[0] + carry);
//             carry = 0;
//             // add
//             if (smallNum.Length > 1)
//             {
//                 largePoint++;
//                 for (i = 1; i < smallNum.Length; i++)
//                 {
//                     k = largePoint;
//                     for (j = largeNum.Length - 1; j >= 0; j--)
//                     {
// 
//                         if ((temp = (smallNum[i] - '0') * (largeNum[j] - '0') + (result[k] - '0') + carry) >= 10)
//                         {
//                             result[k] = (char)('0' + temp % 10);
//                             carry = temp / 10;
//                             l = k;
//                             while (carry > 0)
//                             {
//                                 l--;
//                                 if ((temp = result[l] - '0' + carry) >= 10)
//                                 {
//                                     result[l] = (char)(temp % 10 + '0');
//                                     carry = temp / 10;
//                                 }
//                                 else
//                                 {
//                                     result[l] = (char)(temp + '0');
//                                     carry = 0;
//                                 }
//                             }
//                         }
//                         else
//                         {
//                             result[k] = (char)(temp + '0');
//                             carry = 0;
//                         }
//                         k--;
//                     }
//                     largePoint++;
//                 }
//             }
//             return result;
//         }

         public static char[] Multiply(char[] left, char[] right)
        {
            char[] largeNum = left.Length > right.Length ? left : right;
            char[] smallNum = left.Length > right.Length ? right : left;
            if (smallNum.Length > 5000)
            {
                // choose n
                int n,i;
                for (i = smallNum.Length / 2; i < smallNum.Length; i++)
                {
                    if (smallNum[i] != '0')
                    {
                        break;
                    }
                }
                n = smallNum.Length - i - 1;
                // largeNum = A*10^n+B
                char[] A = new char[largeNum.Length - n];
                Copy(A, largeNum, 0, 0);
                char[] B = new char[n];
                Copy(B, largeNum, 0, largeNum.Length - n);
                // smallNum = C*10^n+D
                char[] C = new char[smallNum.Length - n];
                Copy(A, smallNum, 0, 0);
                char[] D = new char[n];
                Copy(B, smallNum, 0, smallNum.Length - n);
                // get AC
                char[] AC = Multiply(A, C);
                // get BD
                char[] BD = Multiply(B, D);
                // get (A-B)(D-C)
                bool positive = true;
                char[] A_B = Minus(A, B);
                char[] D_C = Minus(D, C);
                if (A_B[0] == '-')
                {
                    A_B = DeleteSign(A_B);
                    if (D_C[0] == '-')
                    {
                        D_C = DeleteSign(D_C);
                    }
                    else
                    {
                        positive = false;
                    }
                }
                else if (D_C[0] == '-')
                {
                    D_C = DeleteSign(D_C);
                    positive = false;
                }
                char[] A_BD_C = Multiply(A_B, D_C);
                // AC*10^2n+BD+((A-B)(D-C)+AC+BD)*10^n
                char[] temp;
                if (positive)
                {
                    temp = Plus(Plus(A_BD_C, AC), BD);
                }
                else
                {
                    temp = Minus(Plus(AC, BD), A_BD_C);
                }
                char[] result = Plus(Plus(ShiftLeft(AC, 2 * n), ShiftLeft(temp, n)), BD);
                return result;
            }
            else
            {

            }
        }


        private static char[] DeleteSign(char[] input)
         {
            if(input[0]=='-')
            {
                char[] array = new char[input.Length - 1];
                Copy(array, input, 0, 1);
                return array;
            }
            return input;
         }

         private static void Copy(char[] des, char[] source, int desBegin, int sourceBegin)
         {
            for (int i = sourceBegin, j=desBegin; i < source.Length && j<des.Length; i++,j++)
            {
                des[j] = source[i];
            }
         }

        private static char[] Multiply(char[] left, char right, int offset)
        {
            char[] temp = Multiply(left, right);
            if (offset == 0)
            {
                return temp;
            }
            char[] result = new char[temp.Length + offset];
            temp.CopyTo(result, 0);
            int i;
            for (i = temp.Length; i < result.Length; i++)
            {
                result[i] = '0';
            }
            return result;
        }


        /**This is a valid Multiply method and will not change the field of left and right!
        */
        private static char[] Multiply(char[] leftCopy, char right)
        {
            char[] left = new char[leftCopy.Length];
            leftCopy.CopyTo(left, 0);
            int carray = 0;
            int i;
            int temp = 0;
            int rightValue = right - 48;

            for (i = left.Length - 1; i >= 0; i--)
            {
                temp = (left[i] - '0') * rightValue + carray;
                carray = temp / 10;
                left[i] = (char)('0' + temp - carray * 10);
            }
            if (carray > 0)
            {
                char[] result;
                result = new char[left.Length + 1];
                result[0] = (char)('0' + carray);
                left.CopyTo(result, 1);
                return result;
            }
            return left;
        }


        private static char[] ShiftLeft(char[] bigInteger, int bitNums)
        {
            char[] array = new char[bigInteger.Length + bitNums];
            bigInteger.CopyTo(array, 0);
            for(int i=bigInteger.Length;i<array.Length;i++)
            {
                array[i] = '0';
            }
            return array;
        }
        
        /* if left>right, return 1 else if left<right return -1 else return 0
         */
        public static int Compare(char[] left, char[] right)
        {
            if (left.Length > right.Length)
            {
                return 1;
            }
            else if (left.Length < right.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < left.Length; i++)
                {
                    if (left[i] > right[i])
                    {
                        return 1;
                    }
                    else if (left[i] < right[i])
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        public static int Compare(List<char> left, List<char> right)
        {
            if (left.Count > right.Count)
            {
                return 1;
            }
            else if (left.Count < right.Count)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < left.Count; i++)
                {
                    if (left[i] > right[i])
                    {
                        return 1;
                    }
                    else if (left[i] < right[i])
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }


        /**check if the two element inputs are valid
         */
        public static bool IsValidInput(String input1, String input2)
        {
            if (IsValidNum(input1) && IsValidNum(input2))
            {
                return true;
            }
            return false;
        }
        /** check if input is a valid decimal number
         */
        public static bool IsValidNum(String input)
        {

            if (input == null)
            {
                return false;
            }
            if (input.ElementAt(0) == '0')
            {
                return false;
            }
            String pattern = @"\D";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                return false;
            }
            return true;
        }

    }
}
