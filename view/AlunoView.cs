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
    public partial class AlunoView : Form
    {
        AlunoModel alunoModel = new AlunoModel();
        AlunoDAO alunoDAO = new AlunoDAO();
        DataTable alunos = new DataTable();

        public AlunoView()
        {
            InitializeComponent();            
            Fill(alunos);            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form sala = new SalaView();
            sala.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form voluntario = new VoluntarioView();
            voluntario.Show();
            this.Hide();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form alunoCad = new AlunoCadView();
            alunoCad.StartPosition = FormStartPosition.CenterParent;
            alunoCad.ShowDialog(this);
            Fill(alunos);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string tmp = dataGridAlunos.CurrentRow.Cells[1].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover " + tmp + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                alunoDAO.removeAluno(dataGridAlunos.CurrentRow.Cells[0].Value.ToString());
                Fill(alunos);
                MessageBox.Show("Aluno removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AlunoModel aluno = alunoDAO.readAlunoByCPF(dataGridAlunos.CurrentRow.Cells[0].Value.ToString());
            AlunoCadView alunoCadView = new AlunoCadView(aluno, true);
            alunoCadView.StartPosition = FormStartPosition.CenterParent;
            alunoCadView.ShowDialog(this);
            Fill(alunos);

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridAlunos.DataSource = alunoDAO.readAlunoByName(txtName.Text);
        }

        private void Fill(DataTable alunos)
        {
            dataGridAlunos.DataSource = alunoDAO.readAluno();
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridAlunos.DataSource = alunoDAO.readAlunoByName(txtName.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form home = new HomeView();
            home.Show();
            this.Hide();            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form atividade = new AtividadeView();
            atividade.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
