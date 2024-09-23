using FinancasApp.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto request);

        AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto request);
    }
}
