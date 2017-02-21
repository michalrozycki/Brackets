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
            if (input.Length % 2 != 0)
            {
                return "impossible";
            }

            // '(' = true, ')' = false
            bool[] inputBool = new bool[input.Length];
            for (var i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] == '(')
                {
                    inputBool[i] = true;
                }
                else
                {
                    inputBool[i] = false;
                }
            }

            if (isValid(inputBool))
            {
                return "possible";
            }

            // One block
            var incorrectRage = split(inputBool);
            if (incorrectRage.Count == 1)
            {
                var sub = new bool[incorrectRage[0][1] - incorrectRage[0][0] + 1];
                Array.Copy(inputBool, incorrectRage[0][0], sub, 0, sub.Length);
                if (search(sub))
                {
                    return "possible";
                }
            }

            // All bloks
            //var incorrectRage = split(inputBool);
            //var poss = true;
            //foreach (var e in incorrectRage)
            //{
            //    var sub = new bool[e[1] - e[0] + 1];
            //    Array.Copy(inputBool, e[0], sub, 0, sub.Length);
            //    if (!search(sub))
            //    {
            //        poss = false;
            //    }
            //}
            //if (poss)
            //{
            //    return "possible";
            //}

            // Broute force
            if (search(inputBool))
            {
                return "possible";
            }

            return "impossible";
        }

        public static List<int[]> split(bool[] input)
        {
            var correctRages = new List<int[]>();
            var count = 0;
            var begin = 0;
            for (var i = 0; i <= input.Length - 1; i++)
            {
                if (input[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    var sub = new bool[i - begin + 1];
                    Array.Copy(input, begin, sub, 0, sub.Length);
                    if (isValid(sub))
                    {
                        int[] rage = { begin, i };
                        correctRages.Add(rage);
                    }
                    begin = i + 1;
                }
            }
            var incorrectBrackets = new List<int>();
            for (var i = 0; i <= input.Length - 1; i++)
            {
                if (!isContain(correctRages, i))
                {
                    incorrectBrackets.Add(i);
                }
            }
            var incorrectRages = new List<int[]>();
            var start = 0;
            // 0123..
            // 3458
            // 0569
            for (var i = 0; i <= incorrectBrackets.Count - 1; i++)
            {
                if ((i == 0) || (incorrectBrackets[i - 1] != incorrectBrackets[i] - 1))
                {
                    start = incorrectBrackets[i];
                }
                if ((i == incorrectBrackets.Count - 1) || (incorrectBrackets[i + 1] != incorrectBrackets[i] + 1))
                {
                    int[] rage = { start, incorrectBrackets[i] };
                    incorrectRages.Add(rage);
                }
            }
            return incorrectRages;
        }

        public static bool isContain(List<int[]> list, int index)
        {
            foreach (var e in list)
            {
                if (e[0] <= index && e[1] >= index)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool search(bool[] input)
        {
            for (var i = 0; i <= input.Length - 1; i++)
            {
                for (var j = input.Length - 1; j >= 0; j--)
                {
                    var sub = new bool[input.Length];
                    Array.Copy(input, 0, sub, 0, sub.Length);
                    var swapResult = swap(sub, i, j);
                    if (isValid(swapResult))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool[] swap(bool[] input, int left, int right)
        {
            for (var i = left; i <= right; i++)
            {
                if (input[i])
                {
                    input[i] = false;
                }
                else
                {
                    input[i] = true;
                }
            }
            return input;
        }

        public static bool isValid(bool[] input)
        {
            var count = 0;
            foreach (var ch in input)
            {
                if (ch)
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count < 0) return false;
            }

            if (count == 0)
            {
                return true;
            }
            return false;
        }
    }
}