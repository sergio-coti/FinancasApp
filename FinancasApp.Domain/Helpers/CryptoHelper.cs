using System.Security.Cryptography;
using System.Text;

namespace FinancasApp.Domain.Helpers
{
    public class CryptoHelper
    {
        public static string GetSha256(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

                var builder = new StringBuilder();
                foreach (var item in bytes)
                    builder.Append(item.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
