using loterias_caixa;
using softlotery.DAL;
using softlotery.Models;
using softlotery.Views;
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
    public partial class acessar : Form
    {
        public acessar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
          

        }

        private void acessar_Load(object sender, EventArgs e)
        {
            if (!ExtensionMethods.IsConnected())
            {
                MessageBox.Show("Não exite conexão ativa com a internet.");
            }
            else
            {
                using (loading l = new loading(CarregarBanco))
                {
                    l.ShowDialog(this);
                }


                using (loading l = new loading(AtualizarBanco))
                {
                    l.ShowDialog(this);
                }
            }   
        }

        private void CarregarBanco()
        {
            try
            {
                SqliteDAL.CriarBancoSQLite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

            try
            {
                SqliteDAL.CriarTabelaSQlite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void AtualizarBanco()
        {
            var resultado = new Loterias();

            var mega = resultado.Megasena();

            var concursoM = mega != null ? mega.Concurso.ToString() : string.Empty;

            var jogo = JogoDAL.GetJogoByConcurso(concursoM, (int)ETipoJogo.Megasena);

            if (jogo == null && mega != null)
            {
                var jogoNovo = new Jogo
                {
                    Numero = string.Join(" ", mega.DezenasOrdemCrescente),
                    TipoJogo = 1,
                    QtdaJogada = "1",
                    Concurso = mega.Concurso.ToString()
                };
                JogoDAL.Add(jogoNovo);
            }

            var lotomania = resultado.Lotomania();

            var concursoL = lotomania != null ? lotomania.Concurso.ToString() : string.Empty;

            var loto = JogoDAL.GetJogoByConcurso(concursoL, (int)ETipoJogo.Lotomania);

            if (loto == null && lotomania != null)
            {
                var jogoNovo = new Jogo
                {
                    Numero = string.Join(" ", lotomania.DezenasOrdemCrescente),
                    TipoJogo = 2,
                    QtdaJogada = "1",
                    Concurso = lotomania.Concurso.ToString()
                };
                JogoDAL.Add(jogoNovo);
            }

            var quina = resultado.Quina();

            var concursoQ = quina != null ? quina.Concurso.ToString() : string.Empty;

            var qn = JogoDAL.GetJogoByConcurso(concursoQ, (int)ETipoJogo.Quina);

            if (qn == null && quina != null)
            {
                var jogoNovo = new Jogo
                {
                    Numero = string.Join(" ", quina.DezenasOrdemCrescente),
                    TipoJogo = 3,
                    QtdaJogada = "1",
                    Concurso = quina.Concurso.ToString()
                };
                JogoDAL.Add(jogoNovo);
            }

            var dupla = resultado.DuplaSena();

            var concursoD = dupla != null ? dupla.Concurso.ToString() : string.Empty;

            var dp = JogoDAL.GetJogoByConcurso(concursoD, (int)ETipoJogo.Duplasena);

            if (dp == null && dupla != null)
            {
                var jogoNovo = new Jogo
                {
                    Numero = string.Join(" ", dupla.DezenasOrdemCrescente),
                    TipoJogo = 4,
                    QtdaJogada = "1",
                    Concurso = dupla.Concurso.ToString()
                };
                JogoDAL.Add(jogoNovo);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text)) 
                {
                    throw new Exception("Não pode haver campos vazios!.");
                }

                var usuario = LoginDAL.GetLoginUsuario(txtUsuario.Text, txtSenha.Text);

                if (usuario != null && usuario.Id > 0)
                {
                    randomnumber random = new randomnumber(usuario);
                    random.Show();
                    this.Hide();
                }
                else
                {
                    throw new Exception("Usuário ou Senha inválidos!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                LimpaFormulario();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registro = new registro();
            registro.ShowDialog();
        }
    }
}
