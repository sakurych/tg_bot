using System;
using System.Collections.Generic;
using System.Text;

namespace tg_Bot_16._0._0
{
    class Client
    {
        private string Id;
        private string Name;
        private string Surname;
        private string Phone;
        private string Status;
        private string Comment;

        public Client()
        {
            Name = "";
            Phone = "";
            Status = "";
            Comment = "";
        }

        public Client(string name_, string surname_, string phone_, string status_)
        {
            Name = name_;
            Surname = surname_;
            Phone = phone_;
            Status = status_;
        }
        public string getId()
        {
            return Id;
        }
        public void setId(string id_)
        {
            Id = id_;
        }
        public void setStatus(string status_)
        {
                Status = status_;
        }

        public string getStatus()
        {
            return Status;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string name_)
        {
            Name = name_;
        }

        public string getPhone()
        {
            return Phone;
        }

        public void setPhone(string phone_)
        {
            Phone = phone_;
        }

        public string getComment()
        {
            return Comment;
        }

        public void setComment(string comment_)
        {
            Comment = comment_;
        }

        public string getSurname()
        {
            return Surname;
        }

        public void setSurname(string surname_)
        {
            Surname = surname_;
        }
    }
}
