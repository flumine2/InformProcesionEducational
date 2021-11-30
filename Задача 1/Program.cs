using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практична_2
{
    //Для будь якого джерела симетричного в послабленому значенні
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
            //Заповнення матриці
            double[,] matrix = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введіть {i + 1} рядок імовірностей");
                double[] line = Console.ReadLine().Split().Select(double.Parse).ToArray();
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            //Введення швидкості передачі символів
            Console.WriteLine("Введіть швидкість передачі символів (одне ціле число)");
            int broadcastSpeedOfSymbol = int.Parse(Console.ReadLine());

            //Знайдемо p(x) i p(y)
            double[] px = new double[3];
            for (int i = 0; i < 3; i++)
            {
                px[i] = matrix[0, i] + matrix[1, i] + matrix[2, i];
            }
            double[] py = new double[3];
            for (int i = 0; i < 3; i++)
            {
                py[i] = matrix[i, 0] + matrix[i, 1] + matrix[i, 2];
            }

            //Обрахування середньої кількісті інформації, яка передається одним символом
            double averageInfosQuantity = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    averageInfosQuantity += matrix[i, j] * Math.Log(matrix[i, j] / (px[i] * py[j]), 2);
                }
            }

            //Обрахування швидкості передачі інформації
            double broadcastSpeedOfInformation = averageInfosQuantity * broadcastSpeedOfSymbol;

            //Обрахування умовних імовірностей
            double[,] matrixСonditional = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixСonditional[i, j] = matrix[i, j] / px[i];
                }
            }

            //Обрахування пропускної здатності джерела
            double C;
            double sum = Math.Log(3, 2);
            for (int i = 0; i < 3; i++)
            {
                sum += matrixСonditional[i, 0] * Math.Log(matrixСonditional[i, 0], 2);
            }
            C = broadcastSpeedOfSymbol * sum;

            //Виведення
            Console.WriteLine();
            Console.WriteLine("Середня кількість інформації, яка передається одним символом: {0}", averageInfosQuantity);
            Console.WriteLine("Швидкість передачі інформації: {0}", broadcastSpeedOfInformation);
            Console.WriteLine("Пропускна здатність каналу: {0}", C);

            Second:

        }
    }
}
