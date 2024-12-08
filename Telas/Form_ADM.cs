using System;
using System.Data.SQLite;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Technological_Future_AI.Telas
{
    public partial class Form_ADM : Form
    {
        

        public Form_ADM()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
            this.KeyPreview = true; // Permite que o formulário capture as teclas pressionadas
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_ADM_KeyDown);          
        }


        private void SalvarNoBancoDeDados(int idUsuario, string salt, string hashSenha)
        {
            // Caminho do banco de dados SQLite
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\banco\Banco.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                // Conexão com o banco de dados
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open(); // Abre a conexão

                    // Comando SQL para atualizar Salt e Hash da senha para o usuário ADM
                    string sql = @"
                UPDATE TB_USUARIOS 
                SET T_Salt = @salt, 
                    T_Senha_Usuarios = @hashSenha 
                WHERE N_ID_Usuarios = @idUsuario";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Adiciona os parâmetros
                        cmd.Parameters.AddWithValue("@salt", salt);
                        cmd.Parameters.AddWithValue("@hashSenha", hashSenha);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        // Executa o comando
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Verifica se a atualização foi bem-sucedida
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Salt e hash da senha atualizados com sucesso para o usuário ADM.");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma linha foi atualizada. Verifique o ID do usuário.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro no console
                Console.WriteLine($"Erro ao atualizar o banco de dados: {ex.Message}");
            }
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            string senha = texBox1.Text; // Entrada da senha fornecida
            int idUsuario = 4;          // ID fixo do usuário "ADM"

            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("A senha não pode estar vazia!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gerar Salt
            string salt = GerarSalt();

            // Gerar Hash da senha combinada com o Salt
            string hashSenha = GerarHash(senha, salt);

            // Salvar Salt e Hash no banco de dados
            SalvarNoBancoDeDados(idUsuario, salt, hashSenha);
        }

        private string GerarSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string GerarHash(string senha, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combina a senha com o Salt
                string senhaComSalt = senha + salt;
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senhaComSalt));
                return Convert.ToBase64String(hashBytes);
            }
        }


        private void Form_ADM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_criar.PerformClick(); // Simula o clique no botão btn_criar
            }
        }
    }
}
