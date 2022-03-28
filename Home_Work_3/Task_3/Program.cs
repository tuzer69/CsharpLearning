using System;
using System.Globalization;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Приветствуем вас в игре \"Угадайка-3\"\nПравила игры:\n" +
                              $"Загадывается случайное число в диапазоне от 12 до 120\n" +
                              $"Каждый из игроков может ввести число от 1 до 4,\n" +
                              $"Кто первым добереться до нуля обьявляется победителем...");
            Console.ReadKey();
            Console.Clear(); //Очистка экрана, начало игры


            Random rand = new Random(); //Генератор СЛЧ

            Console.Write("Введите имя игрока: ");
            string human = Console.ReadLine(); //Переменная с именем первого игрока
            
            int gameNumber = rand.Next(20, 121); // Генерируем случайный Game Number

            int userTry; //Число которые вводит игрок
            while (gameNumber > 0) //Начало игрового чикла
            {
                #region Человек
                //Ход человека
                Console.Write($"Ход игрока {human}, введите число 1 до 4: ");
                while (!int.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out userTry) || userTry > 4 || userTry < 1)
                {
                    Console.WriteLine("ОШИБКА!. Число должно быть в дипазоне от 1 до 4. Пробуйте еще раз...");
                }
                if (gameNumber < userTry)
                {
                    Console.WriteLine("Ввдено число больше нужного. ПРОПУСК ХОДА!");
                }

                else if (gameNumber - userTry == 0)

                {
                    Console.WriteLine($"ПОЗДРАВЛЯЮ игрок {human} победил!");
                    break;

                }
                else
                {
                    gameNumber -= userTry;
                }
                #endregion
                #region Computer
                //Ход компьютера
                Console.Write($"Ход Компьютера: ");
                userTry = rand.Next(1, 5);
                Console.WriteLine(userTry);
                while (userTry > 4 || userTry < 1)
                {
                    Console.WriteLine("ОШИБКА!. Число должно быть в дипазоне от 1 до 4. Пробуйте еще раз...");
                    userTry = rand.Next(1, 5);
                }
                if (gameNumber < userTry)
                {
                    Console.WriteLine("Ввдено чило больше нужного. ПРОПУСК ХОДА!");
                }

                else if (gameNumber - userTry == 0)
                {
                    Console.WriteLine($"ПОЗДРАВЛЯЮ Компьютер победил!");
                    
                    break;

                }
                else
                {
                    gameNumber -= userTry;
                }

                #endregion
            }


        }

    }
}

