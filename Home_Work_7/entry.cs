using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Home_Work_7._8
{
    public struct Entry
    {
        #region Поля
        /// <summary>
        /// Поле хранит дату создания заметки
        /// </summary>
        private DateTime createDate;
        /// <summary>
        /// Поле хранит имя автора заметки
        /// </summary>
        private string autor;
        /// <summary>
        /// Поле заметки или примечание
        /// </summary>
        private string notes;
        /// <summary>
        /// Поле хранит список дел заметки
        /// </summary>
        private string todo;
        /// <summary>
        /// Поле хранит лист желаний заметки
        /// </summary>
        private string wishList;

        #endregion
        
        #region Конструкторы

        /// <summary>
        /// Основлной конструктор
        /// </summary>
        /// <param name="autor">Имя автора</param>
        /// <param name="notes">Заметка</param>
        /// <param name="todo">Сипсок дел</param>
        /// <param name="wishList">Список желаний</param>
        /// <param name="createDate">Дата создания заметки</param>
        public Entry(string autor, string notes, string todo, string wishList, DateTime createDate) : this()
        {
            Autor = autor;
            Notes = notes;
            Todo = todo;
            WishList = wishList;
            CreateDate = DateTime.Today;
        }

        public Entry(string autor, string notes, DateTime createDate) :
            this(autor, notes, "Список дел", "Список желаний", createDate)
        {
        }

        public Entry(string autor, string notes, string todo) :
            this(autor, notes, todo, "Список желаний", DateTime.Now)
        {
        }

        public Entry(string autor, string notes) :
            this(autor, notes, "Список дел", "Список желаний", DateTime.Now)
        {
        }

        public Entry(string autor) :
            this(autor, "Notes", "Список дел", "Список желаний", DateTime.Now)
        {
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство хранит дату создания заметки
        /// </summary>
        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }
        /// <summary>
        /// Свойство хранит имя автора заметки
        /// </summary>
        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }
        /// <summary>
        /// Свойство хранит заметку
        /// </summary>
        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }
        /// <summary>
        /// Свойство хранит список дел
        /// </summary>
        public string Todo
        {
            get { return this.todo; }
            set { todo = value; }
        }
        /// <summary>
        /// Cвойство хранит лист желаний
        /// </summary>
        public string WishList
        {
            get { return wishList; }
            set { wishList = value; }
            }
        }



        #endregion

    
}