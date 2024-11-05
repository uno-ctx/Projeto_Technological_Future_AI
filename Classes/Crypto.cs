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
            public static string HashPassword(string password)
            {
                using(SHA256 sha256Hash = SHA256.Create())
                {
                    // Converte a senha para bytes
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Converte os bytes para uma string hexadecimal
                    StringBuilder builder = new StringBuilder();
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}
