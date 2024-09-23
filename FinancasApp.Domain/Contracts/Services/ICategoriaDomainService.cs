using FinancasApp.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Services
{
    public interface ICategoriaDomainService
    {
        CategoriaResponseDto Criar(CategoriaRequestDto request, Guid usuarioId);
        CategoriaResponseDto Alterar(Guid id, CategoriaRequestDto request);
        CategoriaResponseDto Excluir(Guid id);
        List<CategoriaResponseDto> Consultar(Guid usuarioId);
        CategoriaResponseDto? ObterPorId(Guid id);
    }
}
