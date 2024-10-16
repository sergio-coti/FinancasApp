using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    public interface ICategoriaDomainService
    {
        CategoriaResponseDto Criar(CategoriaRequestDto dto, Guid usuarioId);
        CategoriaResponseDto Alterar(Guid id, CategoriaRequestDto dto, Guid usuarioId);
        CategoriaResponseDto Excluir(Guid id, Guid usuarioId);

        List<CategoriaResponseDto> Consultar(Guid usuarioId);
        CategoriaResponseDto? ObterPorId(Guid id, Guid usuarioId);
    }
}
