using System;
using System.Threading;
using System.Threading.Tasks;

namespace Home_Work_16_2
{
    internal class Program
    {
        static long summa;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            var one = long.Parse(Console.ReadLine());

            Console.Write("Введите второе число число: ");
            var two = long.Parse(Console.ReadLine());


            var firstTask = Task.Run(() =>
            {
                Interlocked.Add(ref summa, one);
                Thread.Sleep(rnd.Next(1500,2000));

            });
            var secondTask = Task.Run(() =>
            {
                Interlocked.Add(ref summa, two);
                Thread.Sleep(rnd.Next(1500, 2000));
            });


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Calculation");

            while (!firstTask.IsCompleted && !secondTask.IsCompleted)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Сумма: {summa}");
            



            Console.ReadKey();
        }
    }
}
