using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Task_1;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); //Генератор СЛЧ для матрицы
            int Xasix, Yasix, Mnumber; //Переменные для храннения размерности матрицы

            #region Умножение на число
            Console.WriteLine("======================  Умножение матрицы на число  ========================");
            Console.WriteLine("===============  Введите размер матриц по оси X:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Xasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            Console.WriteLine("===============  Введите размер матриц по оси Y:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Yasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            Console.WriteLine("===============  Введите число котороу умножаем:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Mnumber))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            int[,] addingMatrix = new int[Xasix, Yasix]; //Создаем матрицу нужой размерности
            //Заполняем матрицу случайными значениями
            for (int i = 0; i < addingMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < addingMatrix.GetLength(1); j++)
                {
                    addingMatrix[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("Исходная матрица:");
            matrix.PrintMatrix(addingMatrix);
            Console.WriteLine();
            Console.WriteLine($"Результат умножения на число {Mnumber}");
            matrix.PrintMatrix(matrix.MulToNum(addingMatrix, Mnumber));
            Console.ReadKey();
            #endregion
            Console.Clear();
            #region Сложение двух матриц
            Console.WriteLine("======================  Сложение двух матриц  ========================");
            Console.WriteLine("===============  Введите размер матриц по оси X:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Xasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            Console.WriteLine("===============  Введите размер матриц по оси Y:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Yasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            int[,] oneMatrix = new int[Xasix, Yasix]; //Первая матрица
            int[,] TwoMatrix = new int[Xasix, Yasix]; //Вторая матрица
            for (int i = 0; i < oneMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < oneMatrix.GetLength(1); j++)
                {
                    oneMatrix[i, j] = rand.Next(10);
                    TwoMatrix[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("Первая матрица:");
            matrix.PrintMatrix(oneMatrix);
            Console.WriteLine();
            Console.WriteLine("Вторая матрица:");
            matrix.PrintMatrix(TwoMatrix);
            Console.WriteLine();
            Console.WriteLine("Результат сложения двух матриц:");
            matrix.PrintMatrix(matrix.AddMatrix(oneMatrix, TwoMatrix));
            Console.ReadKey();

            #endregion
            Console.Clear();

            #region Вычитание двух матриц
            Console.WriteLine("======================  Вычитание двух матриц  ========================");
            Console.WriteLine("===============  Введите размер матриц по оси X:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Xasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            Console.WriteLine("===============  Введите размер матриц по оси Y:  ==========================");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Yasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            oneMatrix = new int[Xasix, Yasix];
            TwoMatrix = new int[Xasix, Yasix];
            for (int i = 0; i < oneMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < oneMatrix.GetLength(1); j++)
                {
                    oneMatrix[i, j] = rand.Next(10);
                    TwoMatrix[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("Первая матрица:");
            matrix.PrintMatrix(oneMatrix);
            Console.WriteLine();
            Console.WriteLine("Вторая матрица:");
            matrix.PrintMatrix(TwoMatrix);
            Console.WriteLine();
            Console.WriteLine("Результат вычитания двух матриц:");
            matrix.PrintMatrix(matrix.SubMatrix(oneMatrix, TwoMatrix));
            Console.ReadKey();


            #endregion
            Console.Clear();

            #region Умножение двух матриц
            Console.WriteLine("======================  Умнзожение двух матриц  ========================");
            Console.WriteLine("========  Введите размер матриц по осям (размер должен быть одинаковый):  ===============");
            while (!int.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out Xasix))
            {
                Console.WriteLine("Введите корректное значени от 1 до 30");
            }
            oneMatrix = new int[Xasix, Xasix];
            TwoMatrix = new int[Xasix, Xasix];
            for (int i = 0; i < oneMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < oneMatrix.GetLength(1); j++)
                {
                    oneMatrix[i, j] = rand.Next(10);
                    TwoMatrix[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("Первая матрица:");
            matrix.PrintMatrix(oneMatrix);
            Console.WriteLine();
            Console.WriteLine("Вторая матрица:");
            matrix.PrintMatrix(TwoMatrix);
            Console.WriteLine();
            Console.WriteLine("Результат умножения двух матриц:");
            matrix.PrintMatrix(matrix.MulMatrix(oneMatrix, TwoMatrix));
            Console.ReadKey();


            #endregion

        }
    }
}
