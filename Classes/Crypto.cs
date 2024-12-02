using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Technological_Future_AI.Classes
{
    internal class Crypto
    {
        public class cryto_login
        {
            // Função para gerar o hash da senha com SHA256
            public static string HashPasswordWithSalt(string password, out string salt)
            {
                // Gera um salt aleatório
                byte[] saltBytes = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltBytes);
                }
                salt = Convert.ToBase64String(saltBytes);

                // Combina senha e salt
                string saltedPassword = password + salt;

                // Gera o hash com SHA256
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        builder.Append(hashBytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}
