using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Windows.Documents;

namespace Task_1
{
    public class Manager : Consultant, ICloneable, IManager

    {
        #region Поля(Fields)

        #endregion
        
        #region Конструктор(Constructor)

        public Manager(string firstName, string secondName, string middleName, long phone, string passSerie, string passNum) 
            : base(firstName, secondName, middleName, phone, passSerie, passNum)
        { }

        public Manager()
        {

        }

        #endregion

        #region Свойства(Properties)

        #endregion

        #region Методы(Methods)


        #endregion

        #region Интерфейсы(Interfeces)

        public void Save(Manager client, object clients, int index)
        {
            Manager tmpClient = (Manager)client.Clone();
            string tmpDataChange = "";
            var collection = (ObservableCollection<Manager>)clients;
            client.Metadata.DataTimeEdit = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            client.Metadata.AutorEdit = "Менеджер";
            client.Metadata.TypeEdit = "Изменение";

            if (collection[index].FirstName != client.FirstName && client.FirstName != null)
                tmpDataChange += "Имя ";
            if (collection[index].SecondName != client.SecondName && client.SecondName != null)
                tmpDataChange += "Фамилия ";
            if (collection[index].MiddleName != client.MiddleName && client.MiddleName != null)
                tmpDataChange += "Отчество ";
            if (collection[index].Phone != client.Phone)
                tmpDataChange += "Телефон ";
            if (collection[index].PassSerie != client.PassSerie && client.PassSerie != null)
                tmpDataChange += "Серия ";
            if (collection[index].PassNum != client.PassNum && client.PassNum != null)
                tmpDataChange += "Номер ";
            client.Metadata.DataChange = tmpDataChange;

            collection[index] = client;





        }

        public void Add(Manager client, object clients)
        {
            var collection = (ObservableCollection<Manager>)clients;
            client.FirstName = "Имя";
            client.SecondName = "Фамилия";
            collection.Add(client);
        }


        #endregion

    }

}