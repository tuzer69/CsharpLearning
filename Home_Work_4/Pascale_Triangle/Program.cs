using System;
using System.Globalization;

namespace Pascale_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************** Введите желаемое количество строк: ********************");
            ushort numStrings; //Переменная хранит количество строк, которые ввел пользователь
            while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any, //Цикл на проверку корректности ввода.
                CultureInfo.InvariantCulture,out numStrings) || (numStrings < 5 || numStrings > 20))
            {
                Console.WriteLine("Количество строк должно быть от 5 до 20:");
            }

            Console.Clear(); //Чистим экран и выводим наш треугольник

            //Цикл отрисовки треугольника
            for (int i = 0; i < numStrings; i++)
            {
                //Цикл для создания пробелов от левой стороны каждой строки
                for (int j = 0; j <= (numStrings - i); j++)
                {
                    Console.Write("   ");
                }
                //Цикл рисования строки при помощи функии факторала
                for (int j = 0; j <= i; j++) 
                {
                    //Переменная хранит число которое вводим на экран
                    int fact = Convert.ToInt32((Factorial(i) / (Factorial(j) * Factorial(i - j))));
                    //Вывод на экран в зависимости от длинны числа
                    if (fact < 9) Console.Write("      ");
                    else if (fact < 100) Console.Write("     ");
                    else if (fact < 1000) Console.Write("    ");
                    else if (fact < 10000) Console.Write("   ");
                    else if (fact < 100000) Console.Write("  ");
                    Console.Write(fact);

                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Функция факториала для отрисовки треугольника
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static float Factorial(int n)
        {
            float x = 1;
            for (int i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }
    }
}
