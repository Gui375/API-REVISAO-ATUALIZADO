using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExemploAPI.Domain.Entities
{
    public class Carta
    {
        public Carta(int id, string nome, int idade,  string bairro, string rua, int numero, string cidade, string estado, string texto)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Texto = texto;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Texto { get; set; }
    }
}
