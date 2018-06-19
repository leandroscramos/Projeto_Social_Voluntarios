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
    public partial class AtividadeCadView : Form
    {
        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();
        SalaDAO salaDAO = new SalaDAO();
        AlunoDAO alunoDAO = new AlunoDAO();
        AtividadeDAO atividadeDAO = new AtividadeDAO();
        //AtividadeModel atividadeModel = new AtividadeModel();
        DataTable voluntario = new DataTable();
        DataTable sala = new DataTable();
        private bool edicao = false;

        public AtividadeCadView()
        {
            InitializeComponent();
            voluntario = voluntarioDAO.readVoluntario();
            for (int i = 0; i < voluntario.Rows.Count; i++)
            {
                CBoxVoluntarios.Items.Add(voluntario.Rows[i]["nome"].ToString());
            }
            sala = salaDAO.readSala();
            for (int i = 0; i < sala.Rows.Count; i++)
            {
                CBoxSalas.Items.Add(sala.Rows[i]["nome"].ToString());
            }
            dataGridAlunosCad.DataSource = alunoDAO.readAluno();
        }

        public AtividadeCadView(AtividadeModel atividade, bool edit)
        {
            InitializeComponent();           
            
            if (edit)
            {
                btnOk.Text = "Atualizar";
                txtId.ReadOnly = true;
                edicao = true;
            }
            SetDTO(atividade);            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            
        }
    

        private void btnOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine(edicao);
            if (edicao)
            {
                if (txtName.Text != string.Empty && txtData.Text != string.Empty)
                {
                    atividadeDAO.updateAtividade(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos Nome e Data não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (txtName.Text != string.Empty && txtData.Text != string.Empty)
                {
                    atividadeDAO.createAtividade(GetDTO());
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Campos Nome e Data não podem ser nulos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        
        private AtividadeModel GetDTO()
        {
            AtividadeModel atividade = new AtividadeModel();            
            atividade.Nome = txtName.Text;
            atividade.Data = DateTime.Parse(txtData.Text);
            atividade.Ativo = true;
            //atividade.CpfVoluntario = voluntario.
            //aluno.Cpf = txtCPF.Text;
            //aluno.Nome = txtNome.Text;
            //aluno.Datanasc = DateTime.Parse(txtData.Text);
            return atividade;
        }

        private void SetDTO(AtividadeModel atividade)
        {
            txtId.Text = atividade.Id.ToString();
            txtName.Text = atividade.Nome;
            txtData.Text = atividade.Data.ToString();
            txtAtivo.Text = atividade.Ativo.ToString();
            voluntario = voluntarioDAO.readVoluntario();
            for (int i = 0; i < voluntario.Rows.Count; i++)
            {
                CBoxVoluntarios.Items.Add(voluntario.Rows[i]["nome"].ToString());
            }
            sala = salaDAO.readSala();
            for (int i = 0; i < sala.Rows.Count; i++)
            {
                CBoxSalas.Items.Add(sala.Rows[i]["nome"].ToString());
            }
            dataGridAlunosCad.DataSource = alunoDAO.readAluno();
        }
        
    }
}
