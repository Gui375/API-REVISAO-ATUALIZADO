using ExemploAPI.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Application.Interfaces
{
    public interface IJogoService
    {
        IEnumerable<JogoViewModel> ObterTodos();
        JogoViewModel BuscarPorId(int id);
        JogoViewModel Adicionar(NovoJogoViewModel jogo);
        JogoViewModel Atualizar(JogoViewModel jogo);
    }
}
