using FinancasApp.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Services
{
    public interface IContaDomainService
    {
        ContaResponseDto Criar(ContaRequestDto request, Guid usuarioId);
        ContaResponseDto Alterar(Guid id, ContaRequestDto request);
        ContaResponseDto Excluir(Guid id);
        List<ContaResponseDto> Consultar(DateTime dataMin, DateTime dataMax, Guid usuarioId);
        ContaResponseDto? ObterPorId(Guid id);
    }
}
