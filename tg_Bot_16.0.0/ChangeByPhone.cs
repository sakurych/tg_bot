using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;
using static tg_Bot_16._0._0.Client;


namespace tg_Bot_16._0._0
{
    class ChangeById:Program
    {
        public static List<string> clientList;
        static Client client_ = new Client();
        public static string id = "";
        public static void Show(MessageEventArgs Id)
        {
            var msgSearchPhone_ = Id.Message;
            id = Id.Message.Text;
            dbCommands db_commands = new dbCommands();
            clientList = db_commands.searchClientById(id, msgSearchPhone_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(msgSearchPhone_.Chat.Id, "Клиент не найден!", replyMarkup: GetButtons());
                check = 1;
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(msgSearchPhone_.Chat.Id, $"Текущие данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }

        public static void setName(MessageEventArgs Name)
        {
            var Name_ = Name.Message;
            string msg = Name.Message.Text;
            dbCommands db_commands = new dbCommands();
            db_commands.setNewName(msg, id);
            db_commands.searchClientByPhone(id, Name_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(Name_.Chat.Id, "Клиент не найден!");
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(Name_.Chat.Id, $"Обновленные данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }
        public static void setSurname(MessageEventArgs Surname)
        {
            var Surname_ = Surname.Message;
            string msg = Surname.Message.Text;
            dbCommands db_commands = new dbCommands();
            db_commands.setNewSurname(msg, id);
            db_commands.searchClientByPhone(id, Surname_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(Surname_.Chat.Id, "Клиент не найден!");
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(Surname_.Chat.Id, $"Обновленные данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }

        public static void setStatus(MessageEventArgs Status)
        {
            var Status_ = Status.Message;
            string msg = Status.Message.Text;
            dbCommands db_commands = new dbCommands();
            db_commands.setNewStatus(msg, id);
            db_commands.searchClientByPhone(id, Status_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(Status_.Chat.Id, "Клиент не найден!");
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(Status_.Chat.Id, $"Обновленные данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }

        public static void setPhone(MessageEventArgs Phone)
        {
            var Phone_ = Phone.Message;
            string msg = Phone.Message.Text;
            dbCommands db_commands = new dbCommands();
            db_commands.setNewPhone(msg, id);
            db_commands.searchClientByPhone(id, Phone_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(Phone_.Chat.Id, "Клиент не найден!");
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(Phone_.Chat.Id, $"Обновленные данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }

        public static void setComment(MessageEventArgs Comment)
        {
            var Comment_ = Comment.Message;
            string msg = Comment.Message.Text;
            dbCommands db_commands = new dbCommands();
            db_commands.setNewComment(msg, id);
            db_commands.searchClientByPhone(id, Comment_);
            if (clientList.Count == 0)
            {
                client.SendTextMessageAsync(Comment_.Chat.Id, "Клиент не найден!");
            }
            else
            {
                client_.setName(clientList[0]);
                client_.setSurname(clientList[1]);
                client_.setPhone(clientList[2]);
                client_.setStatus(clientList[3]);
                client_.setComment(clientList[4]);
                client_.setId(clientList[5]);
                client.SendTextMessageAsync(Comment_.Chat.Id, $"Обновленные данные клиента\nID клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
            }
        }
    }
}
