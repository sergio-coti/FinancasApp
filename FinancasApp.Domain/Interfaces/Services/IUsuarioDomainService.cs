using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto dto);
        CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto dto);
    }
}
