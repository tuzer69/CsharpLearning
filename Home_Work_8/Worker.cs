using System;
using System.Collections.Generic;
using System.Collections;

namespace Home_Work_8._6
{
    /// <summary>
    /// Структура полностью описывает работника департамента
    /// </summary>
    public struct Worker : IComparable<Worker>
    {
        #region Конструкторы (Constructors)
        /// <summary>
        /// Основной конструктор принимает все параметры
        /// </summary>
        /// <param name="firstname">Имя работника</param>
        /// <param name="surname">Фамилия работника</param>
        /// <param name="age">Возрат работника</param>
        /// <param name="department">Департамент работника</param>
        /// <param name="salary">Зарплата работника</param>
        /// <param name="id">ID работника</param>
        public Worker(string firstname, string surname, ushort age, float salary) : this()
        {
            FirstName = firstname;
            SecondName = surname;
            Age = age;
            Department = department;
            Salary = salary;
            Id = id;
        }
        public Worker(string firstname, string surname, ushort age) : 
            this(firstname, surname, age, 0){}
        public Worker(string firstname, string surname) :
            this(firstname, surname, 0, 0){ }

        #endregion
        #region Поля (Fields)
        /// <summary>
        /// Имя работника
        /// </summary>
        private string fname;
        /// <summary>
        /// Фамилия работника
        /// </summary>
        private string sname;
        /// <summary>
        /// Возраст работника
        /// </summary>
        private ushort age;
        /// <summary>
        /// Наименование департамента в котором служит работник
        /// </summary>
        private string department;
        /// <summary>
        /// Размер заработной платы работника
        /// </summary>
        private float salary;
        /// <summary>
        /// Индефикационный номер сотрудника
        /// </summary>
        private uint id;
        #endregion
        #region Свойства (Properties)
        /// <summary>
        /// Свойство содержит имя работника
        /// </summary>
        public string FirstName
        {
            get { return this.fname; }
            set { this.fname = value; }
        }
        /// <summary>
        /// Свойство содержит фамилию работника
        /// </summary>
        public string SecondName
        {
            get { return this.sname; }
            set { this.sname = value; }
        }
        /// <summary>
        /// Свойство содержит возраст работника
        /// </summary>
        public ushort Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        /// <summary>
        /// Свойство содержит департамент в котором служит сотрудник
        /// </summary>
        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
        /// <summary>
        /// Свойство содержит размер зарплаты работника
        /// </summary>
        public float Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        /// <summary>
        /// Свойство содержит идентификационный номер работника
        /// </summary>
        public uint Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        #endregion
        #region Интерфейсы (Interfaces)
        /// <summary>
        /// Интерфейс для сортировки по полю Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Worker obj)
        {
            return this.Id.CompareTo(obj.Id);
            throw new ArgumentException("Параметр не Работник!");
        }



        #endregion

    }

    #region Структуры для сортировки (Structures for sorting)
    /// <summary>
    /// Обобщенный компаратор для сортировки по имени работника
    /// </summary>
    struct NameSort : IComparer<Worker>
    {
        public int Compare(Worker one, Worker two)
        {
            return String.Compare(one.FirstName, two.FirstName);
        }
    }
    /// <summary>
    /// Обобщенный компаратор для сортировки по фамилии работника
    /// </summary>
    struct SnameSort : IComparer<Worker>
    {
        public int Compare(Worker one, Worker two)
        {
            return String.Compare(one.SecondName, two.SecondName);
        }
    }
    /// <summary>
    /// Обобщенный компаратор для сортировки по возрасту работника
    /// </summary>
    struct AgeSort : IComparer<Worker>
    {
        public int Compare(Worker one, Worker two)
        {
            if (one.Age > two.Age)
                return 1;
            else if (one.Age < two.Age)
                return -1;
            else
                return 0;
        }
    }
    /// <summary>
    /// Обобщенный компаратор для сортировки по департаменту
    /// </summary>
    struct DepSort : IComparer<Worker>
    {
        public int Compare(Worker one, Worker two)
        {
            return String.Compare(one.Department, two.Department);
        }
    }
    /// <summary>
    /// Обобщенный компаратор для сортировки по зарплате работника
    /// </summary>
    struct SalarySort : IComparer<Worker>
    {
        public int Compare(Worker one, Worker two)
        {
            if (one.Salary > two.Salary)
                return 1;
            else if (one.Salary < two.Salary)
                return -1;
            else
                return 0;
        }
    }

}


#endregion
