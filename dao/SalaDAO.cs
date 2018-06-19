using MySql.Data.MySqlClient;
using Projeto_LP2_2018_1.model;
using Projeto_LP2_2018_1.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_LP2_2018_1.dao
{
    class SalaDAO
    {
        private DataBase db;

        public SalaDAO()
        {
            db = DataBase.GetInstance();
        }

        // Insere uma sala
        public void createSala(SalaModel salaModel)
        {
            String insert = "insert into sala(nome, localizacao) values(@nome, @localizacao)";
            MySqlCommand cmd = new MySqlCommand(insert);
            cmd.Parameters.AddWithValue("@nome", salaModel.Nome);
            cmd.Parameters.AddWithValue("@localizacao", salaModel.Localizacao);
            db.ExecuteNonQuery(cmd);
        }

        // Retorna todas as salas para preencher o DataGrid
        public DataTable readSala()
        {
            String consulta = "select id as 'Id', nome as 'Nome', localizacao as 'Localizacao' from sala";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Busca sala por nome
        public DataTable readSalaByName(string nome)
        {
            String consulta = "select id as 'Id', nome as 'Nome', localizacao as 'Localizacao' from sala where nome like '%" + nome + "%'";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Busca sala por Id
        
        public SalaModel readSalaById(long id)
        {
            String consulta = "select id as 'Id', nome as 'Nome', localizacao as 'Localizacao' from sala where id = " + id;
            DataTable dt = db.ExecuteQuery(consulta);
            SalaModel sala = null;
            

            foreach (DataRow dr in dt.Rows)
            {
                sala = new SalaModel();
                sala.Id = int.Parse(dr["id"].ToString());
                sala.Nome = dr["nome"].ToString();
                sala.Localizacao = dr["localizacao"].ToString();                
            }
            return sala;
        }
        

        // Remove uma Sala
        public void removeSala(long id)
        {
            String remove = "delete from sala where id = " + id;
            MySqlCommand cmd = new MySqlCommand(remove);
            db.ExecuteNonQuery(cmd);
        }

        // Atualiza uma Sala
        public void updateSala(SalaModel sala)
        {
            String update = "update sala set nome = @nome, localizacao = @localizacao where id = @id";
            MySqlCommand cmd = new MySqlCommand(update);

            cmd.Parameters.AddWithValue("@id", sala.Id);
            cmd.Parameters.AddWithValue("@nome", sala.Nome);
            cmd.Parameters.AddWithValue("@localizacao", sala.Localizacao);
            db.ExecuteNonQuery(cmd);
        }
    }    
}
