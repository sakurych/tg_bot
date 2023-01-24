////using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using static tg_Bot_16._0._0.Client;

namespace tg_Bot_16._0._0
{

    class AddClient : Program
    {
        private static string name;
        private static string surname;
        private static string status;
        private static string number;
        public static void GetNameClient(MessageEventArgs Name)
        {
            var msgAddName = Name.Message;
            name = msgAddName.Text;
            client.SendTextMessageAsync(msgAddName.Chat.Id, "Введите Фамилию клиента");
        }
        public static void GetSurnameClient(MessageEventArgs Surname)
        {
            var msgAddSurname = Surname.Message;
            surname = msgAddSurname.Text;
            client.SendTextMessageAsync(msgAddSurname.Chat.Id, "Введите статус клиента");
        }
        public static void GetCardClient(MessageEventArgs Status)
        {
            var msgAddStatus = Status.Message;
            status = msgAddStatus.Text;
            client.SendTextMessageAsync(msgAddStatus.Chat.Id, "Введите номер телефона клинета");
        }
        public static void GetPhoneClient(MessageEventArgs Phone)
        {
            var msgAddPhone = Phone.Message;
            number = msgAddPhone.Text;
            ResultInfo(Phone);
        }
        private static void ResultInfo(MessageEventArgs Phone)
        {
            var msgAddName = Phone.Message;
            client.SendTextMessageAsync(msgAddName.Chat.Id, $"Клиент добавлен!!!\nИмя - {name}\nФамилия - {surname}\nСтатус карты - {status}\nНомер телефона - {number}");
            dbCommands dbCommands = new dbCommands();
            dbCommands.addClient(name, surname, number, status);
        }
    }
}
