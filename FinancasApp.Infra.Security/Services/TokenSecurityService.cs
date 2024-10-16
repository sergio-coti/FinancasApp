using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Security;
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
    public class TokenSecurityService : ITokenSecurityService
    {
        public string CreateToken(Usuario usuario)
        {
            //chave para assinatura dos tokens (criptografia)
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtTokenSettings.SecretKey);

            //construindo o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravando o email do usuário no conteúdo do TOKEN (identificação do usuário)
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Id.ToString()) }),

                //data de expiração do TOKEN
                Expires = DateTime.UtcNow.AddHours(JwtTokenSettings.ExpirationInHours),

                //chave secreta para assinatura do TOKEN (antifalsificação)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                            SecurityAlgorithms.HmacSha256)
            };

            //gerando e retornando o TOKEN JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
