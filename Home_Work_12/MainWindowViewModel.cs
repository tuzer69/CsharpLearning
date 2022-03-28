using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using Microsoft.VisualBasic.FileIO;

namespace Task_1
{
    internal partial class MainWindowViewModel : DependencyObject
    {
        #region Поля(Fields)

        public static readonly DependencyProperty SelectedClientProperty;

        public static readonly DependencyProperty EditableProperty;

        public static readonly DependencyProperty AuthorProperty;

        public static readonly DependencyProperty PhoneEditProperty;

        public static readonly DependencyProperty SaveProperty;

        public static readonly DependencyProperty AddedClientProperty;

        public static readonly DependencyProperty CandRemoveProperty;

        public static readonly DependencyProperty ListEnableProperty;
        
        public static readonly DependencyProperty ClientsProperty;

        private uint _selectedIndex;

        private readonly ObservableCollection<string> _users;

        #endregion

        #region Metadata Methods

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            MainWindowViewModel tmp = (MainWindowViewModel) d;
            tmp.Editable = true;
            tmp.PhoneEdit = true;
            tmp.SaveEnable = false;

            if (tmp.Author == "Консультант")
            {
                var client = ((Consultant) baseValue).Clone() as Consultant;
                client.PassNum = "***  ***";
                client.PassSerie = "**  **";
                return client;
            }
            else
            {
                tmp.CanRemove = true;
                var client = ((Manager) baseValue).Clone() as Manager;
                return client;
            }
        }

        private static object CorrectEditable(DependencyObject d, object baseValue)
        {
            MainWindowViewModel tmp = (MainWindowViewModel)d;
            return baseValue;
        }

        private static object CorrectAutor(DependencyObject d, object baseValue)
        {
            MainWindowViewModel tmp = (MainWindowViewModel)d;
            tmp.Editable = true;
            tmp.PhoneEdit = true;
            if (baseValue is "Менеджер" and not null)
            {
                tmp.CanRemove = true;
                tmp.SaveEnable = false;

            }
            else
            {

                tmp.CanRemove = false;
                tmp.SaveEnable = false;
            }

            return baseValue;
        }

        private static object CorrectPhone(DependencyObject d, object baseValue)
        {
            MainWindowViewModel tmp = (MainWindowViewModel)d;

            return baseValue;
        }

        private static object CorrectSave(DependencyObject d, object baseValue)
        {
            return baseValue;
        }


        private static bool ValidateValue(object value) => true;

        #endregion

        #region Конструкторы(Constructors)

        public MainWindowViewModel()
        {
            //Команды
            EditClientCommand = new RelayCommand(OnEditClientCommand, CanEditClientCommand);
            SaveClientCommand = new RelayCommand(OnSaveClientCommand, CanSaveClientCommand);
            AddClientCommand = new RelayCommand(OnAddClientCommand, CanAddClientCommand);
            RemoveClientCommand = new RelayCommand(OnRemoveClientCommand, CanRemoveClientCommand);
            ClientsSorting = new RelayCommand(OnClientsSorting, CanClientsSorting);
            UserSelectCommand = new RelayCommand(OnUserSelectCommand, CanUserSelectCommand);

            this.ListEnable = true;
            this.CanRemove = false;
            this.Editable = true;
            this.PhoneEdit = true;
            this.Clients = new ObservableCollection<Manager>();
            this._users = new ObservableCollection<string>();
            this.SelectedClient = new();

            //Добавляем клиентов в ListBox
            Clients.Add(new Manager("Короткова", "Альбина", "Ивановна", 89345624572, "3452", "432456"));
            Clients.Add(new Manager("Симонов", "Степан", "Ильич", 89332624522, "4567", "692064"));
            Clients.Add(new Manager("Тихомиров", "Максим", "Степанович", 89322524235, "4227", "612064"));
            Clients.Add(new Manager("Журавлев", "Владислав", "Матвеевич", 89435674842, "2537", "452474"));
            Clients.Add(new Manager("Мальцева", "Анна", "Вадимовна", 89565872812, "3557", "452448"));
            Clients.Add(new Manager("Данилов", "Андрей", "Александрович", 89375532292, "3583", "242843"));
            Clients.Add(new Manager("Лебедева", "Зоя", "Данииловна", 89475232193, "3343", "261721"));
            Clients.Add(new Manager("Суслов", "Игорь", "Богданович", 89435223242, "3122", "544585"));
            Clients.Add(new Manager("Рыбаков", "Константин", "Платонович", 89673133892, "4374", "341385"));
            Clients.Add(new Manager("Ермакова", "Дарья", "Павловна", 89435131212, "3563", "353623"));
            
            //Добавляем пользователей
            _users.Add("Менеджер");
            _users.Add("Консультант");

            
        }

