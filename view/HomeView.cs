using Projeto_LP2_2018_1.dao;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_LP2_2018_1
{
    public partial class HomeView : Form
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();        

        public HomeView()
        {
            InitializeComponent();
            txtNumAlunos.Text = alunoDAO.countAlunos().ToString();
            txtNumVoluntarios.Text = voluntarioDAO.countVoluntarios().ToString();            
        }
        private void timer1_Tick_2(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
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
        private void button6_Click(object sender, EventArgs e)
        {
            Form atividade = new AtividadeView();
            atividade.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
