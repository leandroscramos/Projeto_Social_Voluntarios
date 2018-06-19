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
    public partial class AtividadeView : Form
    {
        AtividadeModel atividadeModel = new AtividadeModel();
        AtividadeDAO atividadeDAO = new AtividadeDAO();
        DataTable atividades = new DataTable();

        public AtividadeView()
        {
            InitializeComponent();
            Fill(atividades);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form atividadeCad = new AtividadeCadView();
            atividadeCad.StartPosition = FormStartPosition.CenterParent;
            atividadeCad.ShowDialog(this);
            Fill(atividades);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form aluno = new AlunoView();
            aluno.Show();
            this.Hide();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form home = new HomeView();
            home.Show();
            this.Hide();
        }
        private void Fill(DataTable atividades)
        {
            dataGridAtividadesAtivas.DataSource = atividadeDAO.readAtividadeAtiva();
            dataGridAtividadesInativas.DataSource = atividadeDAO.readAtividadeInativa();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AtividadeModel atividade = atividadeDAO.readAtividadeById(long.Parse(dataGridAtividadesAtivas.CurrentRow.Cells[0].Value.ToString()));
            AtividadeCadView atividadeCadView = new AtividadeCadView(atividade, true);                        
            atividadeCadView.StartPosition = FormStartPosition.CenterParent;
            atividadeCadView.ShowDialog(this);
            Fill(atividades);
        }
    }
}
