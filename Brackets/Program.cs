using System;
using System.Collections.Generic;

namespace Brackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string line;
            List<string> lines = new List<string>();
            while ((line = Console.ReadLine()) != null) lines.Add(line);
            input = lines[0];

            Console.WriteLine(steps(input));
        }

        public static string steps(string input)
        {
            //input = "()()";

            if (input.Length == 0)
            {
                return "possible";
            }

            int[] reverseStart = new int[input.Length + 1];
            int start = 0;
            var charArray = input.ToCharArray();
            for (int a = input.Length - 1; a >= 0; a--)
            {
                if (charArray[a] == '(')
                {
                    start -= 1;
                }
                else
                {
                    start += 1;
                }
                if (start < 0)
                {
                    start = int.MaxValue / 2;
                }
                reverseStart[a] = start;
            }

            for (int startFlip = 0; startFlip < input.Length; startFlip++)
            {
                int st = 0;
                for (int a = 0; a < startFlip; a++)
                {
                    st += charArray[a] == '(' ? 1 : -1;
                    if (st < 0)
                    {
                        st = int.MinValue / 2;
                    }
                }
                for (int b = startFlip; b < input.Length; b++)
                {
                    if (st == reverseStart[b])
                    {
                        return "possible";
                    }
                    st += charArray[b] == ')' ? 1 : -1;
                    if (st < 0)
                    {
                        st = int.MinValue / 2;
                    }
                    if (st == reverseStart[b + 1])
                    {
                        return "possible";
                    }
                }
            }
            return "impossible";
        }
    }
}