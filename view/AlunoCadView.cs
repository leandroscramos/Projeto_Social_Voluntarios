using Projeto_LP2_2018_1.dao;
using Projeto_LP2_2018_1.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_LP2_2018_1.view
{
    public partial class AlunoCadView : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        AlunoDAO alunoDAO = new AlunoDAO();
        private bool edicao = false;

        public AlunoCadView()
        {
            InitializeComponent();
        }

        public AlunoCadView(AlunoModel aluno, bool edit)
        {
            InitializeComponent();
            if (edit)
            {
                btnOk.Text = "Atualizar";
                txtCPF.ReadOnly = true;
                edicao = true;
            }
            SetDTO(aluno);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            Console.WriteLine(edicao);
            if (edicao)
            {
                if (txtNome.Text != string.Empty && txtDatanasc.Text != string.Empty)
                {
                    alunoDAO.updateAluno(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos Nome e Data de Nascimento não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (txtCPF.Text != string.Empty && txtNome.Text != string.Empty && txtDatanasc.Text != string.Empty)
                {
                    alunoDAO.createAluno(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos CPF, Nome e Data de Nascimento não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private AlunoModel GetDTO()
        {
            AlunoModel aluno = new AlunoModel();
            aluno.Cpf = txtCPF.Text;
            aluno.Nome = txtNome.Text;
            aluno.Datanasc = DateTime.Parse(txtDatanasc.Text);
            return aluno;
        }

        private void SetDTO(AlunoModel aluno)
        {
            txtCPF.Text = aluno.Cpf;
            txtNome.Text = aluno.Nome;
            txtDatanasc.Text = aluno.Datanasc.ToString();
        }
    }
}
