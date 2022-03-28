using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Home_Work_7._8
{
    /// <summary>
    /// Основленая структура который хранит массив структур Entry
    /// </summary>
    public struct Diary
    {
        #region Поля
        private Entry[] entrys;
        private uint count;



        #endregion

        #region Конструкторы
        public Diary(string Path) : this()
        {
            Load(Path);
            this.Entrys = entrys;
            Count = (uint) Entrys.Length;
            
        }

        #endregion

        #region Свойства
        /// <summary>
        /// Свойство хранит массив структур из ежедневника
        /// </summary>
        public Entry[] Entrys 
        {
            get { return this.entrys;}
            private set { this.entrys = value; }
        }
        /// <summary>
        /// Свойство индексатор. Необходим для работы метода сортировки
        /// </summary>
        /// <param name="s">Строковый параметр имя вызываемого поля структуры</param>
        /// <param name="index">Индкес в массиве структур.</param>
        /// <returns></returns>
        public string this[string s, uint index]
        {
            get
            {
                switch (s)
                {
                    case "autor": return this.entrys[index].Autor; break;
                    case "notes": return this.entrys[index].Notes; break;
                    case "todo": return this.entrys[index].Todo; break;
                    case "wishlist": return this.entrys[index].WishList; break;
                }

                return null;
            }
        }
        /// <summary>
        ///Свойство хранит общее количество записей в ежедневнике
        /// </summary>
        public uint Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        #endregion

        #region Методы
        public void Sort()
        {
            Console.Write("Выберите поле по которому будет произведена сортировка:\n" +
                          "1 - Автор  2 - Заметка  3 - Список дел  4 - Список желаний  5 - Дата\n");
            Char k = Console.ReadKey().KeyChar;
            switch (k)
            {
                case '1': sort("autor"); break;
                case '2': sort("notes"); break;
                case '3': sort("todo"); break;
                case '4': sort("wishlist"); break;
                case '5': sort("date"); break;
            }

            
           Display();
        }
        /// <summary>
        /// Приватный метод для сортировки. Принимает строковый параметр. Который с помощью индексатора выбирает нужное поле.
        /// Также отдельно сделан метод для сортировки даты.
        /// </summary>
        /// <param name="field">Параметр служит укаателем поля для индексатора</param>
        private void sort(string field)
        {
            if (field == "date")
            {
                for (uint i = 1; i < entrys.Length; i++)
                {
                    for (uint j = 0; j < i; j++)
                    {
                        if (entrys[i].CreateDate.CompareTo(entrys[j].CreateDate) > 0)
                        {
                            swap(ref entrys[j], ref entrys[i]);
                        }
                    }
                }
            }
            else
            {
                uint queue = 0;
                while (queue < entrys.Length)
                {
                    for (uint i = queue + 1; i < entrys.Length; i++)
                    {
                        if (this[field, i] == this[field, queue])
                        {
                            queue++;
                            swap(ref entrys[i], ref entrys[queue]);
                        }
                    }

                    queue++;
                }
            }
        }
        /// <summary>
        /// Вспомогательный метод для сортировки. Менят местами две структуры
        /// Метода принимает параметры по ссылке (ref)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        private void swap(ref Entry src, ref Entry dst)
        {
            Entry temp = new Entry();
            temp = src;
            src = dst;
            dst = temp;
        }
        /// <summary>
        /// Метод добавляет запись в ежедневник. Ручной ввод. Без параметров
        /// </summary>
        public void Add()
        {
            //Увеличиваем массив со структорами на один
            Array.Resize(ref entrys, entrys.Length + 1);
            //Далее заполняем данные
            Console.Write("Введите имя автора: ");
            entrys[entrys.Length - 1].Autor = Console.ReadLine();
            Console.Write("Введите заметку: ");
            entrys[entrys.Length - 1].Notes = Console.ReadLine();
            Console.Write("Введите список дел: ");
            entrys[entrys.Length - 1].Todo = Console.ReadLine();
            Console.Write("Введите список желаний: ");
            entrys[entrys.Length - 1].WishList = Console.ReadLine();
            Console.Write("Введите дату: ");
            entrys[entrys.Length - 1].CreateDate = DateTime.Parse(Console.ReadLine());

            //Вызываем метод Display
            Display();
        }
        /// <summary>
        /// Метод удаляет запись по номеру. Дальше вызывает метод Display для одновления ежеденевника
        /// Параметров не имеет
        /// </summary>
        public void Remove()
        {
            //Вначале запрашиваем индекс записи которую хотим удалить
            Console.Write("Введите номер элемента для удаления: ");
            uint index = Convert.ToUInt32(Console.ReadLine()) - 1;
            //Условным оператором проверяем, не является индекс последним
            if (index == entrys.Length - 1)//Если да то, сразу меняем размер массива со структурами
            {
                Array.Resize(ref entrys, entrys.Length - 1);
            }
            else //Если нет, вначале переноним последнюю запись на место которым будем удалять.
            {
                entrys[index] = entrys[entrys.Length - 1];
                Array.Resize(ref entrys, entrys.Length - 1);
            }
            //Вызываем метод Desplay и попадаем на гланый экран
            Display();
        }
        /// <summary>
        /// Метод радактирования выбранного пункта из ежедневника. Параметров нет
        /// </summary>
        public void Edit()
        {
            uint index;
            //Запрашиваем сначала индекс записи, далее по очереди редактируем 5 пунктов.
            //В конце вызываем метод Desplay и обновляем экран
            Console.Write("Выберите номер записи для редактирования: ");
            index = Convert.ToUInt32(Console.ReadLine()) - 1;
            Console.Write("Введите имя автора: ");
            entrys[index].Autor = Console.ReadLine();
            Console.Write("Введите заметку: ");
            entrys[index].Notes = Console.ReadLine();
            Console.Write("Введите список дел: ");
            entrys[index].Todo = Console.ReadLine();
            Console.Write("Введите список желаний: ");
            entrys[index].WishList = Console.ReadLine();
            Console.Write("Введите дату: ");
            entrys[index].CreateDate = DateTime.Parse(Console.ReadLine());

            Display();

        }
        /// <summary>
        /// Метод загрузки с одним параметром который указывает путь к файлу. Ничего не возвращает
        /// Использутся в программе для загрузки файла ежедневника при запуске
        /// </summary>
        /// <param name="Path"></param>
        public void Load(string Path)
        {
            //Считаем количество строчек в файле
            entrys = new Entry[File.ReadAllLines(Path).Length];
            //Создаем поток для чтения из файла. Разбиваем строку на заданный разделитель
            //и кладем в массив
            using (StreamReader sr = new StreamReader(Path))
            {
                for (int i = 0; i < entrys.Length; i++)
                {
                    
                    string[] str = sr.ReadLine().Split("<|>");
                    entrys[i].Autor = str[0];
                    entrys[i].Notes = str[1];
                    entrys[i].Todo = str[2];
                    entrys[i].WishList = str[3];
                    entrys[i].CreateDate = Convert.ToDateTime(str[4]);
                }
            }
            
        }
        /// <summary>
        /// Перегруженный метод загрузки из выбранного пользователем файла, с выбором даты начала
        /// и даты окончания нужного диапазона.
        /// </summary>
        public void Load()
        {
            //Первая переменная считает количество, вторая текущий индекс в отсортированном массиве.
            //Она необходима для правльного уменьшения размера массива
            uint count = 0, index = 0;
            //Ввод имени файла и выбор диапазоона дат
            Console.WriteLine("Введите имя файла: ");
            string f = Console.ReadLine();
            Console.WriteLine("Введите дату начала: ");
            DateTime dStart = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите дату окончания: ");
            DateTime dEnd = DateTime.Parse(Console.ReadLine());
            //Считаем количество строчек в файле
            entrys = new Entry[File.ReadAllLines(f).Length];
            //Создаем поток для чтения из файла. Разбиваем строку на заданный разделитель
            //и кладем в массив
            using (StreamReader sr = new StreamReader(f))
            {
                for (int i = 0; i < entrys.Length; i++)
                {

                    string[] str = sr.ReadLine().Split("<|>");
                    entrys[i].Autor = str[0];
                    entrys[i].Notes = str[1];
                    entrys[i].Todo = str[2];
                    entrys[i].WishList = str[3];
                    entrys[i].CreateDate = Convert.ToDateTime(str[4]);
                }
            }
            //В этом цикле происходит сортировка по датам.
            for (int i = 0; i < entrys.Length; i++)
            {
                if (entrys[i].CreateDate < dStart || entrys[i].CreateDate > dEnd)
                {
                    continue;
                }
                else
                {
                    entrys[index] = entrys[i];
                    index++;
                    count++;
                }
            }
            //Здес уменьшаем наш массив до нужного размера который храниться в переменой "сount"
            Array.Resize(ref entrys, (int)count);

            //Метод Display для обновления экрана
            Display();
        }
        /// <summary>
        /// Метод сохранения структуры ежедневника в файл на диске. Параметров нет
        /// </summary>
        public void Save()
        {
            //Запрос места сохранения ежедневника
            Console.Write("Введите имя файла: ");
            string f_name = Console.ReadLine();
            //Далее открываем поток записи в файл и построчно записываем структуру ежедневника
            using (StreamWriter fs = new StreamWriter(f_name, false))
            {
                for (int i = 0; i < Entrys.Length; i++)
                {
                    fs.WriteLine($"{Entrys[i].Autor}<|>{Entrys[i].Notes}<|>{Entrys[i].Todo}<|>" +
                                 $"{Entrys[i].WishList}<|>{Entrys[i].CreateDate}");
                }
            }
            //В конце вызов метода Display для обновления экрана
            Display();
        }
        /// <summary>
        /// Display одна из ключевых функций, испльзуется при каждом обновлении ежеденевника а
        /// также после загрузки. Параметров не имеет
        /// </summary>
        public void Display()
        {
            //Очистка экрана
            Console.Clear();
            //Далее идет отрисовка Заголовка ежеденвника и построчный вывод из массива Entry
            Console.WriteLine($"{"№", 3}{"Автор",10}{"Заметка", 30}{"Список дел", 25}{"Список желаний",25}{"Дата", 20}");
            Console.WriteLine();
            for (int i = 0; i < entrys.Length; i++)
            {
                Console.WriteLine($"{i + 1, 3}{entrys[i].Autor,10}{entrys[i].Notes,30}{entrys[i].Todo,25}" +
                                  $"{entrys[i].WishList,25}{entrys[i].CreateDate.ToShortDateString(),20}");
            }
            Console.WriteLine();
            Console.WriteLine($"   1 - Удалить  2 - Редактировать 3 - Создать 4 - Сохранить " +
                              $"5 - Сортировка 6 - Загрузить 7 - Выход");
            //Выбор пользователя что дальше надо сделать
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.D1:
                {
                    Remove();
                    break;
                }
                case ConsoleKey.D2:
                {
                    Edit();
                    break;
                }
                case ConsoleKey.D3:
                {
                    Add();
                    break;
                }
                case ConsoleKey.D4:
                {
                    Save();
                    break;
                }
                case ConsoleKey.D5:
                {
                    Sort();
                    break;
                }
                case ConsoleKey.D6:
                {
                    Load();
                    break;
                }
                case ConsoleKey.D7: break;
                
            }

        }


        #endregion



    }
}