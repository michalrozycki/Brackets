using System;
using System.Collections.Generic;

namespace Abc
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<string> lines = new List<string>();
            while ((line = Console.ReadLine()) != null)
            {
                lines.Add(line);
            }
            Console.WriteLine(solve(lines[0], lines[1]));
        }

        public static string solve(string lineFirst, string lineSecond)
        {
            List<int> arr = new List<int>();
            List<string> lines = new List<string>();
            string letters = "";

            string[] split = lineFirst.Split(new char[] { ' ' }, StringSplitOptions.None);
            arr.Add(int.Parse(split[0]));
            arr.Add(int.Parse(split[1]));
            arr.Add(int.Parse(split[2]));

            string[] split1 = lineSecond.Split(new char[] { ' ' }, StringSplitOptions.None);
            letters = split1[0];

            var result = new List<int>();
            arr.Sort();

            analise(letters[0], result, arr);
            analise(letters[1], result, arr);
            analise(letters[2], result, arr);

            string r = string.Empty;
            foreach (var i in result)
            {
                r += i + " ";
            }

            return r.TrimEnd();
        }

        public static void analise(char ch, List<int> result, List<int> arr)
        {
            if (ch == 'A')
            {
                result.Add(arr[0]);
            }
            if (ch == 'B')
            {
                result.Add(arr[1]);
            }
            if (ch == 'C')
            {
                result.Add(arr[2]);
            }
        }
    }
}