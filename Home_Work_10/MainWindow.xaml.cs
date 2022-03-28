using System;
using Home_Work_9._4;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;

namespace Home_Work_10._5
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Поле содержит ссылку на обьект бота управляемого приложением
        /// </summary>
        private BotServer TeleBot;
        /// <summary>
        /// Свойство для хранениея коллекции сообщений
        /// </summary>
        public ObservableCollection<MessageLog> BotLogs { get; set; }
        public MainWindow()
        {

            InitializeComponent();
            //Инициализация
            TeleBot = new BotServer(this);
            BotLogs = new ObservableCollection<MessageLog>();
            logList.ItemsSource = BotLogs;

            //Запускаем сервер бота в фоне
            TeleBot.StartBot();
            
        }

        #region Методы (Methods)

        /// <summary>
        /// Метод для отправки сообщения выбранному пользователю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMsgSendClick(object sender, RoutedEventArgs e)
        {//Проверяем что параметр Id не пустой
            if (TargetSend.Text != "")
            {
                TeleBot.SendMessage(txtMsgSend.Text, TargetSend.Text);
            }
            else
            {
                lblNotification.Foreground = Brushes.Red;
                lblNotification.Content = $"Выберите пользоватебя которому\nхотите отправить сообщение";
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие по кнопке "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            
            if (txtMsgSend.Text == "")
            {
                lblNotification.Foreground = Brushes.Red;
                lblNotification.Content = "Введите название файла!";
            }
            else
            {
                string json = JsonConvert.SerializeObject(BotLogs);
                File.WriteAllText($"{txtMsgSend.Text}.json", json, Encoding.UTF8);
                lblNotification.Foreground = Brushes.Green;
                lblNotification.Content = "Файл сохранен.";
            }
        }
        /// <summary>
        /// Метод вызыватся при изменении текстового поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMsgSend_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblNotification.Content = "";
        }


        #endregion
    }
}
