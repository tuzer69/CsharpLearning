using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************Умножения матрицы на число****************");

            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine()); //Записываем число от пользователя в переменную
            Random rand = new Random(); //Генератор СЛЧ для заполненения матриц
            int[,] matrixOne = new int[3, 3]; //Хранит первую матрицу
            int[,] matrixTwo = new int[3, 3]; //Хранит вторую матрицу
            int[,] interMatrix = new int[3, 3]; //Промежуточная матрица используется для хранения результата

            Console.WriteLine("Первая матрица: ");
            //Заполняем в цикле первую матрицу случайными числами в диапазоне от 1 до 9
            for (int i = 0; i < matrixOne.GetLength(0); i++) 
            {
                for (int j = 0; j < matrixOne.GetLength(1); j++)
                {
                    matrixOne[i, j] = rand.Next(1, 10);
                    Console.Write(matrixOne[i, j]);
                    Console.Write("  ");
                }

                Console.WriteLine();
                
            }

            //Цикл номножает и выводит результат умножения матрицы на число
            Console.WriteLine($"Результат умножения первой на число {number}:");
            for (int i = 0; i < matrixOne.GetLength(0); i++) //Заполняем в цикле первую матрицу
            {
                for (int j = 0; j < matrixOne.GetLength(1); j++)
                {
                    interMatrix[i, j] = matrixOne[i, j] * number;
                    Console.Write(interMatrix[i, j]);
                    Console.Write("  ");
                }

                Console.WriteLine();

            }

            Console.WriteLine("**************** Cложение двух матриц ******************");
            Console.WriteLine("Вторая матрица: ");
            //В цикле заполняем вторую матрицу случ. значениями от 1 до 9
            for (int i = 0; i < matrixTwo.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTwo.GetLength(1); j++)
                {
                    matrixTwo[i, j] = rand.Next(1, 10);
                    Console.Write(matrixTwo[i, j]);
                    Console.Write("  ");
                }

                Console.WriteLine();

            }
            Console.WriteLine("Результат сложения двух матриц:");
            //В цикле складываем первую и вторую марицы и выводим на экран
            for (int i = 0; i < interMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < interMatrix.GetLength(1); j++)
                {
                    interMatrix[i, j] = matrixOne[i, j] + matrixTwo[i, j];
                    Console.Write(interMatrix[i, j]);
                    Console.Write("  ");
                }

                Console.WriteLine();

            }

            Console.WriteLine("**************** Вычитание двух матриц ******************");
            Console.WriteLine("Результат вычитания двух матриц:");
            //В цикле вычитаем первую и вторую марицы и выводим на экран
            for (int i = 0; i < interMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < interMatrix.GetLength(1); j++)
                {
                    interMatrix[i, j] = matrixOne[i, j] - matrixTwo[i, j];
                    Console.Write(interMatrix[i, j]);
                    Console.Write("  ");
                }

                Console.WriteLine();

            }

            Console.WriteLine("**************** Умножения двух матриц ******************");
            Console.WriteLine("Результат умножения двух матриц:");
            for (int k = 0; k < interMatrix.GetLength(0); k++)
            {
                for (int j = 0; j < interMatrix.GetLength(0); j++)
                {
                    interMatrix[k, j] = 0;
                    for (int i = 0; i < interMatrix.GetLength(1); i++)
                    {
                        interMatrix[k, j] += matrixOne[k, i] * matrixTwo[i, j];
                        
                    }
                    Console.Write(interMatrix[k, j]);
                    Console.Write("  ");

                }
                Console.WriteLine();

            }



            Console.ReadKey();

        }
    }
}
