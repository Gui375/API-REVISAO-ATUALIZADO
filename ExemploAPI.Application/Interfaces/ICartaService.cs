using ExemploAPI.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Application.Interfaces
{
    public interface ICartaService
    {
        IEnumerable<CartaViewModel> ObterTodos();
        Task<CartaViewModel> ObterPorId(int id);
        Task<IEnumerable<CartaViewModel>> ObterPorCategoria(int codigo);

        void Adicionar(CartaViewModel NovaCriancaViewMoel);
        void Atualizar(CartaViewModel produto);
    }
}
