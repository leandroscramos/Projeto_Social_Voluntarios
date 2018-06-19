using Projeto_LP2_2018_1.model;
using Projeto_LP2_2018_1.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_LP2_2018_1
{
    public partial class VoluntarioView : Form
    {
        VoluntarioModel voluntarioModel = new VoluntarioModel();
        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();
        DataTable voluntarios = new DataTable();

        public VoluntarioView()
        {
            InitializeComponent();
            Fill(voluntarios);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form home = new HomeView();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form voluntario = new VoluntarioView();
            voluntario.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form sala = new SalaView();
            sala.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form aluno = new AlunoView();
            aluno.Show();
            this.Hide();
        }        

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form voluntarioCad = new VoluntarioCadView();
            voluntarioCad.StartPosition = FormStartPosition.CenterParent;
            voluntarioCad.ShowDialog(this);
            Fill(voluntarios);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            VoluntarioModel voluntario = voluntarioDAO.readVoluntarioByCPF(dataGridVoluntarios.CurrentRow.Cells[0].Value.ToString());
            VoluntarioCadView voluntarioCadView = new VoluntarioCadView(voluntario, true);
            voluntarioCadView.StartPosition = FormStartPosition.CenterParent;
            voluntarioCadView.ShowDialog(this);
            Fill(voluntarios);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string tmp = dataGridVoluntarios.CurrentRow.Cells[1].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover " + tmp + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                voluntarioDAO.removeVoluntario(dataGridVoluntarios.CurrentRow.Cells[0].Value.ToString());
                Fill(voluntarios);
                MessageBox.Show("Voluntário apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void Fill(DataTable voluntarios)
        {
            dataGridVoluntarios.DataSource = voluntarioDAO.readVoluntario();
        }
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridVoluntarios.DataSource = voluntarioDAO.readVoluntarioByName(txtName.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form atividade = new AtividadeView();
            atividade.Show();
            this.Hide();
        }
    }
}
