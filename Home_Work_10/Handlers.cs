using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Home_Work_10._5;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Home_Work_9._4
{
    /// <summary>
    /// Класс сорержит методы облаботчики событий для бота. А также вспмогательные функции
    /// </summary>
    public class Handlers
    {
        #region Конструкторы (Constructors)
        /// <summary>
        /// Конструктор задает переданную ссылку на клиент телеграм бота
        /// </summary>
        /// <param name="_bot"></param>
        public Handlers(TelegramBotClient _bot, MainWindow _W)
        {
            bot = _bot;
            W = _W;
            commands = new BotCommands(bot);
        }
        public Handlers(TelegramBotClient _bot)
        {
            bot = _bot;
            commands = new BotCommands(bot);
        }



        #endregion

        #region Поля (Fields)
        /// <summary>
        /// Внутреняя переменная хранит обьект который дает команды боту
        /// </summary>
        private BotCommands commands;
        /// <summary>
        /// Внутренее поле хранит ссылку на бота переданную через конструктор класса
        /// </summary>
        private TelegramBotClient bot;
        /// <summary>
        /// Поле хранит ссылку на главное окно уплавления ботом
        /// </summary>
        private MainWindow W;

        #endregion

        #region Методы
        /// <summary>
        /// Метод обрабатывает запроспользователя на загрузки файла из облака
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void OnDownlodQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            switch (e.CallbackQuery.Data)
            {
                case "document":
                {
                    UploadFile(e);
                    break;
                }
            }


        }
        /// <summary>
        /// Метод обработки поступающий сообщений от бота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MessageListener(object sender, MessageEventArgs e)
        {

            if (bot == null) return;
            else
            {
                commands.ParseMessage(e.Message, W);
            }
        }
        /// <summary>
        /// Внутренний метод, предназначен для отдачи пользователю его файла который храниться в облаке
        /// </summary>
        /// <param name="e">Параметр принимет коллбэк от нажатой инлайн клавиши</param>
        private async void UploadFile(CallbackQueryEventArgs e)
        {
            using (FileStream fs = new FileStream("_" + e.CallbackQuery.Message.Text,
                FileMode.Open))
            {
                await bot.SendDocumentAsync(
                    e.CallbackQuery.Message.Chat.Id,
                    new InputOnlineFile(fs, e.CallbackQuery.Message.Text));

            }
        }
        #endregion



    }
}