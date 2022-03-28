using System.Collections.Generic;
using Home_Work_9._4;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Home_Work_10._5
{

    public class BotServer
    {
        #region Поля (Fields)

        //Клиент для телеграм бота
        private TelegramBotClient bot;
        //Поле хранит лог текстовых сообщений бота
        public List<Message> cloud;
        //Поле класса для управления событиями бота
        private Handlers handle;
        //Поле класса для управления командами бота
        private BotCommands commands;
        //Поле для передачи параметров главному окну


        #endregion

        #region Конструкторы (Constructors)

        public BotServer(MainWindow w, string token = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@")
        {
            this.bot = new TelegramBotClient(token);
            this.handle = new Handlers(bot, w);
            this.cloud = new List<Message>();
            this.commands = new BotCommands(bot, cloud);
        }

        #endregion

        #region Методы (Methods)

        /// <summary>
        /// Главный метод класса. Выполняет запуск бота
        /// </summary>
        public void StartBot()
        {
            bot.OnMessage += handle.MessageListener;
            bot.OnCallbackQuery += handle.OnDownlodQueryReceived;
            bot.StartReceiving();

        }
        /// <summary>
        /// Метод для отправки сообщения выбранному пользователю бота
        /// </summary>
        /// <param name="Text">Текст сообщения</param>
        /// <param name="Id">ИД пользователя бота</param>
        public void SendMessage(string Text, string Id)
        {

            bot.SendTextMessageAsync(Id, Text);
        }

        #endregion



    }

}
