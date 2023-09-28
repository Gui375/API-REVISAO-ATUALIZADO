using ExemploAPI.Domain.Entities;
using ExemploAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly string _produtoCaminhoArquivo;

        #region - Construtores
        public JogoRepository()
        {
            _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");
        }
        #endregion
        #region Métodos arquivo
        private List<Jogo> LerJogosDoArquivo()
        {
            if (!System.IO.File.Exists(_produtoCaminhoArquivo))
            {
                return new List<Jogo>();
            }

            string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Jogo>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Jogo> jogos = LerJogosDoArquivo();
            if (jogos.Any())
            {
                return jogos.Max(p => p.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverJogosNoArquivo(List<Jogo> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
        }
        #endregion


        public Jogo Adicionar(Jogo jogo)
        {
            List<Jogo> jogos = LerJogosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            jogo.Id = proximoCodigo;
            jogos.Add(jogo);
            EscreverJogosNoArquivo(jogos);
            return jogo;

        }

        public Jogo Atualizar(Jogo produto)
        {
            throw new NotImplementedException();
        }

        public Jogo BuscarPorId(int id)
        {
            List<Jogo> jogos = LerJogosDoArquivo();
            Jogo jogo = jogos.Find(p => p.Id == id);
            return jogo;
        }

        public IEnumerable<Jogo> ObterTodos()
        {
            List<Jogo> jogos = LerJogosDoArquivo();
            return jogos;
        }
    }
}
