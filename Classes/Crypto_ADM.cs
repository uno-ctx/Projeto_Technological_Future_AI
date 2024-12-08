using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Technological_Future_AI.Classes
{
    internal class Crypto_ADM
    {
       /* static void Main()
        {
            // Defina os valores necessários
            string senha = "Ctx2511"; // Substitua pela senha desejada
            string salt = GenerateSalt(); // Gera um novo salt

            // Gere o hash com o salt gerado
            string hashedPassword = HashPasswordWithSalt(senha, salt);

            // Exiba os valores em uma MessageBox
            System.Windows.Forms.MessageBox.Show($"Salt: {salt}\nHash: {hashedPassword}", "Resultado da Criação do Admin");
        }*/

        private void btnGerarHash_Click(object sender, EventArgs e)
        {
            string senha = "senhaDoAdm"; // Substitua pela senha desejada
            string salt = Crypto_ADM.GenerateSalt(); // Gera o Salt
            string hashedPassword = Crypto_ADM.HashPasswordWithSalt(senha, salt); // Gera o Hash

            // Formate os valores
            string resultado = $"Salt: {salt}\nHash: {hashedPassword}";

            // Copia para a área de transferência
            Clipboard.SetText(resultado);

            // Notifica o usuário
            MessageBox.Show("Salt e Hash gerados e copiados para a área de transferência!", "Sucesso");
        }

        // Método para gerar o salt
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Método para gerar o hash com o salt
        public static string HashPasswordWithSalt(string password, string salt)
        {
            string saltedPassword = password + salt;
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

