using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабараторна_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'T' to start transition mode,\nPress 'E' to close app.");

            int timer = 1;
            bool flag = true;
            Service service = new Service();

            service.ChangeState += (Value value) => Console.WriteLine($"State: {value} Time: {timer++}");
            service.StartProgram();

            while (flag)
            {
                ConsoleKey button = Console.ReadKey(true).Key;
                if (button == ConsoleKey.T)
                {
                    service.AllowCrossOver();
                }
                else if (button == ConsoleKey.E)
                {
                    flag = false;
                    service.StopProgram();
                }
            }
        }
    }
}
