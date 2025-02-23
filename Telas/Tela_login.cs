using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Technological_Future_AI.Classes;
using System.Data.SQLite;
using Technological_Future_AI.Properties;
using System.Collections.Generic;
using System.Text;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_login : Form
    {
        public Tela_login()
        {
            InitializeComponent();
            BMT_SignUp.Visible = false;
            tb_username.Focus();
            pnl_linha_username.BackColor = Color.White;
            pnl_linha_password.BackColor = Color.White;
            this.KeyPreview = true;
            // Inicializa a senha oculta com '*'
            BMT_Password.UseSystemPasswordChar = true;
            BMT_Password.PasswordChar = '\0'; // Evita conflito
            BMT_Re_Enter_Password.UseSystemPasswordChar = true;
            BMT_Re_Enter_Password.PasswordChar = '\0';
            tb_password.UseSystemPasswordChar = true;
            tb_password.PasswordChar = '\0';
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;        

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);  
      
        private void Tela_login_Activated(object sender, EventArgs e)
        {
            tb_username.Focus();
        }     

        private void Tela_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // btn_login_Click(sender, e); // Chama o método de clique do botão diretamente
                e.Handled = true; // Evita comportamentos padrões adicionais
            }
        }

        private void lbl_fechar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lbl_SignUp_Click(object sender, EventArgs e)
        {
            BMT_SignUp.Visible = true;
            corpo.Visible = false;
            label3.Visible = false;
        }

        private void lbl_LogIn_Click(object sender, EventArgs e)
        {
            BMT_SignUp.Visible = false;
        }

        private void Tela_login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BMT_SignUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_position_Click(object sender, EventArgs e)
        {
            btn_position.Text = "POSITION";

            if (corpo.Visible)
            {
                // Se o corpo1 já estiver visível, ocultá-lo
                corpo.Visible = false;
                btn_position.Image = Resources.seta_para_baixo;
            }
            else
            {
                // Se não estiver visível, mostrá-lo
                corpo.Visible = true;

                // Certifique-se de ocultar outros corpos
                btn_position.Image = Resources.setas_para_cima;
            }
        }

        private void btn_presidente_Click(object sender, EventArgs e)
        {
            btn_position.Text = "PRESIDENTE";
            corpo.Visible = false;
        }

        private void btn_diretor_Click(object sender, EventArgs e)
        {
            btn_position.Text = "DIRETOR(A)";
            corpo.Visible = false;
        }

        private void btn_coordenador_Click(object sender, EventArgs e)
        {
            btn_position.Text = "COORDENADOR(A)";
            corpo.Visible = false;
        }

        private void btn_supervisor_Click(object sender, EventArgs e)
        {
            btn_position.Text = "SUPERVISOR(A)";
            corpo.Visible = false;
        }

        private void btn_analista_Click(object sender, EventArgs e)
        {
            btn_position.Text = "ANALISTA";
            corpo.Visible = false;
        }    

        private void lbl_fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.Red;
        }

        private void lbl_fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.White;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Os campos 'username' e 'password' são obrigatórios.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "SELECT T_SENHA_USUARIOS, T_SALT, T_Desc_Nivel_Usuarios, T_Code_Name, N_Nivel_Usuarios FROM TB_USUARIOS WHERE T_USERNAME = @username";
                DataTable dt = Classes.Banco.Consulta(sql, new Dictionary<string, object> { { "@username", username } });

                if (dt.Rows.Count == 1)
                {
                    string storedHash = dt.Rows[0]["T_SENHA_USUARIOS"] as string ?? string.Empty;
                    string salt = dt.Rows[0]["T_SALT"] as string ?? string.Empty;

                    if (!string.IsNullOrEmpty(storedHash) && !string.IsNullOrEmpty(salt))
                    {
                        string inputHash = Classes.Crypto.CrytoLogin.HashPasswordWithExistingSalt(password, salt);

                        if (storedHash == inputHash)
                        {
                            // Dados do usuário
                            string descricaoNivel = dt.Rows[0]["T_Desc_Nivel_Usuarios"] as string ?? string.Empty;
                            int nivelUsuarios = dt.Rows[0]["N_Nivel_Usuarios"] != DBNull.Value
                                ? Convert.ToInt32(dt.Rows[0]["N_Nivel_Usuarios"])
                                : 0;
                            string codeName = dt.Rows[0]["T_Code_Name"] as string ?? string.Empty;

                            // Login bem-sucedido
                            Telas.Tela_menu tm = new Telas.Tela_menu
                            {
                                lbl_acesso = { Text = nivelUsuarios.ToString() },
                                lbl_usuarios = { Text = codeName },
                                pct_On_Off = { Image = Properties.Resources.Ligado },
                                lbl_cargo = { Text = descricaoNivel }
                            };

                            Globais.nivel = nivelUsuarios;
                            Globais.logado = true;


                            tm.ShowDialog();
                            this.Close();
                            return;
                        }
                    }
                }

                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_password.Clear();
                tb_username.Clear();
                tb_username.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_AlterarSenha_Click(object sender, EventArgs e)
        {
            Telas.AlterarSenha AS = new Telas.AlterarSenha();
            AS.Show();
            this.Hide();
            AS.tb_password.PasswordChar = '*';
        }

   

        private void btn_login_MouseEnter(object sender, EventArgs e)
        {
            btn_login.FlatAppearance.BorderSize = 1;
            btn_login.FlatAppearance.BorderColor = Color.Lime;
            btn_login.ForeColor = Color.Lime;
        }

        private void btn_login_MouseLeave(object sender, EventArgs e)
        {
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.FlatAppearance.BorderColor = Color.Empty;
            btn_login.ForeColor = Color.White;
        }

        private void lbl_SignUp_MouseEnter_1(object sender, EventArgs e)
        {
            lbl_SignUp.FlatAppearance.BorderSize = 1;
            lbl_SignUp.FlatAppearance.BorderColor = Color.Lime;
            lbl_SignUp.ForeColor = Color.Lime;
        }

        private void lbl_SignUp_MouseLeave_1(object sender, EventArgs e)
        {
            lbl_SignUp.FlatAppearance.BorderSize = 0;
            lbl_SignUp.FlatAppearance.BorderColor = Color.Empty;
            lbl_SignUp.ForeColor = Color.White;
        }

        private void lbl_AlterarSenha_MouseEnter(object sender, EventArgs e)
        {
            lbl_AlterarSenha.FlatAppearance.BorderSize = 1;
            lbl_AlterarSenha.FlatAppearance.BorderColor = Color.Lime;
            lbl_AlterarSenha.ForeColor = Color.Lime;
        }

        private void lbl_AlterarSenha_MouseLeave(object sender, EventArgs e)
        {
            lbl_AlterarSenha.FlatAppearance.BorderSize = 0;
            lbl_AlterarSenha.FlatAppearance.BorderColor = Color.Empty;
            lbl_AlterarSenha.ForeColor = Color.White;
        }

        private void checkBox3_MouseEnter(object sender, EventArgs e)
        {
            checkBox3.FlatAppearance.BorderSize = 1;
            checkBox3.FlatAppearance.BorderColor = Color.Lime;
            checkBox3.ForeColor = Color.Lime;
        }

        private void checkBox3_MouseLeave(object sender, EventArgs e)
        {
            checkBox3.FlatAppearance.BorderSize = 0;
            checkBox3.FlatAppearance.BorderColor = Color.Empty;
            checkBox3.ForeColor = Color.White;
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos de entrada e remove espaços em branco extras
            string fullname = BMT_Full_Name.Text.Trim();
            string email = BMT_Email.Text.Trim();
            string password = BMT_Password.Text.Trim();
            string reEnterPassword = BMT_Re_Enter_Password.Text.Trim();
            string cargoSelecionado = btn_position.Text.Trim();
            string celular = tb_celular.Text.Trim();
            BMT_SignUp.Visible = false;

            // Validação para garantir que nenhum campo obrigatório está vazio
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(reEnterPassword) ||
                string.IsNullOrWhiteSpace(cargoSelecionado) || string.IsNullOrWhiteSpace(celular))
            {
                MessageBox.Show("Todos os campos são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BMT_SignUp.Visible = true;
                // Limpa os campos de entrada
                BMT_Full_Name.Text = string.Empty;
                BMT_Email.Text = string.Empty;
                BMT_Password.Text = string.Empty;
                BMT_Re_Enter_Password.Text = string.Empty;
                tb_celular.Text = string.Empty;
                btn_position.Text = "POSITION"; // Exemplo: redefinir o texto do botão para o padrão
                return;
            }

            // Verificação se as senhas informadas são iguais
            if (password != reEnterPassword)
            {
                MessageBox.Show("As senhas estão diferentes! Por favor, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Limpa os campos de entrada
                BMT_Full_Name.Text = string.Empty;
                BMT_Email.Text = string.Empty;
                BMT_Password.Text = string.Empty;
                BMT_Re_Enter_Password.Text = string.Empty;
                tb_celular.Text = string.Empty;
                btn_position.Text = "POSITION"; // Exemplo: redefinir o texto do botão para o padrão
                return;
            }

            // Gera um salt único
            string salt = Guid.NewGuid().ToString();

            // Gera o hash da senha com o salt gerado
            string hashedPassword = Crypto.CrytoLogin.HashPasswordWithExistingSalt(password, salt);

            // Divide o nome completo em primeiro e último nome

            string[] nameParts = fullname.Split(' ');
            string primeiroNome = nameParts[0];
            string ultimoNome = nameParts.Length > 1 ? nameParts[nameParts.Length - 1] : string.Empty;
            string username = $"{primeiroNome}.{ultimoNome}".ToLower();
            string codeName = $"{primeiroNome} {ultimoNome}";

            // Define os valores do status e nível de acordo com o cargo selecionado
            int nivelUsuario = 0;
            string descNivelUsuario = string.Empty;
            cargoSelecionado = cargoSelecionado.ToLower().Trim();
            switch (cargoSelecionado)
            {
                case "analista":
                    nivelUsuario = 1;
                    descNivelUsuario = "Analista";
                    break;
                case "supervisor":
                case "supervisor(a)":
                    nivelUsuario = 2;
                    descNivelUsuario = "Supervisor";
                    break;
                case "coordenador":
                case "coordenador(a)": // Permite variações como "Coordenador(a)"
                    nivelUsuario = 3;
                    descNivelUsuario = "Coordenador";
                    break;
                case "diretor":
                case "diretor(a)":
                    nivelUsuario = 4;
                    descNivelUsuario = "Diretor";
                    break;
                case "presidente":
                    nivelUsuario = 5;
                    descNivelUsuario = "Presidente";
                    break;
                default:
                    MessageBox.Show("Cargo inválido! Por favor, selecione um cargo válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Caminho do banco de dados SQLite
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\banco\Banco.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                // Conexão com o banco de dados
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Verifica se o e-mail ou username já existe
                    string checkSql = "SELECT COUNT(1) FROM TB_USUARIOS WHERE T_EMail = @Email OR T_Username = @Username";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        checkCmd.Parameters.AddWithValue("@Username", username);

                        int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (userCount > 0)
                        {
                            MessageBox.Show("Usuário ou e-mail já cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Comando SQL para inserir um novo usuário
                    string sql = @"
                    INSERT INTO TB_USUARIOS 
                    (T_Nome_Usuario, T_Username, T_Senha_Usuarios, T_Status_Usuarios, T_Desc_Status_Usuarios, 
                    N_Nivel_Usuarios, T_Desc_Nivel_Usuarios, T_Code_Name, T_EMail, T_Salt, N_Telefone_Usuario) 
                    VALUES 
                    (@fullname, @username, @password, 'A', 'Ativo', 
                    @nivelUsuario, @descNivelUsuario, @codeName, @Email, @salt, @celular)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@nivelUsuario", nivelUsuario);
                        cmd.Parameters.AddWithValue("@descNivelUsuario", descNivelUsuario);
                        cmd.Parameters.AddWithValue("@codeName", codeName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@salt", salt);
                        cmd.Parameters.AddWithValue("@celular", celular);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos de entrada
                BMT_Full_Name.Text = string.Empty;
                BMT_Email.Text = string.Empty;
                BMT_Password.Text = string.Empty;
                BMT_Re_Enter_Password.Text = string.Empty;
                tb_celular.Text = string.Empty;
                btn_position.Text = "POSITION"; // Exemplo: redefinir o texto do botão para o padrão
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void voltarLogin_Click(object sender, EventArgs e)
        {
            BMT_SignUp.Visible = false;
        }

        private void btn_signup_MouseEnter(object sender, EventArgs e)
        {
            btn_signup.FlatAppearance.BorderSize = 1;
            btn_signup.FlatAppearance.BorderColor = Color.Lime;
            btn_signup.ForeColor = Color.Lime;
        }

        private void btn_signup_MouseLeave(object sender, EventArgs e)
        {
            btn_signup.FlatAppearance.BorderSize = 0;
            btn_signup.FlatAppearance.BorderColor = Color.Empty;
            btn_signup.ForeColor = Color.White;
        }

        private void voltarLogin_MouseEnter(object sender, EventArgs e)
        {
            voltarLogin.FlatAppearance.BorderSize = 1;
            voltarLogin.FlatAppearance.BorderColor = Color.Lime;
            voltarLogin.ForeColor = Color.Lime;
        }

        private void voltarLogin_MouseLeave(object sender, EventArgs e)
        {
            voltarLogin.FlatAppearance.BorderSize = 0;
            voltarLogin.FlatAppearance.BorderColor = Color.Empty;
            voltarLogin.ForeColor = Color.White;
        }

        private void check_traducao_MouseEnter(object sender, EventArgs e)
        {
            check_traducao.FlatAppearance.BorderSize = 1;
            check_traducao.FlatAppearance.BorderColor = Color.Lime;
            check_traducao.ForeColor = Color.Lime;
        }

        private void check_traducao_MouseLeave(object sender, EventArgs e)
        {
            check_traducao.FlatAppearance.BorderSize = 0;
            check_traducao.FlatAppearance.BorderColor = Color.Empty;
            check_traducao.ForeColor = Color.White;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_password.Text))
            {
                tb_password.PasswordChar = '\0';
                tb_password.UseSystemPasswordChar = !tb_password.UseSystemPasswordChar;

                ValidacaoSenha2.Image = tb_password.UseSystemPasswordChar
                    ? Properties.Resources.fechar_o_olho2
                    : Properties.Resources.olho2;
            }
        }     

        private void ValidacaoSenha_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BMT_Password.Text))
            {
                // Remove conflito com PasswordChar
                BMT_Password.PasswordChar = '\0';

                // Alterna a visibilidade da senha
                BMT_Password.UseSystemPasswordChar = !BMT_Password.UseSystemPasswordChar;

                // Atualiza o ícone
                ValidacaoSenha.Image = BMT_Password.UseSystemPasswordChar
                    ? Properties.Resources.fechar_o_olho
                    : Properties.Resources.olho;
            }
        }

        private void ValidacaoSenha2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BMT_Re_Enter_Password.Text))
            {
                BMT_Re_Enter_Password.PasswordChar = '\0';
                BMT_Re_Enter_Password.UseSystemPasswordChar = !BMT_Re_Enter_Password.UseSystemPasswordChar;

                ValidacaoSenha2.Image = BMT_Re_Enter_Password.UseSystemPasswordChar
                    ? Properties.Resources.fechar_o_olho2
                    : Properties.Resources.olho2;
            }
        }

    }
}



