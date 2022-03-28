using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Home_Work_8._6
{
    /// <summary>
    /// Структура описывает организацию которая содержит департаменты
    /// </summary>
    public struct Organization 
    {

        #region Поля
        /// <summary>
        /// Поле хранит список департаментов
        /// </summary>
        private List<Department> list;

        #endregion
        #region Свойства
        /// <summary>
        /// Свойство хранит список департаментов
        /// </summary>
        public List<Department> List
        {
            get { return this.list; }
            set { this.list = value; }



        }
        #endregion
        #region Методы
        /// <summary>
        /// Метод добавления департамента
        /// </summary>
        /// <param name="name"></param>
        /// <param name="creationDate"></param>
        public void AddDepartment(string name, DateTime creationDate)
        {
            List.Add(new Department(name, creationDate));
        }
        /// <summary>
        /// Метод добаления департамента только по имени
        /// </summary>
        /// <param name="name">Имя департамента</param>
        public void AddDepartment(string name)
        {
            List.Add(new Department(name));
        }
        /// <summary>
        /// Метод для удаления департамента
        /// </summary>
        /// <param name="name">Имя департамента</param>
        public void RemoveDep(Department name)
        {
            List.Remove(name);
        }
        /// <summary>
        /// Метод без параметров для вывода списка департаментов на экран
        /// </summary>
        public void Display()
        {
            List ??= new List<Department>(); //Если список пустой добавляем новый список
            Console.Clear();
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("                                     ДЕПАРТАМЕНТЫ                                        ");
            Console.WriteLine("*****************************************************************************************");
            //В цикле выводим поочередно выводим департаменты на экран
            Console.WriteLine($"{"Наименование",23}{"Дата создания",25}{"Кол-во сотрудников",25}");
            Console.WriteLine("..........................................................................................");
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine($"{List[i].Name,23}{List[i].CretionDate.ToShortDateString(),25}{List[i].Count,25}");
            }
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("           /1/-Выбор    /2/- Удалить    /3/-Редактировать   /4/-Добавить   \n" +
                              "\n                 /5/-Сортировка  /6/-Сохранить   /7/-Загрузить");
            //Тут в зависимости от нажатой клавиши на цифровой клавиатуре вызываем нужный метод
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.D1: Enter(); break;
                case ConsoleKey.D2: Remove(); break;
                case ConsoleKey.D3: Edit(); break;
                case ConsoleKey.D4: Add(); break;
                case ConsoleKey.D5: SortDep(); break;
                case ConsoleKey.D6: Save(); break;
                case ConsoleKey.D7: Load(); break;

            }

        }
        /// <summary>
        /// Метод для сохранения данных организации в формате XML/JSON
        /// </summary>
        public void Save()
        {
            Console.Write("Введите имя файла: ");
            string path = Console.ReadLine();
            Console.Write("Выбирите формат для сохранения:\n" +
                          "/1/-XML   /2/-JSON ");
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.D1: toXml(path + ".xml"); break;
                case ConsoleKey.D2: toJson(path + ".json"); break;
            }
            Display();
        }
        /// <summary>
        /// Метод загрузки базы данных из файла в формате XML/JSON
        /// </summary>
        public void Load()
        {
            Console.Write("Введите имя файла: ");
            string path = Console.ReadLine();
            string[] f = path.Split('.');
            foreach (var i in f)
            {
                if (i.ToUpper() == "XML") loadXml(path);
                else if (i.ToUpper() == "JSON") loadJson(path);
            }
            Display();
        }
        /// <summary>
        /// Приватный метод для загрузки базы данных в формате JSON
        /// </summary>
        /// <param name="path">Путь к файлу БД</param>
        private void loadJson(string path)
        {
            string json = File.ReadAllText(path);
            List = JsonConvert.DeserializeObject<List<Department>>(json);
        }
        /// <summary>
        /// Приватный метод для загрузке базы данных в формате XML
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void loadXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            List = xmlSerializer.Deserialize(fStream) as List<Department>;
            fStream.Close();
        }
        /// <summary>
        /// Приватный метод для сохранения в формате JSON
        /// </summary>
        /// <param name="path"></param>
        private void toJson(string path)
        {
            string json = JsonConvert.SerializeObject(List);
            File.WriteAllText(path, json);
        }
        /// <summary>
        /// Приватный метод для сохранения в формате XML
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void toXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, List);
            fStream.Close();
        }
        /// <summary>
        /// Приватный метод сортировки списка департаментов по разным полям
        /// </summary>
        private void SortDep()
        {
            Console.WriteLine("По какому критерию хотите сделать сортировку?:\n" +
                              "/1/-Наименование   /2/-Дата создания /3/-Кол-во сотрудников");
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.D1:
                {
                    this.List.Sort();
                    break;
                }
                case ConsoleKey.D2:
                {
                    this.List.Sort(new DataSort());
                    break;
                }
                case ConsoleKey.D3:
                {
                    this.List.Sort(new CountSort());
                    break;
                }
            }
            Console.Clear();
            Display();
        }
        /// <summary>
        /// Приватный метод для добавления депарамента
        /// </summary>
        private void Add()
        {
            Console.Write("Введите наименование нового департамента: ");
            string name = Console.ReadLine();
            Console.Write("Введите дату создания департамента: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            this.AddDepartment(name, date);
            Console.Clear();
            Display();

        }
        /// <summary>
        /// Приватный метод для редактирования департамента
        /// </summary>
        private void Edit()
        {

            Console.Write("Введите наименование департамента: ");
            string str = Console.ReadLine();

            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].Name == str)
                {
                    Department tmp = this.List[i];
                    Console.Write("Введите новое наименование департамента: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите дату создания департамента: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    tmp.Name = name;
                    tmp.CretionDate = date;
                    this.List[i] = tmp;
                    Console.Clear();
                    Display();
                }
            }
        }
        /// <summary>
        /// Приватный метод удаления департамента
        /// </summary>
        private void Remove()
        {
            Console.Write("Введите название департамента: ");
            string str = Console.ReadLine();
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].Name == str)
                {
                    RemoveDep(this.List[i]);
                    Console.Clear();
                    Display();
                }
            }
        }
        /// <summary>
        /// Приватный метод для выбора департамента
        /// </summary>
        private void Enter()
        {
            Console.Write("Введите название департамента: ");
            string str = Console.ReadLine();
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].Name == str)
                {
                    Console.Clear();
                    this.List[i].Display(this);
                }
            }
        }
        #endregion
    }
}