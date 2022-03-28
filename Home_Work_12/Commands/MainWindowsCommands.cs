using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Task_1
{
    /// <summary>
    /// В этом частичном классе реализованы команды для ViewModel
    /// </summary>
    internal partial class MainWindowViewModel : DependencyObject
    {
        #region Выбор пользователя(User Select)
        public ICommand UserSelectCommand { get; }
        private bool CanUserSelectCommand(object p) => true;
        private void OnUserSelectCommand(object p)
        {
            Random rnd = new Random();
            MainWindow MW = new MainWindow();
            ComboBox tmp = null;

            foreach (Window wnd in Application.Current.Windows)
            {
                
                if (wnd.Name == "ModalWin")
                {
                    if (wnd.FindName("CbUsers") != null)
                    {
                        tmp = (ComboBox)wnd.FindName("CbUsers");
                    }

                    wnd.Close();
                    
                }
            }

            if (MW.FindName("cbxAuthor") != null)
            {
                var tmp2 = (ComboBox) MW.FindName("cbxAuthor");
                tmp2.SelectedValue = tmp.SelectedValue.ToString();
            }

            if (MW.FindName("LboxClients") != null)
            {
                var tmp3 = (ListBox)MW.FindName("LboxClients");
                tmp3.SelectedIndex = rnd.Next(Clients.Count);
            }
            MW.Show();

        }
        #endregion

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
        private bool CanSaveClientCommand(object p) => CheckField();
        private void OnSaveClientCommand(object p)
        {
            Editable = true;
            PhoneEdit = true;
            SaveEnable = false;
            ListEnable = true;

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

            ((IManager)SelectedClient)?.Add(new Manager(), Clients);
            AddedClient = Clients.Last();
            Editable = false;
            PhoneEdit = false;
            SaveEnable = true;
            CanRemove = false;
            ListEnable = false;

            Clients[(int)SelectedIndex].Metadata = new ClientMetadata
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
            Clients.Remove(AddedClient);
        }

        #endregion

        #region Сортировка клиентов (Clients sorting)

        public ICommand ClientsSorting { get; }

        private bool CanClientsSorting(object p) => true;

        private void OnClientsSorting(object p)
        {
            ObservableCollection<Manager> sortList = new ObservableCollection<Manager>(
                Clients.OrderBy(_clients => _clients)
                );
            Clients.Clear();
            Clients = sortList;


        }


        #endregion

    }
}