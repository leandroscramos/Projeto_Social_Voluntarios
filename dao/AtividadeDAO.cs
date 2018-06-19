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
    class AtividadeDAO
    {
        private DataBase db;
        private int numAtividades;

        public AtividadeDAO()
        {
            db = DataBase.GetInstance();
        }

        // Insere uma atividade
        public void createAtividade(AtividadeModel atividadeModel)
        {
            String insert = "insert into atividades(nome, data, ativo) values(@nome, @data, @ativo)";
            MySqlCommand cmd = new MySqlCommand(insert);
                        
            cmd.Parameters.AddWithValue("@nome", atividadeModel.Nome);
            cmd.Parameters.AddWithValue("@data", atividadeModel.Data);
            cmd.Parameters.AddWithValue("@ativo", atividadeModel.Ativo);

            db.ExecuteNonQuery(cmd);
        }

        // Retorna todas as atividades para preencher o DataGrid
        public DataTable readAtividade()
        {
            String consulta = "select id as 'Id', nome as 'Nome', data as 'Data', ativo as 'Ativo' from atividades";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        public DataTable readAtividadeAtiva()
        {
            String consulta = "select id as 'Id', nome as 'Nome', data as 'Data', ativo as 'Ativo' from atividades where ativo = true";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }
        public DataTable readAtividadeInativa()
        {
            String consulta = "select id as 'Id', nome as 'Nome', data as 'Data', ativo as 'Ativo' from atividades where ativo = false";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Retorna número de atividades cadastradas para o Dashboard
        public int countAtividade()
        {
            DataTable atividades = readAtividade();
            foreach (DataRow dr in atividades.Rows)
                numAtividades++;
            return numAtividades;
        }

        // Busca atividade por nome
        public DataTable readAtividadeByName(string nome)
        {
            String consulta = "select id as 'Id', nome as 'Nome', data as 'Data', ativo as 'Ativo' from atividades where nome like '%" + nome + "%'";
            DataTable datatable = db.ExecuteQuery(consulta);
            return datatable;
        }

        // Busca atividade por cpf
        public AtividadeModel readAtividadeById(long id)
        {
            String consulta = "select id as 'Id', nome as 'Nome', data as 'Data', ativo as 'Ativo' from atividades where id = " + id;
            DataTable dt = db.ExecuteQuery(consulta);
            AtividadeModel atividade = null;


            foreach (DataRow dr in dt.Rows)
            {
                atividade = new AtividadeModel();
                atividade.Id = int.Parse(dr["id"].ToString());
                atividade.Nome = dr["nome"].ToString();
                atividade.Data = DateTime.Parse(dr["data"].ToString());
                //atividade.Ativo = bool.Parse(dr["nome"].ToString());
            }
            return atividade;
        }

        // Remove uma atividade
        public void removeAtividade(long id)
        {
            String remove = "delete from atividades where id = " + id;
            MySqlCommand cmd = new MySqlCommand(remove);
            db.ExecuteNonQuery(cmd);
        }

        // Atualiza uma atividade
        public void updateAtividade(AtividadeModel atividade)
        {
            String update = "update atividades set nome = @nome, data = @data, ativo = @ativo where id = @id";
            MySqlCommand cmd = new MySqlCommand(update);

            cmd.Parameters.AddWithValue("@id", atividade.Id);
            cmd.Parameters.AddWithValue("@nome", atividade.Nome);
            cmd.Parameters.AddWithValue("@data", atividade.Data);
            cmd.Parameters.AddWithValue("@ativo", atividade.Ativo);
            db.ExecuteNonQuery(cmd);
        }

    }
}
