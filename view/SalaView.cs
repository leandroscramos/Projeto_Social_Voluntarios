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
    public partial class SalaView : Form
    {
        SalaModel salaModel = new SalaModel();
        SalaDAO salaDAO = new SalaDAO();
        DataTable salas = new DataTable();

        public SalaView()
        {
            InitializeComponent();
            Fill(salas);
        }       

        private void btnSair_Click(object sender, EventArgs e)
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
        private void button6_Click(object sender, EventArgs e)
        {
            Form atividade = new AtividadeView();
            atividade.Show();
            this.Hide();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form salaCad = new SalaCadView();
            salaCad.StartPosition = FormStartPosition.CenterParent;
            salaCad.ShowDialog(this);
            Fill(salas);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridSalas.DataSource = salaDAO.readSalaByName(txtName.Text);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string tmp = dataGridSalas.CurrentRow.Cells[1].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover " + tmp + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                salaDAO.removeSala(long.Parse(dataGridSalas.CurrentRow.Cells[0].Value.ToString()));
                Fill(salas);
                MessageBox.Show("Sala removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form home = new HomeView();
            home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form aluno = new AlunoView();
            aluno.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            SalaModel sala = salaDAO.readSalaById(int.Parse(dataGridSalas.CurrentRow.Cells[0].Value.ToString()));
            
            SalaCadView salaCadView = new SalaCadView(sala, true);
            salaCadView.StartPosition = FormStartPosition.CenterParent;
            salaCadView.ShowDialog(this);
            Fill(salas);
        }
        private void Fill(DataTable salas)
        {
            dataGridSalas.DataSource = salaDAO.readSala();
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridSalas.DataSource = salaDAO.readSalaByName(txtName.Text);
        }

        
    }
}
