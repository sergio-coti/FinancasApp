using FinancasApp.Domain.Contracts.Security;
using FinancasApp.Domain.Models.Entities;
using FinancasApp.Infra.Security.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Security.Services
{
    /// <summary>
    /// Classe para implementação da interface definida no domínio
    /// </summary>
    public class JwtTokenService : IJwtTokenService
    {
        public string GetJwtToken(Usuario usuario)
        {
            //capturando a chave para assinar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            //gerando o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //identificação do usuário autenticado
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),

                //data de expiração do token
                Expires = DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours),

                //criptografando a chave para assinatura do token
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //gerando e retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
