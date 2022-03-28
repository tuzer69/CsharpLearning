using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Task_1
{
    internal class MainWindowViewModel : DependencyObject
    {
        #region Поля(Fields)

        public static readonly DependencyProperty SelectedClientProperty;

        public static readonly DependencyProperty EditableProperty;

        public static readonly DependencyProperty AuthorProperty;

        public static readonly DependencyProperty PhoneEditProperty;

        public static readonly DependencyProperty SaveProperty;

        public static readonly DependencyProperty AddedClientProperty;

        public static readonly DependencyProperty CandRemoveProperty;

        private ObservableCollection<Manager> _clients;

        private uint _selectedIndex;

        private readonly ObservableCollection<string> _users;

        #endregion

        #region Metadata Methods

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            MainWindowViewModel tmp = (MainWindowViewModel)d;
            tmp.Editable = true;
            tmp.PhoneEdit = true;
            tmp.SaveEnable = false;

            if (tmp.Author == "Консультант")
            {
                var client = ((Consultant)baseValue).Clone() as Consultant;
                client.PassNum = "***  ***";
                client.PassSerie = "**  **";
                return client;
            }
            else
            {
                tmp.CanRemove = true;
                var client = ((Manager)baseValue).Clone() as Manager;

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


        private static bool ValidateValue(object value)
        {
            return true;
        }

        #endregion

        #region Конструкторы(Constructors)

        public MainWindowViewModel()
        {
            EditClientCommand = new RelayCommand(OnEditClientCommand, CanEditClientCommand);
            SaveClientCommand = new RelayCommand(OnSaveClientCommand, CanSaveClientCommand);
            AddClientCommand = new RelayCommand(OnAddClientCommand, CanAddClientCommand);
            RemoveClientCommand = new RelayCommand(OnRemoveClientCommand, CanRemoveClientCommand);

            this.CanRemove = false;
            this.Editable = true;
            this.PhoneEdit = true;
            this._clients = new ObservableCollection<Manager>();
            this._users = new ObservableCollection<string>();
            this.SelectedClient = new();

            _clients.Add(new Manager("Короткова", "Альбина", "Ивановна", 89345624572, "3452", "432456"));
            _clients.Add(new Manager("Симонов", "Степан", "Ильич", 89332624522, "4567", "692064"));
            _clients.Add(new Manager("Тихомиров", "Максим", "Степанович", 89322524235, "4227", "612064"));
            _clients.Add(new Manager("Журавлев", "Владислав", "Матвеевич", 89435674842, "2537", "452474"));
            _clients.Add(new Manager("Мальцева", "Анна", "Вадимовна", 89565872812, "3557", "452448"));
            _clients.Add(new Manager("Данилов", "Андрей", "Александрович", 89375532292, "3583", "242843"));
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
            get => _clients;
            set => _clients = value;
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
                SelectedClient = _clients[(int) SelectedIndex];
            }
        }

        public string Author
        {
            get => (string) GetValue(AuthorProperty);
            set => SetValue(EditableProperty, value);
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


        #endregion

        #region Команды(Commands)

        #region Изменить(Edit)

        public ICommand EditClientCommand { get; }

        private bool CanEditClientCommand(object p)
        {
            if (SaveEnable) return false;
            else return true;
        }

        private void OnEditClientCommand(object p)
        {
            if (Author == "Консультант") PhoneEdit = false;
            else
            {
                Editable = false;
                PhoneEdit = false;
                CanRemove = false;
            }

            SaveEnable = true;
        }

        #endregion

        #region Сохранить(Save)

        public ICommand SaveClientCommand { get; }
        private bool CanSaveClientCommand(object p) => true;
        private void OnSaveClientCommand(object p)
        {
            Editable = true;
            PhoneEdit = true;
            SaveEnable = false;
            
            if (Author == "Консультант")
            {

                ((IConsultant)SelectedClient)?.Save(SelectedClient, Clients, (int)SelectedIndex);
            }
            else
            {
                CanRemove = true;
                ((IManager)SelectedClient)?.Save(SelectedClient, Clients, (int)SelectedIndex);
            }

        }

        #endregion

        #region Добавить(Add)

        public ICommand AddClientCommand { get; }
        private bool CanAddClientCommand(object p)
        {
            if (SaveEnable) return false;
            else if (Author == "Консультант") return false;
            else return true;
        }
        private void OnAddClientCommand(object p)
        {

            ((IManager)SelectedClient)?.Add(new Manager(), _clients);
            AddedClient =_clients.Last();
            Editable = false;
            PhoneEdit = false;
            SaveEnable = true;
            CanRemove = false;

            _clients[(int)SelectedIndex].Metadata = new ClientMetadata
            {
                TypeEdit = "Добавление",
                DataTimeEdit = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                AutorEdit = "Менеджер"
            };
        }

        #endregion

        #region Удалить(Remove)

        public ICommand RemoveClientCommand { get; }
        private bool CanRemoveClientCommand(object p) => true;

        private void OnRemoveClientCommand(object p)
        {
            _clients.Remove(AddedClient);
        }

        #endregion



        #endregion

        #region Методы(Methods)


        #endregion

    }
}