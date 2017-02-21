using System;
using System.Collections.Generic;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input ="";
            //input = "(()())"; //possible
            // input = ")))("; //impossible
            //input = "()))"; //possible
            //input = "()()()())()()()())"; //possible
            //input = "(())"; //p
            //input = "()()"; // p
            //input = "(()())()";// p
            //input = "(";// i
            // input = "())";// i
            //input = "";//p
            //input = "())("; //p
            //input = "()))"; //p
            //input = ")))("; //i
            ///input = ")))))(((((()()()(())";
            //input = "(((()()())()(((()()())()(((()()()))))((()()())))(((()()())))(((()()()))(";
            //var r = new Random();
            //for (var i = 0; i < 5000; i++)
            //{
            //   input += (r.Next() <.5) ? '(' : ')';
            //}

            string line;
            List<string> lines = new List<string>();
            while ((line = Console.ReadLine()) != null) lines.Add(line);
            input = lines[0];

            if (isValid(input))
            {
                Console.WriteLine("possible");
                return;
            }
            
            //var incorrectRage = split("(()))(()(");
            var incorrectRage = split(input);
            //if (incorrectRage.Count == 1)
            //{
            //    var sub = input.Substring(incorrectRage[0][0], incorrectRage[0][1] - incorrectRage[0][0] +1);
            //    if (search(sub))
            //    {
            //        Console.WriteLine("possible");
            //        return;
            //    }
            //}

            var poss = true;
            foreach (var e in incorrectRage)
            {
                var sub = input.Substring(e[0], e[1] - e[0] + 1);
                if (!search(sub))
                {
                    poss = false;
                }
            }
            if (poss)
            {
                Console.WriteLine("possible");
                return;
            }


           // if  (incorrectRage.Count>1)
           // {
            //    Console.WriteLine("impossible");
            //}

           // return;
           //if (input.Length >1000 && incorrectRage.Count>1)
           // {
           //     Console.WriteLine("impossible");
           //     return;
           // }

           // if (search(input))
           // {
           //     Console.WriteLine("possible");
           // }
           // else
         //   {
                Console.WriteLine("impossible");
           // }
            // Console.ReadLine();
        }

        public static List<int[]> split (string input)
        {
            var correctRages = new List<int[]>();
            var count = 0;
            var begin = 0;
            for (var i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] == '(')
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    var sub = input.Substring(begin, i - begin +1);
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
                if ((i == incorrectBrackets.Count-1) || (incorrectBrackets[i + 1] != incorrectBrackets[i] + 1))
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
                if (e[0]<=index && e[1] >=index)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool search(string input)
        {
            for (var i = 0; i <= input.Length - 1; i++)
            {
                for (var j = input.Length - 1; j >= 0; j--)
                {
                    var swapResult = swap(input, i, j);
                    if (isValid(swapResult))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string swap(string input, int left, int right)
        {
            var chars = input.ToCharArray();

            for (var i = left; i <= right; i++)
            {
                if (chars[i] == '(')
                {
                    chars[i] = ')';
                } 
                else
                {
                    chars[i] = '(';
                }
            }
            return new string(chars);
        }

        public static bool isValid(string input)
        {
            var chars = input.ToCharArray();
            var count = 0;
            foreach (var ch in chars)
            {
                if (ch == '(')
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