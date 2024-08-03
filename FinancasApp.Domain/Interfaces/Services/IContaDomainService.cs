using FinancasApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para a entidade conta
    /// </summary>
    public interface IContaDomainService
    {
        ContaResponseDto? Criar(ContaRequestDto dto);
        ContaResponseDto? Alterar(Guid id, ContaRequestDto dto);
        ContaResponseDto? Excluir(Guid id);

        List<ContaResponseDto>? Consultar(DateTime dataMin, DateTime dataMax);
        ContaResponseDto? ObterPorId(Guid id);
    }
}
