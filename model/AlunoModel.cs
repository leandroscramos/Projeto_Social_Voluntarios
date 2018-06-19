using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.model
{
    public class AlunoModel
    {
        private string cpf, nome;
        private DateTime datanasc;

        public AlunoModel()
        {

        }

        public AlunoModel(string cpf, string nome, DateTime datanasc)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.datanasc = datanasc;
        }

        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime Datanasc { get => datanasc; set => datanasc = value; }        
    }
}
