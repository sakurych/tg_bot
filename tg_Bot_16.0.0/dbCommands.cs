using Microsoft.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using static tg_Bot_16._0._0.Client;
using static tg_Bot_16._0._0.DataBase;
using static tg_Bot_16._0._0.SearchClient;
using Telegram.Bot.Args;

namespace tg_Bot_16._0._0
{
    class dbCommands:Program
    {
        public void addClient(string name_, string surname_, string phone_, string status_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            Client client = new Client(name_, surname_, phone_, status_);

            SqlCommand command = new SqlCommand("INSERT INTO [Table] (Name, Surname, Phone," +
            "Status)" +
            "VALUES (@Name, @Surname, @Phone, @Status)", db.sqlConnection);

            command.Parameters.AddWithValue("Name", client.getName());
            command.Parameters.AddWithValue("Surname", client.getSurname());
            command.Parameters.AddWithValue("Phone", client.getPhone());
            command.Parameters.AddWithValue("Status", client.getStatus());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();
        }

        public List<string> searchClientById(string Id, Telegram.Bot.Types.Message message)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();

            List<string> clientList = new List<string>();
            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id=@Id", db.sqlConnection);
            command.Parameters.AddWithValue("Id", Id);

            SqlDataReader res = command.ExecuteReader();

            if (res.HasRows)
            {
                while (res.Read())
                {
                    clientList.Add(res["Name"].ToString());
                    clientList.Add(res["Surname"].ToString());
                    clientList.Add(res["Phone"].ToString());
                    clientList.Add(res["Status"].ToString());
                    clientList.Add(res["Comment"].ToString());
                    clientList.Add(res["Id"].ToString());
                }
            }
            db.sqlConnection.Close();
            return clientList;
        }
        public List<string> searchClientByPhone(string phone_, Telegram.Bot.Types.Message message)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();

            List<string> clientList = new List<string>();
            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Phone=@Phone", db.sqlConnection);
            command.Parameters.AddWithValue("Phone", phone_);

            SqlDataReader res = command.ExecuteReader();

            if (res.HasRows)
            {
                while (res.Read())
                {
                    clientList.Add(res["Name"].ToString());
                    clientList.Add(res["Surname"].ToString());
                    clientList.Add(phone_);
                    clientList.Add(res["Status"].ToString());
                    clientList.Add(res["Comment"].ToString());
                    clientList.Add(res["Id"].ToString());
                    Client client_ = new Client();
                    client_.setName(clientList[0]);
                    client_.setSurname(clientList[1]);
                    client_.setPhone(clientList[2]);
                    client_.setStatus(clientList[3]);
                    client_.setComment(clientList[4]);
                    client_.setId(clientList[5]);
                    client.SendTextMessageAsync(message.Chat.Id, $"Клиент!!!\nId клиента - {client_.getId()}\nИмя - {client_.getName()}\nФамилия - {client_.getSurname()}\nСтатус карты - {client_.getStatus()}\nНомер телефона - {client_.getPhone()}\nКомментарий - {client_.getComment()}", replyMarkup: GetButtons());
                    clientList.Clear();
                }
            }
            else
            {
                client.SendTextMessageAsync(message.Chat.Id, "Клиент не найден!", replyMarkup: GetButtons());
            }
            db.sqlConnection.Close();
            return clientList;
        }

        public void setNewName(string name_, string id_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            List<string> clientList = new List<string>();
            Client client = new Client();
            client.setName(name_);
            client.setId(id_);

            SqlCommand command = new SqlCommand("UPDATE [Table] SET Name=@Name WHERE Id=@Id", db.sqlConnection);

            command.Parameters.AddWithValue("Id", client.getId());
            command.Parameters.AddWithValue("Name", client.getName());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();

            ChangeById.clientList[0] = client.getName();
        }

        public void setNewSurname(string surname_, string id_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            List<string> clientList = new List<string>();
            Client client = new Client();
            client.setSurname(surname_);
            client.setId(id_);

            SqlCommand command = new SqlCommand("UPDATE [Table] SET Surname=@Surname WHERE Id=@Id", db.sqlConnection);

            command.Parameters.AddWithValue("Id", client.getId());
            command.Parameters.AddWithValue("Surname", client.getSurname());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();

            ChangeById.clientList[1] = client.getSurname();
        }

        public void setNewStatus(string status_, string id_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            List<string> clientList = new List<string>();
            Client client = new Client();
            client.setStatus(status_);
            client.setId(id_);

            SqlCommand command = new SqlCommand("UPDATE [Table] SET Status=@Status WHERE Id=@Id", db.sqlConnection);

            command.Parameters.AddWithValue("Id", client.getId());
            command.Parameters.AddWithValue("Status", client.getStatus());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();

            ChangeById.clientList[3] = client.getStatus();
        }

        public void setNewPhone(string newPhone_, string id_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            List<string> clientList = new List<string>();
            Client client = new Client();
            client.setPhone(newPhone_);
            client.setId(id_);

            SqlCommand command = new SqlCommand("UPDATE [Table] SET Phone=@Phone WHERE Id=@Id", db.sqlConnection);

            command.Parameters.AddWithValue("Id", client.getId());
            command.Parameters.AddWithValue("Phone", client.getPhone());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();

            ChangeById.clientList[2] = client.getPhone();
        }

        public void setNewComment(string comment_, string id_)
        {
            DataBase db = new DataBase();
            db.ConnectSql();
            db.sqlConnection.Open();
            List<string> clientList = new List<string>();
            Client client = new Client();
            client.setComment(comment_);
            client.setId(id_);

            SqlCommand command = new SqlCommand("UPDATE [Table] SET Comment=@Comment WHERE Id=@Id", db.sqlConnection);

            command.Parameters.AddWithValue("Id", client.getId());
            command.Parameters.AddWithValue("Comment", client.getComment());

            command.ExecuteNonQuery();
            db.sqlConnection.Close();

            ChangeById.clientList[4] = client.getComment();
        }
    }
}
