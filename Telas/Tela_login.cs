using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Technological_Future_AI.Classes;
using System.Data.SQLite;
using Bunifu.Framework.UI;
using Technological_Future_AI.Properties;
using System.Collections.Generic;

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
            BMT_Full_Name.Text = "FULL NAME";
            BMT_Email.Text = "EMAIL";
            BMT_Password.Text = "PASSWORD";
            BMT_Re_Enter_Password.Text = "RE-ENTER PASSWORD";
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;        

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void ResetTextBoxStyles()
        {
            // Restaurar estilos de todos os controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;

            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;

            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;

            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void HandleFocusEnter(Bunifu.Framework.UI.BunifuMetroTextbox textBox, string defaultText)
        {
            // Limpar o texto apenas se for o padrão
            if (textBox.Text == defaultText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.White;
            }

            ResetTextBoxStyles();

            // Alterar borda do controle focado
            textBox.BorderColorFocused = Color.DeepSkyBlue;
            textBox.BorderColorMouseHover = Color.DeepSkyBlue;
        }

        private void HandleFocusLeave(Bunifu.Framework.UI.BunifuMetroTextbox textBox, string defaultText)
        {
            // Restaurar texto padrão se estiver vazio
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = defaultText;
                textBox.ForeColor = Color.Silver;
            }
        }

        private void Tela_login_Load(object sender, EventArgs e)
        {
            tb_username.Focus();
            foreach (Control control in this.Controls)
            {
                if (control is Bunifu.Framework.UI.BunifuMetroTextbox textbox)
                {
                    textbox.Enter += TextBox_Enter;
                }
            }
        }

        private void Tela_login_Activated(object sender, EventArgs e)
        {
            tb_username.Focus();
        }

        private void check_traducao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_traducao.Checked)
            {
                BMT_Full_Name.Text = "NOME COMPLETO";
                BMT_Email.Text = "E-MAIL";
                BMT_Password.Text = "SENHA";
                BMT_Re_Enter_Password.Text = "DIGITE NOVAMENTE A SENHA";
            }
            else
            {
                BMT_Full_Name.Text = "Full Name";
                BMT_Email.Text = "E-mail";
                BMT_Password.Text = "Password";
                BMT_Re_Enter_Password.Text = "Re-enter Password";
            }
        }

        private void Tela_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e); // Chama o método de clique do botão diretamente
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

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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
                            string descricaoNivel = dt.Rows[0]["T_Desc_Nivel_Usuarios"] as string ?? string.Empty;
                            string codeName = dt.Rows[0]["T_Code_Name"] as string ?? string.Empty;
                            int nivelUsuarios = 0;

                            if (dt.Rows[0]["N_Nivel_Usuarios"] != DBNull.Value)
                            {
                                int.TryParse(dt.Rows[0]["N_Nivel_Usuarios"].ToString(), out nivelUsuarios);
                            }

                            // Login bem-sucedido
                            Telas.Tela_menu tm = new Telas.Tela_menu
                            {
                                lbl_acesso = { Text = descricaoNivel },
                                lbl_usuarios = { Text = codeName },
                                pct_On_Off = { Image = Properties.Resources.Ligado },
                                lbl_cargo = { Text = descricaoNivel }
                            };

                            Globais.nivel = nivelUsuarios;
                            Globais.logado = true;

                            this.Hide();
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

        private void UpdatePlaceholder(BunifuMaterialTextbox textBox, string placeholder, bool isEntering)
        {
            if (isEntering)
            {
                if (textBox.Text == placeholder && textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;

                    if (textBox.Name == "BMT_Password" || textBox.Name == "BMT_Re_Enter_Password")
                    {
                        textBox.isPassword = true;
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;

                    if (textBox.Name == "BMT_Password" || textBox.Name == "BMT_Re_Enter_Password")
                    {
                        textBox.isPassword = false;
                    }
                }
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            BunifuMaterialTextbox textBox = sender as BunifuMaterialTextbox;
            UpdatePlaceholder(textBox, textBox.Tag.ToString(), true);
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos de entrada e remove espaços em branco extras
            string fullname = BMT_Full_Name.Text.Trim(); // Nome completo do usuário
            string email = BMT_Email.Text.Trim();       // E-mail do usuário
            string password = BMT_Password.Text.Trim(); // Senha do usuário
            string reEnterPassword = BMT_Re_Enter_Password.Text.Trim(); // Confirmação da senha
            string cargoSelecionado = btn_position.Text.Trim(); // Cargo selecionado no sistema
            BMT_SignUp.Visible = false; // Oculta o botão de cadastro após o clique (opcional)

            // Validação para garantir que nenhum campo obrigatório está vazio
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(reEnterPassword) ||
                string.IsNullOrWhiteSpace(cargoSelecionado))
            {
                MessageBox.Show("Todos os campos são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Interrompe o fluxo caso os campos estejam vazios
            }

            // Verificação se as senhas informadas são iguais
            if (password != reEnterPassword)
            {
                MessageBox.Show("As senhas estão diferentes! Por favor, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Interrompe o fluxo caso as senhas não coincidam
            }

            // Gera o hash da senha com um salt existente (sem usar out)
            string salt = "algum_valor_de_salt"; // Defina o valor do salt
            string hashedPassword = Classes.Crypto.CrytoLogin.HashPasswordWithExistingSalt(password, salt);

            // Divide o nome completo em primeiro e último nome
            string[] nameParts = fullname.Split(' ');
            string primeiroNome = nameParts[0];
            string ultimoNome = nameParts.Length > 1 ? nameParts[nameParts.Length - 1] : string.Empty;
            string username = $"{primeiroNome}.{ultimoNome}".ToLower(); // Gera o username no formato primeiro.ultimo
            string codeName = $"{primeiroNome} {ultimoNome}"; // Combinação do primeiro e último nome

            // Define os valores do status e nível de acordo com o cargo selecionado
            int nivelUsuario = 0;
            string descNivelUsuario = string.Empty;
            switch (cargoSelecionado.ToLower())
            {
                case "analista":
                    nivelUsuario = 1;
                    descNivelUsuario = "Analista";
                    break;
                case "supervisor":
                    nivelUsuario = 2;
                    descNivelUsuario = "Supervisor";
                    break;
                case "coordenador(a)":
                    nivelUsuario = 3;
                    descNivelUsuario = "Coordenador";
                    break;
                case "diretor":
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
                    conn.Open(); // Abre a conexão

                    // Comando SQL para inserir um novo usuário
                    string sql = @"
                INSERT INTO TB_USUARIOS 
                (T_Nome_Usuario, T_Username, T_Senha_Usuarios, T_Status_Usuarios, T_Desc_Status_Usuarios, 
                 N_Nivel_Usuarios, T_Desc_Nivel_Usuarios, T_Code_Name, T_EMail, T_Salt) 
                VALUES 
                (@fullname, @username, @password, 'A', 'Ativo', 
                 @nivelUsuario, @descNivelUsuario, @codeName, @Email, @salt)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Adiciona os parâmetros
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@nivelUsuario", nivelUsuario);
                        cmd.Parameters.AddWithValue("@descNivelUsuario", descNivelUsuario);
                        cmd.Parameters.AddWithValue("@codeName", codeName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        // Executa o comando
                        cmd.ExecuteNonQuery();
                    }
                }

                // Mensagem de sucesso
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BMT_Full_Name_Click(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Full_Name.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Full_Name.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;            
        }

        private void BMT_Full_Name_MouseEnter(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Full_Name.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Full_Name.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void BMT_Full_Name_Enter(object sender, EventArgs e)
        {
            HandleFocusEnter(BMT_Full_Name, "FULL NAME");
        }        

        private void BMT_Full_Name_Leave(object sender, EventArgs e)
        {
            HandleFocusLeave(BMT_Full_Name, "FULL NAME");
        }

        private void BMT_Email_Click(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Email.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Email.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void BMT_Email_MouseEnter(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Email.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Email.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void BMT_Email_Enter(object sender, EventArgs e)
        {
            HandleFocusEnter(BMT_Email, "EMAIL");
        }     

        private void BMT_Email_Leave(object sender, EventArgs e)
        {
            HandleFocusLeave(BMT_Email, "EMAIL");
        }

        private void BMT_Password_Click(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Password.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Password.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void BMT_Password_MouseEnter(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Password.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Password.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Re_Enter_Password.BorderColorFocused = Color.Empty;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.Empty;
        }

        private void BMT_Password_Enter(object sender, EventArgs e)
        {
            HandleFocusEnter(BMT_Password, "PASSWORD");
        }       

        private void BMT_Password_Leave(object sender, EventArgs e)
        {
            HandleFocusLeave(BMT_Password, "PASSWORD");
        }

        private void BMT_Re_Enter_Password_Click(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Re_Enter_Password.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;            
        }

        private void BMT_Re_Enter_Password_MouseEnter(object sender, EventArgs e)
        {
            // Alterar bordas do controle focado
            BMT_Re_Enter_Password.BorderColorFocused = Color.DeepSkyBlue;
            BMT_Re_Enter_Password.BorderColorMouseHover = Color.DeepSkyBlue;

            // Restaurar bordas dos outros controles
            BMT_Full_Name.BorderColorFocused = Color.Empty;
            BMT_Full_Name.BorderColorMouseHover = Color.Empty;
            BMT_Email.BorderColorFocused = Color.Empty;
            BMT_Email.BorderColorMouseHover = Color.Empty;
            BMT_Password.BorderColorFocused = Color.Empty;
            BMT_Password.BorderColorMouseHover = Color.Empty;            
        }    

        private void BMT_Re_Enter_Password_Enter(object sender, EventArgs e)
        {
            HandleFocusEnter(BMT_Re_Enter_Password, "RE-ENTER PASSWORD");
        }        

        private void BMT_Re_Enter_Password_Leave(object sender, EventArgs e)
        {
            HandleFocusLeave(BMT_Re_Enter_Password, "RE-ENTER PASSWORD");
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

        private void lbl_SignUp_MouseEnter(object sender, EventArgs e)
        {
            lbl_SignUp.ForeColor = Color.Lime;
        }

        private void lbl_SignUp_MouseLeave(object sender, EventArgs e)
        {
            lbl_SignUp.ForeColor = Color.White;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            BMT_SignUp.Visible = false;
        }

        private void BMT_Termos_Click(object sender, EventArgs e)
        {
            Tela_Termos tt = new Tela_Termos();
            tt.Show();
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
    }
}

