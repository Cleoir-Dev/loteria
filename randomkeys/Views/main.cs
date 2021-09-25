using loterias_caixa;
using softlotery.DAL;
using softlotery.Models;
using softlotery.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace softlotery
{
    public partial class randomnumber : Form
    {
        Login _login = new Login();

        public randomnumber()
        {
            InitializeComponent();
        }

        public randomnumber(Login login)

        {
            InitializeComponent();
            _login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mega = new painel((int)ETipoJogo.Megasena);
            mega.ShowDialog();
        }

        private void button_lotomania_Click(object sender, EventArgs e)
        {
            var lotomania = new painel((int)ETipoJogo.Lotomania);
            lotomania.ShowDialog();
        }

        private void button_quina_Click(object sender, EventArgs e)
        {
            var quina = new painel((int)ETipoJogo.Quina);
            quina.ShowDialog();
        }

        private void button_duplasena_Click(object sender, EventArgs e)
        {
            var dupla = new painel((int)ETipoJogo.Duplasena);
            dupla.ShowDialog();
        }

        private void randomnumber_Load(object sender, EventArgs e)
        {
            lbNome.Text = _login.Username;
            var jogos = JogoDAL.GetAllJogos();
            var jogo = jogos.LastOrDefault();
            lbNumeros.Text = jogo.Numero.ToString(); 
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbNumeros.Text))
            {
                Clipboard.SetText(lbNumeros.Text);
            }
        }

        private void randomnumber_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
