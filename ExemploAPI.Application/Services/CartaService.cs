using AutoMapper;
using ExemploAPI.Application.Interfaces;
using ExemploAPI.Application.ViewModels;
using ExemploAPI.Domain.Entities;
using ExemploAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Application.Services
{
    public class CartaService : ICartaService
    {
        private readonly ICartaRepository _cartaRepository;
        private IMapper _mapper;

        public CartaService(ICartaRepository cartaRepository, IMapper mapper)
        {
            _cartaRepository = cartaRepository;
            _mapper = mapper;
        }

        public void Adicionar(CartaViewModel NovaCriancaViewMoel)
        {
            var NovaCrianca = _mapper.Map<Carta>(NovaCriancaViewMoel);
            _cartaRepository.Adicionar(NovaCrianca);
        }

        public void Atualizar(CartaViewModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartaViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<CartaViewModel> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CartaViewModel>>(_cartaRepository.ObterTodos());
        }
    }
}
}
