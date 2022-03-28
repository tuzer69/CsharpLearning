using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================  Введите текст =================================");
            string text = Console.ReadLine();
            Console.WriteLine("========================  Слово с мин. длинной: ===========================");
            Console.WriteLine($"{StringUtils.MinStr(text)}");
            Console.WriteLine();
            Console.WriteLine("========================  Слова с макс. длинной ===========================");
            string[] TextMax = StringUtils.MaxStr(text);
            for (int i = 0; i < TextMax.Length; i++)
            {
                Console.WriteLine($"{TextMax[i]}");
            }

            Console.ReadKey();
        }
    }
}
