using AutoMapper;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Mappings
{
    public class ProfileMap : Profile
    {
        //método construtor
        public ProfileMap()
        {
            CreateMap<CategoriaRequestDto, Categoria>();
            CreateMap<Categoria, CategoriaResponseDto>();

            CreateMap<ContaRequestDto, Conta>();
            CreateMap<Conta, ContaResponseDto>();
        }
    }
}
