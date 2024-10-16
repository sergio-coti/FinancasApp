using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    public interface IContaDomainService
    {
        ContaResponseDto Criar(ContaRequestDto dto, Guid usuarioId);
        ContaResponseDto Alterar(Guid id, ContaRequestDto dto, Guid usuarioId);
        ContaResponseDto Excluir(Guid id, Guid usuarioId);

        List<ContaResponseDto> Consultar(Guid usuarioId, DateTime dataMin, DateTime dataMax);
        ContaResponseDto? ObterPorId(Guid id, Guid usuarioId);
    }
}
