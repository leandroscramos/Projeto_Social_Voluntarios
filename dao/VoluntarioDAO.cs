using MySql.Data.MySqlClient;
using Projeto_LP2_2018_1.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_LP2_2018_1.model
{
    class VoluntarioDAO
    {
        private DataBase db;
        private int numVoluntarios;

        public VoluntarioDAO()
        {
            db = DataBase.GetInstance();
        }

        // Insere um voluntario
        public void createVoluntario(VoluntarioModel voluntarioModel)
        {
            String insert = "insert into voluntario(cpf, nome, celular, email, atividade) values(@cpf, @nome, @celular, @email, @atividade)";
            MySqlCommand cmd = new MySqlCommand(insert);

            cmd.Parameters.AddWithValue("@cpf", voluntarioModel.Cpf);
            cmd.Parameters.AddWithValue("@nome", voluntarioModel.Nome);
            cmd.Parameters.AddWithValue("@celular", voluntarioModel.Celular);
            cmd.Parameters.AddWithValue("@email", voluntarioModel.Email);
            cmd.Parameters.AddWithValue("atividade", voluntarioModel.Atividade);

            db.ExecuteNonQuery(cmd);
        }

        // Retorna todos os voluntarios para preencher o DataGrid
        public DataTable readVoluntario()
        {
            String consulta = "select cpf as 'CPF', nome as 'Nome', celular as 'Celular', email as 'Email', atividade as 'Atividade' from voluntario";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Retorna número de voluntárioss cadastrados para o Dashboard
        public int countVoluntarios()
        {
            DataTable voluntarios = readVoluntario();
            foreach (DataRow dr in voluntarios.Rows)
                numVoluntarios++;
            return numVoluntarios;
        }

        // Busca voluntario por nome
        public DataTable readVoluntarioByName(string nome)
        {
            String consulta = "select cpf as 'CPF', nome as 'Nome', celular as 'Celular', email as 'Email', atividade as 'Atividade' from voluntario where nome like '%" + nome + "%'";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Busca voluntario por cpf
        public VoluntarioModel readVoluntarioByCPF(string cpf)
        {
            String consulta = "select cpf as 'CPF', nome as 'Nome', celular as 'Celular', email as 'Email', atividade as 'Atividade' from voluntario where cpf like '%" + cpf + "%'";
            DataTable dt = db.ExecuteQuery(consulta);
            VoluntarioModel voluntario = null;

            foreach (DataRow dr in dt.Rows)
            {
                voluntario = new VoluntarioModel();
                voluntario.Cpf = dr["cpf"].ToString();
                voluntario.Nome = dr["nome"].ToString();
                voluntario.Celular = dr["celular"].ToString();
                voluntario.Email = dr["email"].ToString();
                voluntario.Atividade = dr["atividade"].ToString();
            }
            return voluntario;
        }

        // Remove um voluntario
        public void removeVoluntario(string cpf)
        {
            String remove = "delete from voluntario where cpf = '" + cpf + "'";
            MySqlCommand cmd = new MySqlCommand(remove);
            db.ExecuteNonQuery(cmd);
        }

        // Atualiza um voluntario
        public void updateVoluntario(VoluntarioModel voluntario)
        {
            String update = "update voluntario set nome = @nome, celular = @celular, email = @email, atividade = @atividade where cpf = @cpf";
            MySqlCommand cmd = new MySqlCommand(update);

            cmd.Parameters.AddWithValue("@cpf", voluntario.Cpf);
            cmd.Parameters.AddWithValue("@nome", voluntario.Nome);
            cmd.Parameters.AddWithValue("@celular", voluntario.Celular);
            cmd.Parameters.AddWithValue("email", voluntario.Email);
            cmd.Parameters.AddWithValue("atividade", voluntario.Atividade);
            db.ExecuteNonQuery(cmd);
        }       

    }
}

