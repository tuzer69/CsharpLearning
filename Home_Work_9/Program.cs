using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telegram.Bot;
using Telegram.Bot.Types;
using Home_Work_10._5;

namespace Home_Work_9._4
{
    public class BotServer
    {
        //Клиент для телеграм бота
        private static TelegramBotClient bot;
        //Поле хранит лог текстовых сообщений бота
        public static ObservableCollection<MessageLog> BotLogs;
        //Поле список загруженных файлов пользователем в облако
        public static List<Message> cloud;
        //Поле класса для управления событиями бота
        private static Handlers handle;
        //Поле класса для управления командами бота
        private static BotCommands commands;



        public static void Main()
        {
            //Токен для управления ботом
            string token = "2082412653:AAG_yiY2mQ2JOMXqw-eszNKvu4YYDwFM7jc";
            bot = new TelegramBotClient(token);
            handle = new Handlers(bot);
            cloud = new List<Message>();
            commands = new BotCommands(bot);
            BotLogs = new ObservableCollection<MessageLog>();
            bot.OnMessage += handle.MessageListener;
            bot.OnCallbackQuery += handle.OnDownlodQueryReceived;
            bot.StartReceiving();

        }



    }

}
