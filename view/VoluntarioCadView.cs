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

namespace Projeto_LP2_2018_1.view
{
    public partial class VoluntarioCadView : Form
    {
        VoluntarioModel voluntarioModel = new VoluntarioModel();
        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();
        private bool edicao = false;

        public VoluntarioCadView()
        {
            InitializeComponent();
        }
        public VoluntarioCadView(VoluntarioModel voluntario, bool edit)
        {
            InitializeComponent();
            if (edit)
            {
                btnOk.Text = "Atualizar";
                txtCPF.ReadOnly = true;
                edicao = true;
            }
            SetDTO(voluntario);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine(edicao);
            if (edicao)
            {   
                if (txtCPF.Text != string.Empty && txtNome.Text != string.Empty && txtCelular.Text != string.Empty)
                {
                    voluntarioDAO.updateVoluntario(GetDTO());
                    Dispose();
                }
                else
                {                    
                    MessageBox.Show("Campos Nome e Celular não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            else
            {
                if (txtCPF.Text != string.Empty && txtNome.Text != string.Empty && txtCelular.Text != string.Empty)
                {
                    voluntarioDAO.createVoluntario(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos CPF, Nome e Celular não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private VoluntarioModel GetDTO()
        {
            VoluntarioModel voluntario = new VoluntarioModel();
            voluntario.Cpf = txtCPF.Text;
            voluntario.Nome = txtNome.Text;
            voluntario.Celular = txtCelular.Text;
            voluntario.Email = txtEmail.Text;
            voluntario.Atividade = txtAtividade.Text;
            return voluntario;
        }

        private void SetDTO(VoluntarioModel voluntario)
        {
            txtCPF.Text = voluntario.Cpf;
            txtNome.Text = voluntario.Nome;
            txtCelular.Text = voluntario.Celular;
            txtEmail.Text = voluntario.Email;
            txtAtividade.Text = voluntario.Atividade;
            
        }

    }
}
