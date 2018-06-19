using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_LP2_2018_1.model
{
    class DataBase
    {
        private static MySqlConnection conexao;
        private static DataBase instance;
        private string URL = "server=localhost; user=root; database=projetoLP2; port=3306; password=''";

        private DataBase()
        {
            conexao = new MySqlConnection(URL);
        }

        public static DataBase GetInstance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            return conexao;
        }

        public void ExecuteNonQuery(MySqlCommand cmd)
        {
            if (conexao.State != System.Data.ConnectionState.Open)
                conexao.Open();

            cmd.Connection = conexao;
            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        public DataTable ExecuteQuery(string consulta)
        {
            if (conexao.State != System.Data.ConnectionState.Open)
                conexao.Open();

            MySqlCommand cmd = new MySqlCommand(consulta, conexao);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            DataTable dataTable = new DataTable();            
            dataAdapter.Fill(dataTable);

            conexao.Close();
            return dataTable;
        }        
    }
}
