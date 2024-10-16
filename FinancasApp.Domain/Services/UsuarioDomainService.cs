using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Helpers;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Security;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributos
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenSecurityService _tokenSecurityService;

        //método construtor para injeção de dependência (inicialização) do atributo
        public UsuarioDomainService(IUsuarioRepository usuarioRepository, ITokenSecurityService tokenSecurityService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenSecurityService = tokenSecurityService;
        }

        public AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto dto)
        {
            //consultar o usuário no banco de dados através do email e da senha
            var usuario = _usuarioRepository.Get(dto.Email, CryptoHelper.GetSha256(dto.Senha));

            //verificando se o usuário não foi encontrado
            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuário não foi encontrado.");

            //retornar os dados do usuário autenticado
            return new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = DateTime.Now.AddHours(1),
                Token = _tokenSecurityService.CreateToken(usuario)
            };
        }

        public CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto dto)
        {
            //verificar se o email já está cadastrado no banco de dados
            if (_usuarioRepository.VerifyExists(dto.Email))
                throw new ApplicationException("O email informado já está cadastrado para outro usuário.");

            //capturar os dados do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = CryptoHelper.GetSha256(dto.Senha),
            };

            //gravar o usuário no banco de dados
            _usuarioRepository.Add(usuario);

            //retornar os dados do usuário cadastrado
            return new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now
            };
        }
    }
}
