using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Technological_Future_AI.Classes
{
    internal class Banco
    {
        private readonly string connectionString = $"Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "your_database.db")};Version=3;";

        // Método para criar e retornar a conexão com o banco de dados
        private static SQLiteConnection ConexaoBanco()
        {
            try
            {
                // Caminho dinâmico baseado no diretório da apli cação
                string caminhoBanco = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\banco\Banco.db");

                // Verifica se o arquivo do banco existe
                if (!File.Exists(caminhoBanco))
                {
                    throw new FileNotFoundException($"O arquivo do banco de dados não foi encontrado no caminho: {caminhoBanco}");
                }

                // Retorna uma nova conexão
                return new SQLiteConnection($"Data Source={caminhoBanco};Version=3;");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar ao banco de dados. Caminho: {AppDomain.CurrentDomain.BaseDirectory}. Detalhes: {ex.Message}");
            }
        }

        // Método para obter todos os usuários da tabela TB_USUARIOS
        public static DataTable ObterTodosUsuarios()
        {
            DataTable dt = new DataTable();
            using (var conexao = ConexaoBanco())
            {
                try
                {
                    conexao.Open();
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM TB_USUARIOS";
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao obter usuários: {ex.Message}");
                }
            }
            return dt;
        }

        // Método genérico para realizar consultas
        public static DataTable Consulta(string sql)
        {
            DataTable dt = new DataTable();
            using (var conexao = ConexaoBanco())
            {
                try
                {
                    conexao.Open();
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao executar consulta: {ex.Message}");
                }
            }
            return dt;
        }
    }
}
