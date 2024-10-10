using System.ComponentModel.DataAnnotations;

namespace FinancasApp.WEB.Models
{
    /// <summary>
    /// Modelo de dados para capturar o formulário de autenticação de usuário.
    /// </summary>
    public class AutenticarUsuarioModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}