        static MainWindowViewModel()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectValue),
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataAutor = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectEditable),
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataEditable = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectAutor),
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataPhoneEdit = new FrameworkPropertyMetadata()
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectPhone),
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataSave = new FrameworkPropertyMetadata()
            {
                CoerceValueCallback = new CoerceValueCallback(CorrectSave),
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadaAddedClient = new FrameworkPropertyMetadata
            {
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataCanRemove = new FrameworkPropertyMetadata
            {
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataListEnable = new FrameworkPropertyMetadata
            {
                AffectsMeasure = true,
                AffectsRender = true
            };

            FrameworkPropertyMetadata metadataClietns = new FrameworkPropertyMetadata
            {
                AffectsMeasure = true,
                AffectsRender = true
            };

            ClientsProperty = DependencyProperty.Register(
                "Clients",
                typeof(ObservableCollection<Manager>),
                typeof(MainWindowViewModel),
                metadataClietns,
                new ValidateValueCallback(ValidateValue));

            ListEnableProperty = DependencyProperty.Register(
                "ListEnable",
                typeof(bool),
                typeof(MainWindowViewModel),
                metadataListEnable,
                new ValidateValueCallback(ValidateValue));

            CandRemoveProperty = DependencyProperty.Register(
                "CanRemove",
                typeof(bool),
                typeof(MainWindowViewModel),
                metadataCanRemove,
                new ValidateValueCallback(ValidateValue));

            SelectedClientProperty = DependencyProperty.Register(
                "SelectedClient", 
                typeof(Manager),
                typeof(MainWindowViewModel), 
                metadata, new ValidateValueCallback(ValidateValue));
       
            EditableProperty = DependencyProperty.Register(
                "Editable", typeof(bool),
                typeof(MainWindowViewModel),
                metadataAutor, 
                new ValidateValueCallback(ValidateValue));
            
            AuthorProperty = DependencyProperty.Register(
                "Author", typeof(string),
                typeof(MainWindowViewModel),
                metadataEditable,
                new ValidateValueCallback(ValidateValue));

            PhoneEditProperty = DependencyProperty.Register(
                "PhoneEdit",
                typeof(bool),
                typeof(MainWindowViewModel),
                metadataPhoneEdit,
                new ValidateValueCallback(ValidateValue));

            SaveProperty = DependencyProperty.Register(
                "SaveEnable",
                typeof(bool),
                typeof(MainWindowViewModel),
                metadataSave,
                new ValidateValueCallback(ValidateValue));

            AddedClientProperty = DependencyProperty.Register(
                "AddedClient",
                typeof(Manager),
                typeof(MainWindowViewModel),
                metadaAddedClient,
                new ValidateValueCallback(ValidateValue));

    }

    #endregion

        #region Свойства

        public ObservableCollection<string> Users => _users;

        public ObservableCollection<Manager> Clients
        {
            get => (ObservableCollection<Manager>)GetValue(ClientsProperty);
            set => SetValue(ClientsProperty, value);
        }

        public Manager SelectedClient
        {
            get => (Manager) GetValue(SelectedClientProperty);
            set => SetValue(SelectedClientProperty, value);
        }

        public uint SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                SelectedClient = Clients[(int) SelectedIndex];
            }
        }

        public string Author
        {
            get => (string) GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }

        public bool Editable
        {
            get => (bool) GetValue(EditableProperty);
            set => SetValue(EditableProperty, value);
        }

        public bool PhoneEdit
        {
            get => (bool) GetValue(PhoneEditProperty);
            set => SetValue(PhoneEditProperty, value);
        }

        public bool SaveEnable
        {
            get => (bool)GetValue(SaveProperty);
            set => SetValue(SaveProperty, value);

        }

        public Manager AddedClient
        {
            get => (Manager) GetValue(AddedClientProperty);
            set => SetValue(AddedClientProperty, value);
        }

        public bool CanRemove
        {
            get => (bool) GetValue(CandRemoveProperty);
            set => SetValue(CandRemoveProperty, value);
        }

        public bool ListEnable 
        {
            get => (bool)GetValue(ListEnableProperty);
            set => SetValue(ListEnableProperty, value);
        }


        #endregion

        #region Методы(Methods)

        private bool CheckField()
        {
            if (String.IsNullOrEmpty(SelectedClient.FirstName) ||
                String.IsNullOrEmpty(SelectedClient.SecondName) ||
                String.IsNullOrEmpty(SelectedClient.MiddleName) ||
                SelectedClient.Phone.ToString().Length != 11 ||
                String.IsNullOrEmpty(SelectedClient.PassNum) ||
                String.IsNullOrEmpty(SelectedClient.PassSerie))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion

    }
}