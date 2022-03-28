using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Home_Work_10._5;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Home_Work_9._4
{
    /// <summary>
    /// Класс содержит список команд для бота
    /// </summary>
    public class BotCommands
    {
        #region Поля (Fields)

        /// <summary>
        /// Внутренняя переменная которая хранит ссылку на бот
        /// </summary>
        private static TelegramBotClient bot;
        /// <summary>
        /// Внутрення переменная хранит ссылку на список файлов загруженных пользователем
        /// </summary>
        private List<Message> cloud;

        #endregion

        #region Конструкторы (Constructors)
        /// <summary>
        /// Конструктор устанавливает ссылку на бота для внутреней переменной
        /// </summary>
        /// <param name="_bot"></param>

        public BotCommands(TelegramBotClient _bot, List<Message> _cloud)
        {
            bot = _bot;
            cloud = _cloud;
        }
        public BotCommands(TelegramBotClient _bot)
            : this(_bot, new List<Message>())
        { }


        #endregion

        #region Методы (Methods)
        /// <summary>
        /// Метод выводит список файлов загруженных пользователем в облако
        /// </summary>
        /// <param name="bot">Параметр принимает ссылку на бот</param>
        /// <param name="e">Параметр принимает ссылку на Список файлов загруженных пользователем в облако</param>
        public static async void showList(TelegramBotClient bot, List<Message> e)
        {

            for (int j = 0; j < e.Count; j++)
            {
                switch (e[j].Type)
                {
                    case MessageType.Photo:
                        {
                            await bot.SendTextMessageAsync(
                                chatId: e[j].Chat.Id,
                                text: e[j].Photo[e[j].Photo.GetLength(0) - 1].FileUniqueId,
                                replyMarkup: new InlineKeyboardMarkup(new[]
                                {
                                new[]
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        "Cкачать",
                                        "document")
                                },
                                }));

                            break;
                        }
                    case MessageType.Document:
                        {
                            await bot.SendTextMessageAsync(
                                chatId: e[j].Chat.Id,
                                text: e[j].Document.FileName,
                                replyMarkup: new InlineKeyboardMarkup(new[]
                                {
                                new[]
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        "Cкачать",
                                        "document")
                                },
                                }));
                            break;
                        }
                    case MessageType.Audio:
                        {
                            await bot.SendTextMessageAsync(
                                chatId: e[j].Chat.Id,
                                text: e[j].Audio.FileName,
                                replyMarkup: new InlineKeyboardMarkup(new[]
                                {
                                new[]
                                {
                                    InlineKeyboardButton.WithCallbackData(
                                        "Cкачать",
                                        "document")
                                },
                                }));
                            break;
                        }
                };
            }
        }

        /// <summary>
        /// Метод производит парсинг сообщения отправленного от пользоватебя бота
        /// </summary>
        /// <param name="e">Параметр принимает тип сообщения от бота</param>
        public void ParseMessage(Message e, MainWindow W)
        {
            //Создаем клавиатуру которую выводим в пригласительном сообщении
            var keys = new ReplyKeyboardMarkup(new[]
            {
                    new KeyboardButton[] {"Добавить файл в облако", "Загрузить файл из облака"}

                })
            {
                ResizeKeyboard = true
            };
            //Проверяем размер принимаегомо файла
            if (!CheckFileSize(e)) return;
            //В зависимости от типа принимаемого файла, добавляем его в облаго или выводим список
            //файлов облачного хранилища пользователя
            switch (e.Type)
            {
                case MessageType.Photo:
                    {

                        DownLoad(e.Photo[e.Photo.GetLength(0) - 1].FileId,
                            e.Photo[e.Photo.GetLength(0) - 1].FileUniqueId + ".jpg");
                        e.Photo[e.Photo.GetLength(0) - 1].FileUniqueId += $".jpg";
                        cloud.Add(e);
                        break;
                    }
                case (MessageType.Document):
                    {

                        DownLoad(e.Document.FileId, e.Document.FileName);
                        cloud.Add(e);
                        break;
                    }
                case MessageType.Audio:
                    {
                        DownLoad(e.Audio.FileId, e.Audio.FileName);
                        cloud.Add(e);
                        break;
                    }
                case MessageType.Text:
                    {
                        //Здесь происходит обработка текстовых команд боту
                        if (e.Text == null) return;
                        else if (e.Text == "/start")
                        {
                            bot.SendTextMessageAsync(
                                chatId: e.Chat.Id,
                                text: $"<b>Привет</b>, {e.Chat.FirstName}",
                                replyMarkup: keys,
                                parseMode: ParseMode.Html
                            );
                        }
                        else if (e.Text == "Добавить файл в облако")
                        {
                            bot.SendTextMessageAsync(
                                chatId: e.Chat.Id,
                                text: $"Отправьте ваш файл боту (размер не более 10мб)",
                                parseMode: ParseMode.Html
                            );
                        }
                        else if (e.Text == "Загрузить файл из облака")
                        {
                            showList(bot, cloud);
                        }
                        else
                        {
                            var tmp = new MessageLog();
                            tmp.FirstName = e.Chat.FirstName;
                            tmp.Id = e.Chat.Id;
                            tmp.Msg = e.Text;
                            tmp.Time = DateTime.Now.ToLongTimeString();
                            W.Dispatcher.Invoke(() =>
                            {
                                W.BotLogs.Add(tmp);
                            });

                        }

                        break;
                    }

            }



        }

        /// <summary>
        /// Метод загружает файл отправленный пользователем файлы на сервер
        /// </summary>
        /// <param name="fileId">Параметр FileId</param>
        /// <param name="path">Путы к файлу на сервере</param>
        static async void DownLoad(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream("_" + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }
        /// <summary>
        /// Внутренний метод для проверки размера загружаемого файла на сервер бота.
        /// </summary>
        /// <param name="e">Параметр принимает сообщение</param>
        /// <returns></returns>
        private bool CheckFileSize(Message e)
        {
            //Проверяем на NULL и пустую строку
            if (e.Text != string.Empty || e.Document != null || e.Photo != null || e.Audio != null)
            {
                switch (e.Type)
                {
                    case MessageType.Photo:
                    {
                        if (e.Photo.GetLength(0) - 1 > 10485760)
                        {
                            bot.SendTextMessageAsync(
                                chatId: e.Chat.Id,
                                text: $"<b>Ошибка!!</b>, файл не должен превышать 10 мб.",
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        break;
                    }
                    case MessageType.Document:
                    {
                        if (e.Document.FileSize > 10485760)
                        {
                            bot.SendTextMessageAsync(
                                chatId: e.Chat.Id,
                                text: $"<b>Ошибка!!</b>, файл не должен превышать 10 мб.",
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        break;
                    }
                    case MessageType.Audio:
                    {
                        if (e.Audio.FileSize > 10485760)
                        {
                            bot.SendTextMessageAsync(
                                chatId: e.Chat.Id,
                                text: $"<b>Ошибка!!</b>, файл не должен превышать 10 мб.",
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        break;
                    }
                }

            }


            return true;

        }


        #endregion


    }
}