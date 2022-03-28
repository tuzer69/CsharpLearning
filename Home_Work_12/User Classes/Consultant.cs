using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Task_1
{
    public class Consultant : ICloneable, IConsultant, IComparable<Consultant>
    {
        #region Поля(Fields)

        protected string _firstName;

        protected string _secondName;

        protected string _middleName;

        protected long _phone;

        protected string _passSerie;

        protected string _passNum;

        protected ClientMetadata _metadata;

        #endregion

        #region Конструктор(Constructor)

        public Consultant(string firstName, string secondName, string middleName, long phone, string passSerie,
            string passNum, bool isChanged = false)
        {
            _firstName = firstName;
            _secondName = secondName;
            _middleName = middleName;
            _passNum = passNum;
            _passSerie = passSerie;
            _phone = phone;
            _metadata = new ClientMetadata();
        }

        public Consultant()
        {
        }

        #endregion

        #region Свойства(Properties)

        public virtual string PassSerie
        {
            get => _passSerie;
            set
            {
                if (Equals(_passSerie, value)) return;
                _passSerie = value;
            }
        }

        public virtual string PassNum
        {
            get => _passNum;
            set
            {
                if (Equals(_passNum, value)) return;
                _passNum = value;
            }
        }

        public virtual long Phone
        {
            get => _phone;
            set
            {
                if (Equals(_phone, value)) return;
                else if (value.ToString().Length != 11) return;
                _phone = value;
            }
        }

        public virtual string FirstName
        {
            get => _firstName;
            set
            {
                if (Equals(_firstName, value)) return;
                _firstName = value;
            }
        }

        public virtual string SecondName
        {
            get => _secondName;
            set
            {
                if (Equals(_secondName, value)) return;
                _secondName = value;
            }
        }

        public virtual string MiddleName
        {
            get => _middleName;
            set
            {
                if (Equals(_middleName, value)) return;
                _middleName = value;
            }
        }

        public virtual ClientMetadata Metadata
        {
            get => _metadata;
            set
            {
                if (Equals(_metadata, value)) return;
                _metadata = value;
            }
        }


        #endregion

        #region Методы(Methods)


        #endregion

        #region Интерфейсы(Interfeces)

        public virtual object Clone()
        {
            
            Consultant cl = (Consultant)this.MemberwiseClone();
            ClientMetadata meta = new ClientMetadata
            {
                TypeEdit = this?._metadata?.TypeEdit,
                AutorEdit = this?._metadata?.AutorEdit,
                DataChange = this?._metadata?.DataChange,
                DataTimeEdit = this?._metadata?.DataTimeEdit
            };
            cl.Metadata = meta;

            return cl;
        }
        public void Save(Consultant client, object clients, int index)
        {
             
             var collection = (ObservableCollection<Manager>)clients;
            if (collection[index].Phone == client.Phone) return;
            client.Phone = client.Phone;
            client.Metadata.DataTimeEdit = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            client.Metadata.DataChange = "Teлефон";
            client.Metadata.TypeEdit = "Редактирование";
            client.Metadata.AutorEdit = "Консультант";

            collection[index] = (Manager)client;

        }

        public int CompareTo(Consultant obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Обьект не существует");
            }
    
            return this.FirstName.CompareTo(obj.FirstName);
        }


        #endregion

    }

}