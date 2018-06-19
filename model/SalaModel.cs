using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.model
{
    public class SalaModel
    {
        private long id;
        private string nome, localizacao;

        public SalaModel()
        {

        }

        public SalaModel(long id, string nome, string localizacao)
        {
            this.id = id;
            this.nome = nome;
            this.localizacao = localizacao;
        }

        public long Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Localizacao { get => localizacao; set => localizacao = value; }
    }
}
