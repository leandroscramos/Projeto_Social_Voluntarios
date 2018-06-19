using MySql.Data.MySqlClient;
using Projeto_LP2_2018_1.model;
using Projeto_LP2_2018_1.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.dao
{
    class AlunoDAO
    {
        private DataBase db;
        private int numAlunos;

        public AlunoDAO()
        {
            db = DataBase.GetInstance();
        }

        // Insere um aluno
        public void createAluno(AlunoModel alunoModel)
        {
            String insert = "insert into aluno(cpf, nome, datanasc) values(@cpf, @nome, @datanasc)";
            MySqlCommand cmd = new MySqlCommand(insert);

            cmd.Parameters.AddWithValue("@cpf", alunoModel.Cpf);
            cmd.Parameters.AddWithValue("@nome", alunoModel.Nome);
            cmd.Parameters.AddWithValue("@datanasc", alunoModel.Datanasc);

            db.ExecuteNonQuery(cmd);
        }

        // Retorna todos os alunos para preencher o DataGrid
        public DataTable readAluno()
        {            
            String consulta = "select cpf as 'CPF', nome as 'Nome', datanasc as 'DataNasc' from aluno";
            DataTable datatable = db.ExecuteQuery(consulta);            
            return datatable;  
        }

        // Retorna número de alunos cadastrados para o Dashboard
        public int countAlunos()
        {
            DataTable alunos = readAluno();
            foreach (DataRow dr in alunos.Rows)
                numAlunos++;
            return numAlunos;
        }

        // Busca aluno por nome
        public DataTable readAlunoByName(string nome)
        {
            String consulta = "select cpf as 'CPF', nome as 'Nome', datanasc as 'DataNasc' from aluno where nome like '%" + nome + "%'";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Busca aluno por cpf
        public AlunoModel readAlunoByCPF(string cpf)
        {
            String consulta = "select cpf as 'CPF', nome as 'Nome', datanasc as 'DataNasc' from aluno where cpf like '%" + cpf + "%'";
            DataTable dt = db.ExecuteQuery(consulta);
            AlunoModel aluno = null;

            foreach (DataRow dr in dt.Rows)
            {
                aluno = new AlunoModel();
                aluno.Cpf = dr["cpf"].ToString();
                aluno.Nome = dr["nome"].ToString();
                aluno.Datanasc = DateTime.Parse(dr["datanasc"].ToString());
            }
            return aluno;
        }

        // Remove um aluno
        public void removeAluno(string cpf)
        {
            String remove = "delete from aluno where cpf = '" + cpf + "'";
            MySqlCommand cmd = new MySqlCommand(remove);
            db.ExecuteNonQuery(cmd);
        }

        // Atualiza um aluno
        public void updateAluno(AlunoModel aluno)
        {
            String update = "update aluno set nome = @nome, datanasc = @datanasc where cpf = @cpf";
            MySqlCommand cmd = new MySqlCommand(update);

            cmd.Parameters.AddWithValue("@cpf", aluno.Cpf);
            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@datanasc", aluno.Datanasc);
            db.ExecuteNonQuery(cmd);
        }
        
    }
}
