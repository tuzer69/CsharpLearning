using System;
using System.Diagnostics;
using System.Globalization;

namespace Task_2
{
    class Program
    {

            static void Main(string[] args)
            {

                Console.WriteLine($"Приветствуем вас в игре \"Угадайка-2.0\"\nПравила игры:\n" +
                                  $"Игроки загадывают случайное число, которое указывает размер игры,\n" +
                                  $"далее игроками выбирается число, которое указывает размер хода\n" +
                                  $"каждый ход уменьшает размер игры. Тот игрок который\n" +
                                  $"первым добереться до нуля обьявляется победителем...");
                Console.ReadKey();
                Console.Clear(); //Очистка экрана, начало игры
                Random rand = new Random(); //Генератор СЛЧ
                ushort countPlayers; //Переменная хранит количество игроков
                int mingameSize; //Переменная для хранения минимального заначения gameNumber
                int maxgameSize; //Переменная для хранения Максимального заначения gameNumber
                ushort minUserTry; //Переменная для хранения минимального размера хода
                ushort maxUserTry; //Переменная для хранения максимального размера хода

                Console.Write("Введите количество игроков от 2 до 5: ");
                //Проверяем количество игроков
                while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out countPlayers) || countPlayers > 5 || countPlayers < 2)
                {
                    Console.WriteLine("ОШИБКА!. Число игроков должно быть от 2 до 5. Пробуйте еще раз...");
                }

                #region Ввод размеров на ход
                //Проверка Мин размера игры
                Console.Write("Введите минимальный размер игры от 10 до 100: ");
                while (!int.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out mingameSize) || mingameSize < 10 || mingameSize > 100)
                {
                    Console.WriteLine("ОШИБКА!. Минимальный размер должен быть от 10 до 100. Пробуйте еще раз...");
                }

                //Проверка Макс размера игры
                Console.Write("Введите максимальный размер игры от 100 до 1000: ");
                while (!int.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out maxgameSize) || maxgameSize < 100 || maxgameSize > 1000)
                {
                    Console.WriteLine("ОШИБКА!. Минимальный размер должен быть от 10 до 100. Пробуйте еще раз...");
                }
                //Проверка МИН размера на ход
                Console.Write("Введите минимальный размер на ход от 2 до 10: ");
                while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out minUserTry) || minUserTry < 2 || minUserTry > 10)
                {
                    Console.WriteLine("ОШИБКА!. Минимальный размер на ход должен быть от 2 до 10. Пробуйте еще раз...");
                }
                //Проверка МАКС размера на ход
                Console.Write("Введите максимальный размер на ход от 15 до 50: ");
                while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out maxUserTry) || maxUserTry < 15 || maxUserTry > 50)
                {
                    Console.WriteLine(
                        "ОШИБКА!. Максимальный размер на ход должен быть от 15 до 50. Пробуйте еще раз...");
                }
                #endregion
                int gameNumber = rand.Next(mingameSize, maxgameSize); // Генерируем случайный размер игры

                ushort userTry; //Число которые вводит игрок
                uint currPlayer = 1; //Хранит текущего игрока, необходима для цикла while
                while (gameNumber > 0) //Начало игрового чикла. Пока игра не равно НОЛЬ
                {
                    Console.Write($"Ход {currPlayer}го игрока, введите число {minUserTry} до {maxUserTry}: ");
                    while (!ushort.TryParse(Console.ReadLine(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out userTry) || userTry < minUserTry || userTry > maxUserTry)
                    {
                        Console.WriteLine($"ОШИБКА!. Число должно быть в дипазоне " +
                                          $"от {minUserTry} до {maxUserTry}. Пробуйте еще раз...");
                    }
                    if (gameNumber < userTry)
                    {
                        Console.WriteLine("Введенный размер хода больше размер игры. Обьявляется НИЧЬЯ!");
                        break;
                    }
                    else if (gameNumber - userTry == 0)
                    {
                        Console.WriteLine($"ПОЗДРАВЛЯЮ игрок {currPlayer}й победил!");
                        break;

                    }
                    else
                    {
                        gameNumber -= userTry;
                        if (currPlayer == countPlayers) currPlayer = 0;
                        currPlayer++;
                    }
                }

                Console.ReadKey();

            }

    }
}
