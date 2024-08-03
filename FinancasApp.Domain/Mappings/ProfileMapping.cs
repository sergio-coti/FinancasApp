using AutoMapper;
using FinancasApp.Domain.Dtos;
using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Mappings
{
    /// <summary>
    /// Classe para configurar os mapeamentos feitos pelo AutoMapper
    /// </summary>
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<ContaRequestDto, Conta>()
                .AfterMap((dto, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.Tipo = (TipoConta?) dto.Tipo;
                });

            CreateMap<Conta, ContaResponseDto>()
                .AfterMap((entity, dto) =>
                {
                    dto.Tipo = entity.Tipo.ToString();
                });
        }
    }
}
