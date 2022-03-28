using System;


namespace HW_4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine($"{"Номер месяца", 15}{"Доход", 20}{"Расход",20}{"Прибыль",20}");
            Console.WriteLine("********************************************************************************");
            int[,] finOrder = new int[12, 4]; //Создание массива для данных
            //В цикле заполняем массив, случайными числами.
            for (int i = 0; i < finOrder.GetLength(0); i++)
            {
                finOrder[i, 0] = i + 1;
                finOrder[i, 1] = rand.Next(80, 130) * 1000;
                finOrder[i, 2] = rand.Next(55, 100) * 1000;
                finOrder[i, 3] = finOrder[i, 1] - finOrder[i, 2];
                Console.WriteLine($"{finOrder[i, 0], 15}" +         //Месяцы
                                  $"{finOrder[i, 1], 20:### ###}" + //Доход
                                  $"{finOrder[i, 2], 20:### ###}" +  //Расход
                                  $"{finOrder[i, 3], 20:### ###}");  //Прибль
            }
            Console.WriteLine("********************  Месяцы с наимельшей прибылью   **********************");
            int[] sortMonth = new int[12]; //Первая копия, с доходом которая будет отсортирована
            int[] unsortMonth = new int[12]; //Вторая копия которая хранит доход и НЕ будет отсортирован.
            ushort plusMonth = 0;
            //Цикл для заполнения двух переменных типа массив
            for (int i = 0; i < finOrder.GetLength(0); i++) 
            {
                sortMonth[i] = finOrder[i, 3];
                unsortMonth[i] = finOrder[i, 3];
                if (finOrder[i, 3] >= 0) plusMonth++; //Считаем количество месяцев с положительной прибылью
            }
            Array.Sort(sortMonth); //Сортировка первого массива, который предназначен для поиска минимальных заначений
            
            //Переменная просто хранит текущую позицию ОТСОРТИРОВАННОМ sortMonth массиве. В каждом цикле увеличивается на единицу
            ushort currentIndex = 0;

            //Цикл по выводу информации по наихудшим месяцам. По умолчании устновлено три итерации. Можно легко увелицить
            for (int i = 0; i < 3; i++)
            {
                //Индексная переменная для хранения текущей позиции в НЕ отсортированном массиве
                int index = Array.IndexOf(unsortMonth, sortMonth[currentIndex]);
                Console.Write("Месяц: ");

                while (index != -1)
                {
                    Console.Write($"({index + 1})");
                    index = Array.IndexOf(unsortMonth, sortMonth[currentIndex], index + 1);
                    currentIndex += 1;
                }
                Console.WriteLine($": {sortMonth[currentIndex - 1]}");
            }
           
            Console.WriteLine();
            Console.WriteLine($"Общее количество месяцов с пложительной прибылью: {plusMonth}");


            Console.ReadKey();
        }
    }
}
