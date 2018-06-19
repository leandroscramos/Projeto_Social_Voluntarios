using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_LP2_2018_1.model
{
    public class AtividadeModel
    {
        private long id;
        private string nome;
        private DateTime data;
        private Boolean ativo;
        //private int idSala;
        //private string cpfVoluntario;

        public AtividadeModel()
        {

        }

        public AtividadeModel(long id, /*int idSala,*/ string nome, /*string cpfVoluntario,*/ DateTime data, Boolean ativo)
        {
            this.Id = id;
            //this.IdSala = idSala;
            this.Nome = nome;
            //this.CpfVoluntario = cpfVoluntario;
            this.Data = data;
            this.Ativo = ativo;
        }

        public long Id { get => id; set => id = value; }
        //public int IdSala { get => idSala; set => idSala = value; }
        public string Nome { get => nome; set => nome = value; }
        //public string CpfVoluntario { get => cpfVoluntario; set => cpfVoluntario = value; }
        public DateTime Data { get => data; set => data = value; }        
        public bool Ativo { get => ativo; set => ativo = value; }
    }
}
