using System.Security.Cryptography;
using System.Text;

namespace FinancasApp.Domain.Helpers
{
    /// <summary>
    /// Classe auxiliar para implementarmos rotinas de criptografia
    /// </summary>
    public class CryptoHelper
    {
        /// <summary>
        /// Gera o hash SHA-256 de uma string
        /// </summary>
        public static string GetSHA256(string value)
        {
            // Cria uma nova instância da classe SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string de entrada para um array de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(value);

                // Computa o hash dos bytes
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Converte o hash em formato hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}