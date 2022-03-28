using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Home_Work_6._6
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = ReadNum("N.txt"); //Записываем в переменную число из файла
            uint groups = (uint) Math.Log(number, 2) + 1; //Считаем количество групп
            //Спрашиваем пользователя нужно ли сделать полный расчет или только вывести количество групп
            Console.WriteLine($"Рассчитать все группы или только посмотреть их количество для {number}? (д/н): ");
            //Если нет выводим группы
            if (Console.ReadKey().KeyChar == 'н')
                Console.WriteLine($"Количество групп: {groups}");
            //Иначе делаем расчет и записываем результат в файл
            else
            {
                //Если в файле цифра 1
                if (number == 1)
                {
                    using (StreamWriter sw = new StreamWriter("out.txt", true))
                    {
                        sw.Write($"Группа 1: 1");
                    }
                }
                //Иначе считаем дальше
                else
                {
                    using (StreamWriter sw = new StreamWriter("out.txt", false))
                    {
                        DateTime curTime = DateTime.Now; //В переменную кладем время начала цикла
                        ushort degree = 1; //Хранит текущую группу И степень числа
                        //Считаем группы и одновременно пишем их в файловый поток
                        sw.Write($"Группа 1: 1");
                        for (int i = 2; i < number; i++)
                        {
                            
                            if (i == (int) (Math.Pow(2, degree)))
                            {
                                degree++;
                                sw.Write($"\nГруппа {degree}: {i} ");

                            }
                            else
                            {

                                sw.Write($"{i} ");

                            }
                        }
                        //После расчета выводим количество потраченного времени на расчеты.
                        Console.WriteLine();
                        TimeSpan span = DateTime.Now - curTime;
                        Console.WriteLine($"Затраченно время: {span.Minutes} " +
                                          $"мин. {span.Seconds} сек. {span.Milliseconds} мил.сек.");
                    }
                }
                //Спрашиваем пользователя нужно ли сжать полученный файл с результатами
                Console.WriteLine();
                Console.WriteLine("Хотите файл с группа поместить в архив? (д/н):");
                //Если да вызываем процедуду сжатия, если нет завершаем выполенение программы
                if (Console.ReadKey().KeyChar == 'д')
                    Compress("out.txt", "out.txt.zip");
            }

            Console.ReadKey();
        }



        /// <summary>
        /// Метод считывания и проверки на корректность из файла
        /// </summary>
        /// <param name="filePath">Параметр строка которая содержит путь к файлу для чтения</param>
        /// <returns></returns>
        public static uint ReadNum(string filePath)
        {
            //Проверяем существует ли файл
            while (!File.Exists(filePath))
            {
                Console.WriteLine($"Отсутствует файл: {filePath}");
                Console.Write("Хотите продолжить? (д/н): ");
                if (Console.ReadKey().KeyChar == 'н') return 0;

            }

            uint n; //Число из файла
            //В цикле проверяем на корректность считанных данных
            while (!uint.TryParse(File.ReadAllText(filePath),
                NumberStyles.Integer, CultureInfo.InvariantCulture, out n) || (n < 1 || n > 1_000_000_000))
            {
                Console.WriteLine("Значение должно быть числом в диапазоне от 1 до 1 000 000 000");
                Console.Write("Хотите продолжить? (д/н): ");
                if (Console.ReadKey().KeyChar == 'н') return 0;
            }


            return n;
        }

        /// <summary>
        /// Метод выполняет сжатие файла с результатами
        /// </summary>
        /// <param name="sourceName">Параметр является строкой которая содержит Имя или полынй путь к файлу</param>
        /// <param name="compressedName">Параметр строка которая задает имя для сжимаемого файла</param>
        public static void Compress(string sourceName, string compressedName)
        {
            using (FileStream ss = new FileStream(sourceName, FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(compressedName))
                {

                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs);
                        Console.WriteLine("Сжатие файла {0} завершено. Было: {1}K  стало: {2}K.",
                            sourceName,
                            ss.Length / 1024,
                            ts.Length / 1024);
                    }
                }
            }
        }
    }
}

    

