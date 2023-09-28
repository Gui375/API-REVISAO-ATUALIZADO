using AutoMapper;
using ExemploAPI.Application.ViewModels;
using ExemploAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<JogoViewModel, Jogo>().ReverseMap();
            CreateMap<NovoJogoViewModel, NovoJogo>().ReverseMap();
            CreateMap<CartaViewModel, Carta>().ReverseMap();
        }
    }
}
