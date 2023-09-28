using ExemploAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Domain.Interfaces
{
    public interface ICartaRepository
    {
        IEnumerable<Carta> ObterTodos();
        Task<Carta> ObterPorId(int id);
        Task<IEnumerable<Carta>> ObterPorCategoria(int codigo);
        void Adicionar(Carta crianca);
        void Atualizar(Carta crianca);
    }
}
