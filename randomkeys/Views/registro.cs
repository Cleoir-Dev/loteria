using softlotery.DAL;
using softlotery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softlotery
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    string msg = "Não pode haver campos vazios!.";
                    throw new Exception(msg);
                }

                Login login = new Login();
                login.Username = txtUsuario.Text;
                login.Password = txtSenha.Text;

                LoginDAL.Add(login);

                MessageBox.Show("Usuário e Senha cadastrada com sucesso!.");

                LimpaFormulario();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void LimpaFormulario() 
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox) 
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }
    }
}
