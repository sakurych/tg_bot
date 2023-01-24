using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;
using static tg_Bot_16._0._0.Client;


namespace tg_Bot_16._0._0
{
    class SearchClient:Program
    {
        public static void SearchPhone(MessageEventArgs Phone)
        {
            var msgSearchPhone_ = Phone.Message;
            string msg = Phone.Message.Text;
            dbCommands db_commands = new dbCommands();
            List<string> clientList = db_commands.searchClientByPhone(msg, msgSearchPhone_);
        }
    }
}
