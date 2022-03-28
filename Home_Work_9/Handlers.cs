using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
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
        public Handlers(TelegramBotClient _bot)
        {
            bot = _bot;
        }



        #endregion

        #region Поля (Fields)
        /// <summary>
        /// Внутреняя переменная хранит обьект который дает команды боту
        /// </summary>
        private BotCommands commands = new BotCommands(bot);
        /// <summary>
        /// Внутренее поле хранит ссылку на бота переданную через конструктор класса
        /// </summary>
        private static TelegramBotClient bot;

        #endregion

        #region Методы

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

        public void MessageListener(object sender, MessageEventArgs e)
        {
            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (bot == null) return;
            else
            {
                commands.ParseMessage(e.Message);
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