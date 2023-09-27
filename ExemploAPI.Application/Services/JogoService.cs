using AutoMapper;
using ExemploAPI.Application.Interfaces;
using ExemploAPI.Application.ViewModels;
using ExemploAPI.Domain.Entities;
using ExemploAPI.Domain.Interfaces;
using ExemploAPI.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Application.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IMapper _mapper;
        public JogoService(IJogoRepository jogoRepository, IMapper mapper)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
        }
        public JogoViewModel Adicionar(NovoJogoViewModel jogo)
        {
            var novoJogo = _mapper.Map<Jogo>(jogo);
            var result = _jogoRepository.Adicionar(novoJogo);
            return _mapper.Map<JogoViewModel>(result);
        }

        public JogoViewModel Atualizar(JogoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public JogoViewModel BuscarPorId(int id)
        {
            var result = _jogoRepository.BuscarPorId(id);
            return _mapper.Map<JogoViewModel>(result);
        }

        public IEnumerable<JogoViewModel> ObterTodos()
        {
            var jogos = _jogoRepository.ObterTodos();
            var jogosViewModel = _mapper.Map<IEnumerable<JogoViewModel>>(jogos);
            return jogosViewModel;
        }
    }
}
