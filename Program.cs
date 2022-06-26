using System;

namespace TestHackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            string s = Console.ReadLine();

            string result = highestValuePalindrome(s, n, k);

            Console.WriteLine(result);
        }
        public static string highestValuePalindrome(string s, int n, int k)
        {
            // Creating array of string length 
            char[] ch = new char[n];
            int i, mode, devide;

            // Copy character by character into array 
            for (i = 0; i < n; i++)
            {
                ch[i] = s[i];
            }


            devide = n / 2;
            mode = n % 2;

            // Character changes according to the algorithm
            ch = MakeChanges(ch, n, k, devide, mode);
            // Compare string characters that are equal according to the algorithm or not
            var status = CompareString(ch, n, devide, mode);
            return status;
        }
        public static char[] MakeChanges(char[] ch, int n, int k, int devide, int mode)
        {
            int i, j, index;
            i = 0;
            j = n - 1;
            index = 0;

            while (i < devide)
            {
                if (ch[i] != ch[j])
                {
                    if (index < k)
                    {
                        if (ch[i] == '9')
                        {
                            ch[j] = '9';
                            index++;
                        }
                        else if (ch[j] == '9')
                        {
                            ch[i] = '9';
                            index++;
                        }
                        else
                        {
                            ch[i] = '9';
                            index++;
                            if (index < k)
                            {
                                ch[j] = '9';
                                index++;
                            }
                            else
                                break;
                        }
                    }
                }
                i++;
                j--;
            }
            if (mode != 0)
            {
                if (ch[devide] != 9)
                    if (index < k)
                    {
                        ch[devide] = '9';
                        index++;
                    }
            }
            return ch;
        }
        public static string CompareString(char[] ch, int n, int devide, int mode)
        {
            int i = 0;
            int j = n - 1;
            int status = 1;

            while (i < devide)
            {
                if (ch[i] != ch[j])
                {
                    status = 0;
                    break;
                }
                i++;
                j--;
            }
            if (mode != 0)
            {
                if (ch[devide] != 9)
                    return "-1";
            }

            if (status == 0)
                return "-1";
            else
            {
                string s = "";
                for (int l = 0; l < n; l++)
                {
                    s = s + ch[l];
                }
                s = s.Trim();
                return s;
            }
        }

    }
}



