using ExemploAPI.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Data.Repositories
{
    internal class CartaRepository
    {
        private readonly string _cartasCaminhoArquivo;

        #region - Construtores
        public CartaRepository()
        {
            _cartasCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cartas.json");
        }
        #region Métodos arquivo
        private List<Carta> LerJogosDoArquivo()
        {
            if (!System.IO.File.Exists(_cartasCaminhoArquivo))
            {
                return new List<Carta>();
            }

            string json = System.IO.File.ReadAllText(_cartasCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Carta>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Carta> cartas = LerJogosDoArquivo();
            if (cartas.Any())
            {
                return cartas.Max(p => p.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverJogosNoArquivo(List<Carta> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(_cartasCaminhoArquivo, json);
        }
        #endregion


        public Carta Adicionar(Carta carta)
        {
            List<Carta> cartas = LerJogosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            carta.Id = proximoCodigo;
            cartas.Add(carta);
            EscreverJogosNoArquivo(cartas);
            return carta;

        }

        public Carta Atualizar(Carta carta)
        {
            throw new NotImplementedException();
        }

        public Carta BuscarPorId(int id)
        {
            List<Carta> cartas = LerJogosDoArquivo();
            Carta carta = cartas.Find(p => p.Id == id);
            return carta;
        }

        public IEnumerable<Carta> ObterTodos()
        {
            List<Carta> cartas = LerJogosDoArquivo();
            return cartas;
        }
    }
}
