using MySql.Data.MySqlClient;
using Projeto_LP2_2018_1.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.dao
{
    
    class LoginDAO
    {        
        private DataBase db;
        private bool login;
        private int numUsers;

        public LoginDAO()
        {
            db = DataBase.GetInstance();
        }

        public bool ValidaLogin(string user, string password)
        {
            login = false;
            numUsers = 0;
            String ckLogin = "select id from users where username = '" + user + "' and password = '" + password + "'";
            DataTable users = db.ExecuteQuery(ckLogin);
            Console.Write(users);
                        
            foreach (DataRow dr in users.Rows)
                numUsers++;

            if (numUsers != 0)
            {
                login = true;
            }
            return login;
        }
        
    }

}
