using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабараторна_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вибір задачі
            Console.WriteLine("Введіть номер задачі:");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                goto First;
            }
            else if (number == 2)
            {
                goto Second;
            }
            else
            {
                throw new InvalidProgramException("Invalid input.");
            }

            First:
            // Task 4.3.2
            Service.Task1("0110", "1101", 2);

            Second:
            // Task 4.3.3
            Service.Task2("0110", 4, 2);
        }
    }

    static class Service
    {
        static List<string> weightOfCombinations;

        public static void Task1(string a, string b, int d)
        {
            Console.WriteLine($"4.3.2\n    A+B={CalculateSum(a, b)},\n    w = {CalculateSum(a, b).Where(x => x == '1').Count()}");
            var combinations = GenerateCombinationsWithDistance(a, d);
            Console.WriteLine($"Number of combinations = {combinations.Length}\nCombinations: {string.Join(" ", combinations)}");
        }

        public static void Task2(string a, int n, int d)
        {
            string[] combinations_ = GenerateCombinationsWithDistance(a, d);
            Console.WriteLine($"4.3.3\nNumber of combinations = {combinations_.Length}\nCombinations: {string.Join(" ", combinations_)}");
        }

        static string CalculateSum(string A, string B)
        {
            string C = "";
            for (int i = 0; i < A.Length; i++)
            {
                C += A[i] == B[i] ? '0' : '1';
            }
            return C;
        }

        static string[] GenerateCombinationsWithDistance(string code, int distance)
        {
            var n = code.Length;
            weightOfCombinations = new List<string>();
            GenerateCombinations(n, distance);
            return weightOfCombinations.Select(s => CalculateSum(s, code)).ToArray();
        }

        static void GenerateCombinations(int length, int weight, int position = 1, string code = "")
        {
            var count = length - code.Length;
            for (int i = 0; i < count; i++)
            {
                if (position == weight)
                {
                    weightOfCombinations.Add(code + "1" + string.Join("", Enumerable.Range(0, length - code.Length - 1).Select(x => "0")));
                }
                else
                {
                    GenerateCombinations(length, weight, position + 1, code + "1");
                }
                code += "0";
            }
        }
    }
}
