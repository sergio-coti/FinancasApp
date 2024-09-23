using FinancasApp.Domain.Contracts.Repositories;
using FinancasApp.Domain.Contracts.Security;
using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Helpers;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Models.Entities;
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
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtTokenService = jwtTokenService;
        }

        public CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto request)
        {
            //verificar se o email informado já está cadastrado no banco de dados
            if (_usuarioRepository.Get(request.Email) != null)
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");

            //caoturar os dados do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = CryptoHelper.GetSHA256(request.Senha)
            };

            //gravar o usuário no banco de dados
            _usuarioRepository.Add(usuario);

            //retornar os dados do usuário cadastrado
            var response = new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now
            };

            return response;
        }

        public AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto request)
        {
            //buscar o usuário no banco de dados através do email e da senha
            var usuario = _usuarioRepository.Get(request.Email, CryptoHelper.GetSHA256(request.Senha));

            //verificar se o usuário não foi encontrado
            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuário não encontrado.");

            //retornando os dados do usuário autenticado
            var response = new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = _jwtTokenService.GetJwtToken(usuario),
                DataHoraAcesso = DateTime.Now
            };

            return response;
        }
    }
}
