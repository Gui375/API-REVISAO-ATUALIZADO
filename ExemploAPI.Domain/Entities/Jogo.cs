using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Domain.Entities
{
    public class Jogo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int primeiroNro { get; set; }

        public int segundoNro { get; set; }

        public int terceiroNro { get; set; }

        public int quartoNro { get; set; }

        public int quintoNro { get; set; }

        public int sextoNro { get; set; }
        public DateTime dataJogo { get; set; }
    }
}
