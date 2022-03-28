using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace Home_Work_8._6
{
    /// <summary>
    /// Структура описывает департамент
    /// </summary>
    public struct Department : IComparable<Department>
    {
        #region Конструкторы (Constructors)
        /// <summary>
        /// Основной конструктор структуры
        /// </summary>
        /// <param name="name">Имя департамента</param>
        /// <param name="creationDate">Дата создания департамента</param>
        public Department(string name, DateTime creationDate) : this()
        {
            Name = name;
            CretionDate = creationDate;
            Workers = new List<Worker>();
        }
        /// <summary>
        /// Второстепенный конструктор. Без даты создания
        /// </summary>
        /// <param name="name">Имя департамента</param>
        public Department(string name) : 
            this(name, DateTime.Now) { }
        #endregion
        #region Поля (Fields)
        /// <summary>
        /// Поле соджержит имя департамента
        /// </summary>
        private string name;
        /// <summary>
        /// Поле содержит дату создания департамента
        /// </summary>
        private DateTime creationDate;
        /// <summary>
        /// Поле содержик список сотрудникв департамента
        /// </summary>
        private List<Worker> workers;

        private Organization backLink;
        #endregion
        #region Свойства (Properties)
        /// <summary>
        /// Свойство содержит имя департамента
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        /// <summary>
        /// Свойство содержит дату создания департамента
        /// </summary>
        public DateTime CretionDate
        {
            get { return creationDate; }
            set { this.creationDate = value; }
        }
        /// <summary>
        /// Свойство содержит количество сотрудников в департаменте
        /// </summary>
        public ushort Count
        {
            get { return (ushort) Workers.Count; }
            
        }
        /// <summary>
        /// Свойство содержит список (TList) сотрудников департамента
        /// </summary>
        public List<Worker> Workers
        {
            get { return this.workers; }
            set { this.workers = value; }
        }

        public Worker this[ushort index]
        {
            get { return this.workers[index]; }
            
        }
        #endregion
        #region Методы (Methods)
        /// <summary>
        /// Метод добавления работника в департамент
        /// </summary>
        /// <param name="firstname">Имя работника</param>
        /// <param name="surname">Фамилия работника</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="department">Департамент работника</param>
        /// <param name="salary">Зарплата работника</param>
        public void AddWorker(string firstname, string surname, ushort age, float salary)
        {
            Random r = new Random();
            Worker tmp = new Worker(firstname, surname, age, salary);
            
            tmp.Id = (uint)r.Next(1000);
            tmp.Department = this.Name;
            Workers.Add(tmp);
            
        }
        /// <summary>
        /// Метод для вывод информации по выбранному департаменту
        /// </summary>
        /// <param name="back">Локальная переменная которая хранит обратную ссылку на вызвавшей ее обьект организации</param>
        public void Display(Organization back)
        {
            backLink = back;
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine($"                                     {this.Name}                                        ");
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine($"{"Фамилия", 12}{"Имя",15}{"Возраст",15}{"Департамент",20}{"ИД",12}{"З/П",15}");
            Console.WriteLine("..........................................................................................");
            for (ushort i = 0; i < this.Count; i++)
            {
                Console.WriteLine($"{this[i].SecondName, 12}{this[i].FirstName,15}{this[i].Age,15}{this[i].Department,20}" +
                                  $"{this[i].Id,12}{this[i].Salary,15:### ###}");
            }
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("/1/- Удалить    /2/-Редактировать   /3/-Добавить   /4/-Cортировка  /5/-Назад");
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {

                case ConsoleKey.D1: Remove(); break;
                case ConsoleKey.D2: Edit(); break;
                case ConsoleKey.D3: Add(); break;
                case ConsoleKey.D4: Sort(); break;
                case ConsoleKey.D5: Console.Clear(); backLink.Display(); break;
            }

        }
        /// <summary>
        /// Приватный метод для сортировки работников департамента
        /// </summary>
        private void Sort()
        {
            Console.WriteLine("По какому критерию хотите сделать сортировку?:\n" +
                              "/1/-Фамилия   /2/-Имя   /3/-Возраст   /4/-Департамент   /5/-ИД   /6/-Зарплата");
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.D1:
                {
                    this.Workers.Sort(new SnameSort());
                    break;
                }
                case ConsoleKey.D2:
                {
                    this.Workers.Sort(new NameSort());
                        break;
                }
                case ConsoleKey.D3:
                {
                    this.Workers.Sort(new AgeSort());
                        break;
                }
                case ConsoleKey.D4:
                {
                    this.Workers.Sort(new DepSort());
                    break;
                }
                case ConsoleKey.D5:
                {
                    this.Workers.Sort();
                    break;
                }
                case ConsoleKey.D6:
                {
                    this.Workers.Sort(new SalarySort());
                    break;
                }
            }
            Console.Clear();
            Display(backLink);
        
    }
        /// <summary>
        /// Приватный метод для добавления работника
        /// </summary>
        private void Add()
        {
            Console.WriteLine("Введите фамилию нового работника");
            string Lname = Console.ReadLine();
            Console.WriteLine("Введите имя нового работника");
            string Fname = Console.ReadLine();
            Console.WriteLine("Введите возраст нового работника");
            short Age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите зарплату нового работника");
            decimal Salary = Convert.ToDecimal(Console.ReadLine());
            this.AddWorker(Lname, Fname, (ushort)Age, (float)Salary);

            Console.Clear();
            Display(backLink);

        }
        /// <summary>
        /// Приватный метод для редактирования работника
        /// </summary>
        private void Edit()
        {
            Console.WriteLine("Введите имя или фамилию или ИД работника");
            string n = Console.ReadLine();
            uint nn;
            uint.TryParse(n, NumberStyles.Integer, CultureInfo.InvariantCulture, out nn);

            for (int i = 0; i < this.Workers.Count; i++)
            {


                if (this.Workers[i].SecondName == n || this.Workers[i].FirstName == n || this.Workers[i].Id == nn)
                {
                    Worker tmp = this.Workers[i];

                    Console.WriteLine("Введите фамилию работника");
                    tmp.SecondName = Console.ReadLine();
                    Console.WriteLine("Введите имя работника");
                    tmp.FirstName = Console.ReadLine();
                    Console.WriteLine("Введите возраст работника");
                    tmp.Age = (ushort) Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Введите зарплату нового работника");
                    tmp.Salary = (float) Convert.ToDecimal(Console.ReadLine());

                    this.Workers[i] = tmp;
                }   

            }
            Console.Clear();
            Display(backLink);
        }
        /// <summary>
        /// Приватный метод для удаления сотрудника
        /// </summary>
        private void Remove()
        {
            Console.WriteLine("Введите имя или фамилию или ИД работника");
            string n = Console.ReadLine();
            uint nn;
            uint.TryParse(n, NumberStyles.Integer, CultureInfo.InvariantCulture, out nn);
            
            for (int i = 0; i < this.Workers.Count; i++)
            {


                if (this.Workers[i].SecondName == n || this.Workers[i].FirstName == n || this.Workers[i].Id == nn)
                {
                    Workers.Remove(this.Workers[i]);
                }

            }
            Console.Clear();
            Display(backLink);
        }
        #endregion
        #region Интерфейсы (Interfaces)
        /// <summary>
        /// Метод для реализации интерфейса сортировки по умолчанию
        /// Сортировка по именю департамента
        /// </summary>
        /// <param name="obj">Обьект структуры</param>
        /// <returns></returns>
        public int CompareTo(Department obj)
        {
            return this.Name.CompareTo(obj.Name);
            
        }


        #endregion


    }
    /// <summary>
    /// Компаратор для сортировки департаментов по дате оздания
    /// </summary>
    struct DataSort : IComparer<Department>
    {
        public int Compare(Department one, Department two)
        {
            if (one.CretionDate > two.CretionDate)
                return 1;
            else if (one.CretionDate < two.CretionDate)
                return -1;
            else
                return 0;
        }
    }
    /// <summary>
    /// Компаратор для сортировки департаментов по количеству работников
    /// </summary>
    struct CountSort : IComparer<Department>
    {
        public int Compare(Department one, Department two)
        {
            if (one.Count > two.Count)
                return 1;
            else if (one.Count < two.Count)
                return -1;
            else
                return 0;
        }
    }

}

