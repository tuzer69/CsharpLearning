using System;
using System.Security.Cryptography.X509Certificates;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================  Введите текст:  ============================");
            string text = TextUtils.ClearString(Console.ReadLine());
            Console.WriteLine("====================  Текст после очистки  =========================");
            Console.WriteLine($"{text}");

            Console.ReadKey();

        }
    }
}
