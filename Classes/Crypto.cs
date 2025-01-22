using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Technological_Future_AI.Classes
{
    internal static class Crypto // Classe para lógica de hash
    {
        public static class CrytoLogin
        {
            // Método para gerar o hash com um salt existente
            public static string HashPasswordWithExistingSalt(string password, string salt)
            {
                // Verificação de validação do password e salt
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("A senha não pode ser nula ou vazia.");
                }
                if (string.IsNullOrWhiteSpace(salt))
                {
                    throw new ArgumentException("Salt não pode ser nulo ou vazio.");
                }

                // Concatenando senha com salt
                string saltedPassword = password + salt;

                // Usando o algoritmo SHA256 para gerar o hash
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    StringBuilder builder = new StringBuilder();
                    foreach (var b in hashBytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}