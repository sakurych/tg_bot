using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.Data.SqlClient;
using System.Text;
using Telegram.Bot.Types.Enums;
using static tg_Bot_16._0._0.Client;


namespace tg_Bot_16._0._0
{
    class Program
    {
        private static int counter;
        private static String token { get; set; } = "5618027592:AAGOpbvZOBuP36MyAeL0Cr4dOi2e6v5B8Bs";
        protected static TelegramBotClient client;
        public static int check = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (e.Message.Text == "Отмена")
            {
                await client.SendTextMessageAsync(msg.Chat.Id, "Введите команду: ", replyMarkup: GetButtons());
            }
            else
            {
                switch (counter)
                {
                    case 1:
                        AddClient.GetNameClient(e);
                        counter = 2;
                        break;

                    case 2:
                        AddClient.GetSurnameClient(e);
                        counter = 3;
                        break;

                    case 3:
                        AddClient.GetCardClient(e);
                        counter = 4;
                        break;

                    case 4:
                        AddClient.GetPhoneClient(e);
                        counter = 0;
                        break;

                    case 5:
                        SearchClient.SearchPhone(e);
                        counter = 0;
                        break;

                    case 6:
                        ChangeById.Show(e);
                        if (check == 0)
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "Выберите, что хотите изменить", replyMarkup: GetButtonsForChanges());
                        }
                        else
                        {
                            check = 0;
                        }
                        counter = 0;
                        break;

                    case 7:
                        ChangeById.setName(e);
                        counter = 0;
                        break;

                    case 8:
                        ChangeById.setSurname(e);
                        counter = 0;
                        break;

                    case 9:
                        ChangeById.setStatus(e);
                        counter = 0;
                        break;

                    case 10:
                        ChangeById.setPhone(e);
                        counter = 0;
                        break;

                    case 11:
                        ChangeById.setComment(e);
                        counter = 0;
                        break;
                    case 0:
                        switch (msg.Text)
                        {
                            case "Добавить":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите Имя клиента");
                                counter = 1;
                                break;

                            case "Изменить":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите Id клиента, данные которого хотите изменить");
                                counter = 6;
                                break;

                            case "Поиск":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите номер телефона клиента");
                                counter = 5;
                                break;

                            case "Имя":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите новое имя клиента");
                                counter = 7;
                                break;

                            case "Фамилию":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите новую фамилию клиента");
                                counter = 8;
                                break;

                            case "Статус карты":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите новый статус карты клиента");
                                counter = 9;
                                break;

                            case "Номер телефона":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите новый номер телефона клиента");
                                counter = 10;
                                break;

                            case "Комментарий":
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите комментарий о клиенте");
                                counter = 11;
                                break;

                            default:
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введите команду: ", replyMarkup: GetButtons());
                                break;
                        }
                        break;
                }
            }
        }

        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Добавить" }, new KeyboardButton { Text = "Изменить" } },
                    new List<KeyboardButton> {new KeyboardButton { Text = "Поиск" } },
                }
            }; 
        }
        public static IReplyMarkup GetButtonsForChanges()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Имя" }, new KeyboardButton { Text = "Фамилию" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Номер телефона" }, new KeyboardButton { Text = "Статус карты" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Комментарий" } },

                }
            };
        }
    }
}
