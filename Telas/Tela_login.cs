using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Technological_Future_AI.Classes;
using System.Data.SQLite;
using Bunifu.Framework.UI;
using Technological_Future_AI.Properties;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_login : Form
    {
        public Tela_login()
        {
            InitializeComponent();
            panel3.Visible = false;
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
        private bool isCollapsed;

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
                e.Handled = true; // Impede processamento adicional
                e.SuppressKeyPress = true; // Evita som do "beep"
                btn_login_Click(btn_login, EventArgs.Empty); // Executa o evento de clique diretamente
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
            panel3.Visible = true;
            corpo.Visible = false;
        }

        private void lbl_LogIn_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
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
            string username = tb_username.Text;
            string password = tb_password.Text;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Campo username e password estão vazios, por favor tente novamente!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Question);
                tb_username.Focus();
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Campo username está vazio, por favor tente novamente!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Question);
                tb_username.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Campo password está vazio, por favor tente novamente!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            DataTable dt = new DataTable();
            string sql = "SELECT * FROM TB_USUARIOS WHERE T_USERNAME = '" + username + "' AND T_SENHA_USUARIOS='" + password + "'";
            dt = Classes.Banco.Consulta(sql);
            if (dt.Rows.Count == 1)
            {
                Telas.Tela_menu tm = new Telas.Tela_menu();
                tm.lbl_acesso.Text = dt.Rows[0].ItemArray[6].ToString();
                tm.lbl_usuarios.Text = dt.Rows[0].Field<string>("T_Code_Name");
                tm.pct_On_Off.Image = Properties.Resources.Ligado;
                tm.lbl_cargo.Text = dt.Rows[0].Field<string>("T_Desc_Nivel_Usuarios");
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("N_Nivel_Usuarios").ToString());
                Globais.logado = true;

                this.Hide(); // Oculta a tela de login
                tm.ShowDialog(); // Abre Tela_menu como um diálogo
                                 // this.Show(); // Opcional: pode trazer a tela de login de volta se necessário
            }
            else
            {
                MessageBox.Show("Usuário ou senha inconsistentes ou usuário não encontrado!!");
                tb_password.Clear();
                tb_username.Clear();
            }
            SendKeys.Send("{ENTER}");
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
            // Tags para os campos de entrada
            string fullname = BMT_Full_Name.Text.Trim();
            string email = BMT_Email.Text.Trim();
            string password = BMT_Password.Text.Trim();
            string reEnterPassword = BMT_Re_Enter_Password.Text.Trim();
            panel3.Visible = false;

            // Validação de campos obrigatórios
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(reEnterPassword))
            {
                MessageBox.Show("Usuário e senha são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != reEnterPassword)
            {
                MessageBox.Show("As senhas estão diferentes! Por favor, Tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gerar o hash e o salt da senha
            string salt;
            string hashedPassword = Classes.Crypto.cryto_login.HashPasswordWithSalt(password, out salt);

            // Caminho do banco de dados
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\banco\Banco.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                // Conexão com o banco de dados
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Comando SQL para inserir o usuário
                    string sql = "INSERT INTO TB_USUARIOS (T_USERNAME, T_SENHA_USUARIOS, T_SALT) VALUES (@username, @password, @salt)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Adicionar parâmetros
                        cmd.Parameters.AddWithValue("@username", fullname);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        // Executar o comando
                        cmd.ExecuteNonQuery();
                    }
                }

                // Mensagem de sucesso
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Exibir erro em caso de falha
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
            panel3.Visible = false;
        }
    }
}

