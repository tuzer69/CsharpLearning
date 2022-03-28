using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mime;
using System.Windows;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Приветствуем вас в игре \"Угадайка\"\nПравила игры:\n" +
                              $"Загадывается случайное число в диапазоне от 12 до 120\n" +
                              $"Каждый из игроков может ввести число от 1 до 4,\n" +
                              $"Кто первым добереться до нуля обьявляется победителем...");
            Console.ReadKey();
            Console.Clear(); //Очистка экрана, начало игры


            Random rand = new Random(); //Генератор СЛЧ

            Console.Write("Введите имя первого игрока: ");
            string firstPlayer = Console.ReadLine(); //Переменная с именем первого игрока
            Console.Write("Введите имя второго игрока: ");
            string secondPlayer = Console.ReadLine(); //Переменная с именем второго игрока
            int gameNumber = rand.Next(20, 121); // Генерируем случайный Game Number

            ushort userTry; //Число которые вводит игрок
            while (gameNumber > 0) //Начало игрового чикла
            {
                #region Первый игрок
                Console.Write($"Ход игрока {firstPlayer}, введите число 1 до 4: ");
                while (!ushort.TryParse(Console.ReadLine(),NumberStyles.Any,
                    CultureInfo.InvariantCulture,out userTry) || userTry > 4 || userTry < 1)
                {
                    Console.WriteLine("ОШИБКА!. Число должно быть в дипазоне от 1 до 4. Пробуйте еще раз...");
                }
                if (gameNumber < userTry)
                {
                    Console.WriteLine("Ввдено число больше нужного. ПРОПУСК ХОДА!");
                }
                
                else if (gameNumber - userTry == 0)
                {
                    Console.WriteLine($"ПОЗДРАВЛЯЮ игрок {firstPlayer} победил!");
                    Console.WriteLine("Ходите РЕВАНШ (Y/N)?: ");
                    if (Console.ReadKey().KeyChar == 'Y' || Console.ReadKey().KeyChar == 'y')
                    {
                        Console.WriteLine("РЕСТАРТ");
                        Console.ReadKey();
                        var info = new ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
                        System.Diagnostics.Process.Start(info);
                    }
                    //Если игрок хочет взять реванш. В этом случае возвтрат назат по средством goto
                    //Если не хочет тогда выход из проложения через оператор brake
                    //break;

                }
                else
                {
                    gameNumber -= userTry;
                }
                #endregion
                #region Второй игрок
                Console.Write($"Ход игрока {secondPlayer}, введите число 1 до 4: ");
                while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out userTry) || userTry > 4 || userTry < 1)
                {
                    Console.WriteLine("ОШИБКА!. Число должно быть в дипазоне от 1 до 4. Пробуйте еще раз...");
                }
                if (gameNumber < userTry)
                {
                    Console.WriteLine("Ввдено чило больше нужного. ПРОПУСК ХОДА!");
                }

                else if (gameNumber - userTry == 0)
                {
                    Console.WriteLine($"ПОЗДРАВЛЯЮ игрок {secondPlayer} победил!");
                    Console.WriteLine("Ходите РЕВАНШ (Y/N)?: ");
                    if (Console.ReadKey().KeyChar == 'Y' || Console.ReadKey().KeyChar == 'y')
                    {
                        Console.WriteLine("РЕСТАРТ");
                        Console.ReadKey();
                        var info = new ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
                        System.Diagnostics.Process.Start(info);
                    }
                    //Если игрок хочет взять реванш. В этом случае возвтрат назат по средством goto
                    //Если не хочет тогда выход из проложения через оператор brake
                    //break;

                }
                else
                {
                    gameNumber -= userTry;
                }

                #endregion
            }

            //Console.ReadKey();

        }
        
    }
}
