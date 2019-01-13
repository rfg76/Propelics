using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropelicsTest
{
    
    class Program
    {

        //Q.1 Write a function that computes... 
        static string  Question1()
        {
            double lim = Math.Pow(10, 6);
            double sum = 0;

            for (double k = 1; k <= lim; k++)
            {
                double a  = Math.Pow(-1d, (k + 1));
                double b = (2 * k) - 1;  
                sum += (a / b);
            }

            sum = (4 * sum);

            return sum.ToString();
        }

        //Q.2 Write a function that receives an hour and a minute... and calculate the inner angle
        static string Question2(int hour, int minute)
        {
            const double degreesPerHour = (360 / 12);
            const double degreePerMin = (360 / 60);

            if (hour < 1 || hour > 12)
            {
                return "Hour must be a value between 1 - 12";
            }

            if (minute < 0 || minute > 59)
            {
                return "Minute must be a value between 0 - 59";
            }
            
            double degh = degreesPerHour * hour;
            double degm = degreePerMin * minute;

            double ang = degm - degh;

            if (ang < 0)
            {
                ang = degh - degm;
            }

            if (ang > 180)
            {
                ang = 360 - ang;
            }

            return ang.ToString();
        }

        //Q.3 Write a function that converts a given integer into a Roman Numeral
        static string Question3(int num)
        {

            if (num < 1 || num > 3999)
            {
                return "Parameter must be a value between 1 and 3999";
            }

            string res = "";

            int m = num / 1000;
            res += new String('M', m);
            num = num - (m * 1000);

            if (num >= 900)
            {
                res += "CM";
                num = num - 900;
            }

            int d = num / 500;
            res += new string('D', d);
            num = num - (d * 500);

            if (num >= 400)
            {
                res += "CD";
                num = num - 400;
            }

            int c = num / 100;
            res += new string('C', c);
            num = num - (c * 100);

            if (num >= 90)
            {
                res += "XC";
                num = num - 90;
            }

            int l = num / 50;
            res += new string('L', l);
            num = num - (l * 50);

            if (num >= 40)
            {
                res += "XL";
                num = num - 40;
            }
            
            int x = num / 10;
            res += new string('X', x);
            num = num - (x * 10);

            if (num == 9)
            {
                res += "IX";
                num = num - 9;
            }

            int v = num / 5;
            res += new string('V', v);
            num = num - (v * 5);

            if (num == 4)
            {
                res += "IV";
                num = num - 4;
            }

            int i = num;
            res += new string('I', i);

            return res;
        }

        //Q.4 Write a function, that given two strings, test wether one is an anagram of the other
        static string Question4(string str1, string str2)
        {

            str1 = str1.Replace(" ", string.Empty);
            str2 = str2.Replace(" ", string.Empty);

            str1 = str1.ToLower();
            str2 = str2.ToLower();

            if (str1.Length != str2.Length)
            {
                return "NO";
            }

            var dic1 = new Dictionary<char, int>();
            foreach (char c in str1)
            {
                int n = 0;
                if (!dic1.TryGetValue(c, out n))
                {
                    dic1.Add(c, 1);
                }
                else
                {
                    dic1[c]++;
                }
            }

            var dic2 = new Dictionary<char, int>();
            foreach (char c in str2)
            {
                int n = 0;
                if (!dic2.TryGetValue(c, out n))
                {
                    dic2.Add(c, 1);
                }
                else
                {
                    dic2[c]++;
                }
            }

            foreach (var pair in dic1)
            {
                int val = 0;
                if (!dic2.TryGetValue(pair.Key, out val))
                {
                    return "NO";
                }
                if (pair.Value != val)
                {
                    return "NO";
                }

            }

            return "YES";
        }

        // Q.5 Write a function that performs basic string compression...
        static string Question5(string str)
        {
            string compressed = "";

            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int n = 1;

                for (int j = i + 1; j < str.Length; j++)
                {
                    char r = str[j];
                    if (c == r)
                    {
                        n++;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
                compressed += $"{c}{n}";
            }

            if (compressed.Length > str.Length)
            {
                return str;
            }

            return compressed;
        }

        // Q.6 Write a function that reverses a string...
        static string Question6(string str)
        {
            StringBuilder reversed = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversed.Append(str[i]);
            }

            return (reversed.ToString());
        }


        static int[,] SetZeros(int row, int col, int m, int n, int[,] arr)
        {
            for (int i = 0; i <= n; i++)
            {
                arr[row, i] = 0;
            }

            for (int i = 0; i <= m; i++)
            {
                arr[i, col] = 0;
            }

            return arr;
        }

        static string ArrToString(int[,] arr)
        {
            int m = arr.GetUpperBound(0);
            int n = arr.GetUpperBound(1);

            StringBuilder output = new StringBuilder("[\n");
            for (int i = 0; i <= m; i++)
            {
                output.Append("\t[");

                for (int j = 0; j <= n; j++)
                {
                    output.Append($"{arr[i, j]}, ");
                }
                output.Remove(output.Length - 2, 2);
                output.Append("]\n");
            }
            output.Append("]\n");

            return output.ToString();
        }

        //Q.7 Write a function such that if an element in an MxN matrix is 0...
        static string Question7(int[,] arr)
        {
            int m = arr.GetUpperBound(0);
            int n = arr.GetUpperBound(1);

            var coord = new List<int[]>();

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        coord.Add(new int[] {i, j} );

                    }
                }
            }

            foreach (var c in coord)
            {
                arr = SetZeros(c[0], c[1], m, n, arr);
            }

            return (ArrToString(arr));
        }

        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type Question Number [1-7]. Q to Exit");
                string input = Console.ReadLine();
                Console.WriteLine();

                string answer = "";
                string value = "";
                if (input.ToLower() == "q")
                {
                    break;
                }

                switch (input)
                {
                    case "1":
                        answer = Question1();
                        break;

                    case "2":
                        Console.WriteLine("Enter Hour [1 - 12]:");
                        value = Console.ReadLine();
                        int hour;
                        if (!int.TryParse(value, out hour))
                        {
                            Console.WriteLine("Hour must be an integer value.");
                            break;
                        }

                        Console.WriteLine("Enter Minute [0- 59]:");
                        value = Console.ReadLine();
                        int minute;
                        if (!int.TryParse(value, out minute))
                        {
                            Console.WriteLine("Minute must be an integer value.");
                            break;
                        }

                        answer = Question2(hour, minute);
                        break;

                    case "3":
                        Console.WriteLine("Enter Value to convert [1 - 3999]:");
                        value = Console.ReadLine();
                        int num;
                        if (!int.TryParse(value, out num))
                        {
                            Console.WriteLine("Parameter must be an integer value.");
                            break;
                        }

                        answer = Question3(num);
                        break;

                    case "4":
                        Console.WriteLine("Enter string 1:");
                        string str1 = Console.ReadLine();

                        Console.WriteLine("Enter string 2:");
                        string str2 = Console.ReadLine();

                        answer = Question4(str1, str2);
                        break;

                    case "5":
                        Console.WriteLine("Enter string to compress:");
                        string comp = Console.ReadLine();

                        answer = Question5(comp);
                        break;

                    case "6":
                        Console.WriteLine("Enter string to reverse:");
                        string rev = Console.ReadLine();

                        answer = Question6(rev);
                        break;

                    case "7":
                        
                        int[,] arr = new int[,] { { 0, 2, 3}, {4, 5, 6}, {7, 8, 9} };

                        Console.WriteLine($"INPUT\n{ArrToString(arr)}");

                        answer = Question7(arr);

                        break;

                    default:
                        continue;
                }

                Console.WriteLine($"Answer is: {answer}");
                Console.ReadKey(true);
            }

        }
    }
}
