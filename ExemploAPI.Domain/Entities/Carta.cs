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
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Texto { get; private set; }
    }
}
