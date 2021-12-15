using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практична_4
{
    class Program
    {
        static int countOfSymbols;
        static Dictionary<string, double> dictionary;
        static Dictionary<string, string> combination = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Coding by the method of unique codes.");
            countOfSymbols = 1;
            dictionary = new Dictionary<string, double> {{ "A", 0.15 }, { "B", 0.63 }, { "C", 0.05 }, { "D", 0.17 }};
            PrintResultsToConsole();
            Console.ReadKey();
        }

        public static void PrintResultsToConsole()
        {
            combination = dictionary.ToDictionary(x => x.Key, y => "");
            Dictionary<string, string> generatedCode = GenerateCode();

            Console.WriteLine(string.Join("\n", generatedCode.Select(x => $"symbol: {x.Key} with code: {x.Value}")));

            var entropia = GetEntropia();
            var average = GetAverageNumberLength();
            Console.WriteLine($"Entropy  = {entropia}\nAverage = {average}\nCode efficiency  = {Math.Abs(average - entropia) / average * 100}");
        }

        static Dictionary<string, string> GenerateCode()
        {
            var sorted = dictionary.OrderBy(x => -x.Value).Select(x => x.Key).ToList();
            SplitArrayAndTypeCode(sorted);
            return combination;
        }

        static void SplitArrayAndTypeCode(List<string> list)
        {
            if (list.Count <= 1) return;

            int divide_in = 1;
            double delta = -1;
            for (int i = 1; i < list.Count; i++)
            {
                double sum_first_part = 0, sum_second_part = 0;
                for (int j = 0; j < i; j++) sum_first_part += dictionary[list[j]];
                for (int j = i; j < list.Count; j++) sum_second_part += dictionary[list[j]];

                var new_delta = Math.Abs(sum_first_part - sum_second_part);
                if (new_delta == 0 || i == list.Count - 1)
                {
                    divide_in = i;
                    break;
                }
                if (delta != -1 && new_delta > delta)
                {
                    divide_in = i - 1;
                    break;
                }
                delta = new_delta;
            }

            var list_1 = list.Take(divide_in).ToList();
            var list_2 = list.Skip(divide_in).ToList();

            list_1.ForEach(x => combination[x] += "1");
            list_2.ForEach(x => combination[x] += "0");

            SplitArrayAndTypeCode(list_1);
            SplitArrayAndTypeCode(list_2);
        }

        static double GetEntropia()
        {
            return dictionary.Select(x => -1 * x.Value * Math.Log(x.Value, 2)).Sum();
        }

        static double GetAverageNumberLength()
        {
            return dictionary.Select(x => x.Value * combination[x.Key].Length).Sum() / countOfSymbols;
        }
    }
}
