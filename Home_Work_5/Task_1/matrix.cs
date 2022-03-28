using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{ 
    public static class matrix
    {
        /// <summary>
        /// Метод для вывода матрицы на экран
        /// </summary>
        /// <param name="matirx"></param>
        public static void PrintMatrix(int[,] matirix)
        {
            for (int i = 0; i < matirix.GetLength(0); i++)
            {
                for (int j = 0; j < matirix.GetLength(1); j++)
                {

                    Console.Write($"{matirix[i, j],3}");

                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int[,] MulToNum(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   matrix[i, j] *= number;
                }
            }

            return matrix;
        }
        
        /// <summary>
        /// Метод сложения двух матриц
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static int[,] AddMatrix(int[,] one, int[,] two)
        {
            int[,] matrix = new int[one.GetLength(0), one.GetLength(1)];
            for (int i = 0; i < one.GetLength(0); i++)
            {
                for (int j = 0; j < one.GetLength(1); j++)
                {
                    matrix[i, j] += one[i, j] + two[i, j];
                }
            }

            return matrix;
        }
        /// <summary>
        /// Метод вычитания двух матриц
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static int[,] SubMatrix(int[,] one, int[,] two)
        {
            int[,] matrix = new int[one.GetLength(0), one.GetLength(1)];
            for (int i = 0; i < one.GetLength(0); i++)
            {
                for (int j = 0; j < one.GetLength(1); j++)
                {
                    matrix[i, j] += one[i, j] - two[i, j];
                }
            }

            return matrix;
        }
        /// <summary>
        /// Метод умножения двух матриц
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static int[,] MulMatrix(int[,] one, int[,] two)
        {
            int[,] matrix = new int[one.GetLength(0), one.GetLength(1)];
            for (int i = 0; i < one.GetLength(0); i++)
            {
                for (int j = 0; j < one.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                    for (int k = 0; k < one.GetLength(0); k++)
                    {
                        matrix[i, j] += one[i, k] * two[k, j];
                        
                    }
                    
                }
                
            }

            return matrix;
        }

    }
}
