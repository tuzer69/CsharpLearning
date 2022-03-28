using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork
{
    public partial class Program
    {
        public static Random rnd = new Random();

        public static void Main(string[] args)
        {
            var myshed = new MySheduler();
            Task[] tasks = new Task[10];

            Console.SetWindowSize(120,30);
            Console.WriteLine($"ID потока метода Main {Thread.CurrentThread.ManagedThreadId}");

            TaskTesting(tasks, myshed);
            
            try
            {
                Task.WaitAll(tasks);
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Несколько задач были отменены!");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine($"Метод Main закончил свое выполнение");
            }
            
            Console.ReadKey();

        }

        private static void TaskTesting(Task[] tasks, TaskScheduler scheduler)
        {

            for (int i = 0; i < tasks.Length; i++)
            {

                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(rnd.Next(2000, 6000));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Задача {Task.CurrentId} выполнилась в потоке {Thread.CurrentThread.ManagedThreadId}\n");
                    Console.ResetColor();

                });

                tasks[i].Start(scheduler);
            }
        }
    }
}


