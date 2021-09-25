using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softlotery.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int TipoJogo { get; set; }
        public string QtdaJogada { get; set; }
        public string Concurso { get; set; }
        public DateTime DataCriacao { get; set; }

        public Jogo()
        {
            DataCriacao = DateTime.UtcNow;
        }
    }
}
