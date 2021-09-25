using loterias_caixa;
using softlotery.DAL;
using softlotery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace softlotery.Views
{
    public partial class painel : Form
    {
        ETipoJogo _tipoJogo;

        public painel()
        {
            InitializeComponent();
        }

        public painel(int tipoJogo)

        {

            InitializeComponent();

            _tipoJogo = (ETipoJogo)tipoJogo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool igual = false;

            if (listView1.Items.Count > 0)
            {
                var lista = listView1.Items.Cast<ListViewItem>().ToList();
                igual = lista.Any(d => d.Text == textBox1.Text);
            }

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !igual && listView1.Items.Count < QuantidadeMaxima(_tipoJogo))
            {
                listView1.Items.Add(textBox1.Text);
            }

            textBox1.Text = string.Empty;
        }

        private void painel_Load_1(object sender, EventArgs e)
        {
            lbNomeJogo.Text = _tipoJogo.ToString();
            comboBox1.SelectedIndex = _tipoJogo.GetHashCode() - 1;
        }

        private void button_lotomania_gerar_Click(object sender, EventArgs e)
        {
            List<int> lotteryNumbers = new List<int>();

            if (listView2.Items.Count > 0)
                listView2.Items.Clear();

            bool hasJogo = true;

            if (comboBox2.SelectedItem.Equals("Meu Número"))
            {
                lotteryNumbers = MeuNumero();
            }

            if (comboBox2.SelectedItem.Equals("Mais Jogados"))
            {
                lotteryNumbers = MaisJogados();
            }

            if (comboBox2.SelectedItem.Equals("Sorte"))
            {
                while (hasJogo)
                {
                    lotteryNumbers = Sorte();
                    var result = string.Join(" ", lotteryNumbers);
                    var jogo = JogoDAL.GetJogoByNumber(result);
                    hasJogo = jogo != null ? true : false;
                }
            }

            var listaNumber = lotteryNumbers.ToArray();
            Array.Sort(listaNumber);

            foreach (var item in listaNumber)
            {
                listView2.Items.Add(item.ToString());
            }

        }

        private List<int> MeuNumero() 
        {
            List<int> lotteryNumbers = new List<int>();

            var jogos = JogoDAL.GetJogoByTipo((int)_tipoJogo);

            var quantidades = jogos.Select(d => Convert.ToInt32(d.QtdaJogada));

            var resultado = jogos.FirstOrDefault(d => d.QtdaJogada.Equals(quantidades.Max().ToString()));

            var arrayNumeros = resultado.Numero.Split(' ');
            int[] myInts = Array.ConvertAll(arrayNumeros, s => int.Parse(s));

            foreach (var item in myInts)
            {
                lotteryNumbers.Add(item);
            }

            return lotteryNumbers;
        }

        private List<int> MaisJogados()
        {
            List<int> lotteryNumbers = new List<int>();
            List<int[]> numerosMaisJogados = new List<int[]>();

            var jogos = JogoDAL.GetJogoByTipo((int)_tipoJogo);
            var numeros = jogos.Select(d => d.Numero);

            foreach (var numero in numeros)
            {
                var arrayNumeros = numero.Split(' ');
                int[] myInts = Array.ConvertAll(arrayNumeros, s => int.Parse(s));
                numerosMaisJogados.Add(myInts);
            }

            foreach (var item in numerosMaisJogados)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    lotteryNumbers.Add(item[i]);
                }
            }

            var list = lotteryNumbers.Distinct().ToList();

            foreach (var item in list)
            {
                lotteryNumbers.Remove(item);
            }
            lotteryNumbers = lotteryNumbers.Distinct().ToList();

            return lotteryNumbers;
        }

        private List<int> Sorte()
        {
            int MaxNumberArray;
            Random r = new Random();
            List<int> lotteryNumbers = new List<int>();
            
            switch (_tipoJogo)
            {
                case ETipoJogo.Megasena:
                    MaxNumberArray = 6;

                    while (lotteryNumbers.Count < MaxNumberArray)
                    {
                        int lottoNumber = r.Next(1, 60);
                        if (!lotteryNumbers.Contains(lottoNumber))
                        {
                            lotteryNumbers.Add(lottoNumber);
                        }
                    }
                    break;
                case ETipoJogo.Lotomania:
                    MaxNumberArray = 50;

                    while (lotteryNumbers.Count < MaxNumberArray)
                    {
                        int lottoNumber = r.Next(0, 99);
                        if (!lotteryNumbers.Contains(lottoNumber))
                        {
                            lotteryNumbers.Add(lottoNumber);
                        }
                    }
                    break;
                case ETipoJogo.Quina:
                    MaxNumberArray = 5;

                    while (lotteryNumbers.Count < MaxNumberArray)
                    {
                        int lottoNumber = r.Next(1, 80);
                        if (!lotteryNumbers.Contains(lottoNumber))
                        {
                            lotteryNumbers.Add(lottoNumber);
                        }
                    }
                    break;
                case ETipoJogo.Duplasena:
                    MaxNumberArray = 12;

                    while (lotteryNumbers.Count < MaxNumberArray)
                    {
                        int lottoNumber = r.Next(1, 50);
                        if (!lotteryNumbers.Contains(lottoNumber))
                        {
                            lotteryNumbers.Add(lottoNumber);
                        }
                    }
                    break;
                default:
                    break;
            }
           
            return lotteryNumbers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                var names = listView2.Items.Cast<ListViewItem>()
                                .Select(item => item.Text)
                                .ToList();
                var result = string.Join(" ", names);

                Clipboard.SetText(result);
            }          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(
                    listView1.Items.Cast<ListViewItem>().LastOrDefault()
                );
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                var names = listView1.Items.Cast<ListViewItem>()
                                .Select(item => item.Text)
                                .ToList();
                var result = string.Join(" ", names);

                var jogo = JogoDAL.GetJogoByNumber(result);

                if (jogo == null)                 
                {
                    var jogoNovo = new Jogo
                    {
                        Numero = result,
                        TipoJogo = (int)_tipoJogo,
                        QtdaJogada = "1",
                        Concurso = "0"
                    };
                    JogoDAL.Add(jogoNovo);
                    MessageBox.Show("Números salvos com sucesso!.");
                } 
                else
                {
                    jogo.Numero = result;
                    jogo.TipoJogo = (int)_tipoJogo;
                    jogo.QtdaJogada = (Convert.ToInt32(jogo.QtdaJogada) + 1).ToString();
                    jogo.Concurso = "0";

                    JogoDAL.Update(jogo);
                    MessageBox.Show("Números salvos com sucesso!.");
                }
                listView1.Items.Clear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count > 0)
            {
                var names = listView3.Items.Cast<ListViewItem>()
                                .Select(item => item.Text)
                                .ToList();
                var result = string.Join(" ", names);

                Clipboard.SetText(result);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label10.Text = string.Empty;
            label12.Text = string.Empty;
            label11.Text = string.Empty;
            lbResultado.Text = string.Empty;

            var resultado = new Loterias();
            var jogo = new List<int>();
            int count = 0;

            switch (_tipoJogo)
            {
                case ETipoJogo.Megasena:

                    var mega = resultado.Megasena();
                 
                    while (mega == null && count <= 3)
                    {
                        mega = resultado.Megasena();
                        count++;
                    }                                   

                    if (listView3.Items.Count > 0 && mega != null)
                    {
                        jogo = listView3.Items.Cast<ListViewItem>()
                                        .Select(item => Convert.ToInt32(item.Text))
                                        .ToList();

                        label10.Text = $"O jogo acima possui {mega.Acertos(jogo)} acertos.";
                        label12.Text = $"O concurso n° {mega.Concurso} realizado dia {mega.DataApuracao:dd/MM/yyyy}.";
                        label11.Text = $"Teve as seguintes dezenas sorteadas:";
                        lbResultado.Text = $"{string.Join(", ", mega.DezenasSorteadas.ToArray())}";
                    }
                break;

                case ETipoJogo.Lotomania:

                    var lotomania = resultado.Lotomania();

                    while (lotomania == null && count <= 3)
                    {
                        lotomania = resultado.Lotomania();
                        count++;
                    }

                    if (listView3.Items.Count > 0 && lotomania != null)
                    {
                        jogo = listView3.Items.Cast<ListViewItem>()
                                        .Select(item => Convert.ToInt32(item.Text))
                                        .ToList();

                        label10.Text = $"O jogo acima possui {lotomania.Acertos(jogo)} acertos.";
                        label12.Text = $"O concurso n° {lotomania.Concurso} realizado dia {lotomania.DataApuracao:dd/MM/yyyy}.";
                        label11.Text = $"Teve as seguintes dezenas sorteadas:";
                        lbResultado.Text = $"{string.Join(", ", lotomania.DezenasSorteadas.ToArray())}";
                    }
                    break;

                case ETipoJogo.Quina:

                    var quina = resultado.Quina();

                    while (quina == null && count <= 3)
                    {
                        quina = resultado.Quina();
                        count++;
                    }


                    if (listView3.Items.Count > 0 && quina != null)
                    {
                        jogo = listView3.Items.Cast<ListViewItem>()
                                        .Select(item => Convert.ToInt32(item.Text))
                                        .ToList();

                        label10.Text = $"O jogo acima possui {quina.Acertos(jogo)} acertos.";
                        label12.Text = $"O concurso n° {quina.Concurso} realizado dia {quina.DataApuracao:dd/MM/yyyy}.";
                        label11.Text = $"Teve as seguintes dezenas sorteadas:";
                        lbResultado.Text = $"{string.Join(", ", quina.DezenasSorteadas.ToArray())}";
                    }
                    break;

                case ETipoJogo.Duplasena:

                    var dupla = resultado.DuplaSena();

                    while (dupla == null && count <= 3)
                    {
                        dupla = resultado.DuplaSena();
                        count++;
                    }                  

                    if (listView3.Items.Count > 0 && dupla != null)
                    {
                        jogo = listView3.Items.Cast<ListViewItem>()
                                        .Select(item => Convert.ToInt32(item.Text))
                                        .ToList();

                        label10.Text = $"O jogo acima possui {dupla.Acertos(jogo)} acertos.";
                        label12.Text = $"O concurso n° {dupla.Concurso} realizado dia {dupla.DataApuracao:dd/MM/yyyy}.";
                        label11.Text = $"Teve as seguintes dezenas sorteadas:";
                        lbResultado.Text = $"{string.Join(", ", dupla.DezenasSorteadas.ToArray())}";
                    }
                    break;

                default:
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool igual = false;

            if (listView3.Items.Count > 0)
            {
                var lista = listView3.Items.Cast<ListViewItem>().ToList();
                igual = lista.Any(d => d.Text == textBox3.Text);
            }

            if (!string.IsNullOrWhiteSpace(textBox3.Text) && !igual && listView3.Items.Count < QuantidadeMaxima(_tipoJogo))
            {
                listView3.Items.Add(textBox3.Text);              
            }

            textBox3.Text = string.Empty;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count > 0)
            {
                listView3.Items.Remove(
                    listView3.Items.Cast<ListViewItem>().LastOrDefault()
                );
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumeric(e);
        }

        private void isNumeric(KeyPressEventArgs e)
        {
            var tecla = e.KeyChar.ToString();
            if (!char.IsDigit(e.KeyChar) && !tecla.Equals("\b"))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente número!.");
            }
        }

        private int QuantidadeMaxima(ETipoJogo tipoJogo) 
        {
            switch (tipoJogo)
            {
                case ETipoJogo.Megasena:
                    return 6;
                case ETipoJogo.Lotomania:
                    return 50;
                case ETipoJogo.Quina:
                    return 5;
                case ETipoJogo.Duplasena:
                    return 12;
                default:
                    return 0;
            }
        }
    }
}
