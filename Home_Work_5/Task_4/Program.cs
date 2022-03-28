using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        /// <summary>
        /// Метод определяет является ли последовательность чисел прогрессией
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static (bool, bool) CheckProgression(int[] numbers)
        {
            float Arithmetic = numbers[1] - numbers[0];
            float Geometric = numbers[1] / numbers[0];

            bool isArithmetic = true;
            bool isGeometric = true;

            for (int i = 1; i < numbers.GetLength(0); i++)
            {
                if (isArithmetic == true)
                    if (numbers[i + 1] - numbers[i] != Arithmetic)
                        isArithmetic = false;

                if (isGeometric == true)
                    if (numbers[i + 1] / numbers[i] != Geometric)
                        isGeometric = false;
            }
            return (isArithmetic, isGeometric);
        }

    }
}
