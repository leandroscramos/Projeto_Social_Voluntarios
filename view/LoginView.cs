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

namespace Projeto_LP2_2018_1
{
    public partial class LoginView : Form
    {
        LoginDAO loginDAO = new LoginDAO();

        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            { 
                if (loginDAO.ValidaLogin(txtUser.Text, txtPassword.Text))
                {
                    Form home = new HomeView();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválida");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
