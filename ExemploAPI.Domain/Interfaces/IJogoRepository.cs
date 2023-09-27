using ExemploAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Domain.Interfaces
{
    public interface IJogoRepository
    {
        IEnumerable<Jogo> ObterTodos();
        Jogo BuscarPorId(int id);
        Jogo Adicionar(Jogo jogo);
        Jogo Atualizar(Jogo jogo);
    }
}
