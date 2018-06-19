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
    public partial class SalaCadView : Form
    {
        SalaModel salaModel = new SalaModel();
        SalaDAO salaDAO = new SalaDAO();
        private bool edicao = false;

        public SalaCadView()
        {
            InitializeComponent();
        }
        public SalaCadView(SalaModel sala, bool edit)
        {
            InitializeComponent();
            if (edit)
            {
                btnOk.Text = "Atualizar";
                txtId.ReadOnly = true;
                edicao = true;
            }
            SetDTO(sala);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine(edicao);
            Console.WriteLine(edicao);
            if (edicao)
            {
                if (txtNome.Text != string.Empty && txtLocalizacao.Text != string.Empty)
                {
                    salaDAO.updateSala(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos Nome e Localização não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (txtNome.Text != string.Empty && txtLocalizacao.Text != string.Empty)
                {
                    salaDAO.createSala(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos Nome e Localização não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private SalaModel GetDTO()
        {
            SalaModel sala = new SalaModel();
            if (txtId.Text != "")
                sala.Id = long.Parse(txtId.Text);
            sala.Nome = txtNome.Text;
            sala.Localizacao = txtLocalizacao.Text;
            return sala;
        }

        private void SetDTO(SalaModel sala)
        {
            txtId.Text = sala.Id.ToString();
            txtNome.Text = sala.Nome;
            txtLocalizacao.Text = sala.Localizacao;
        }
    }
}
