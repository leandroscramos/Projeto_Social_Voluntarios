using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.view
{
    public class VoluntarioModel
    {
        private string cpf, nome, celular, email, atividade;

        public VoluntarioModel()
        {

        }

        public VoluntarioModel(string cpf, string nome, string celular, string email, string atividade)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.celular = celular;
            this.email = email;
            this.atividade = atividade;

        }

        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public string Atividade { get => atividade; set => atividade = value; }
    }
}
