using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Technological_Future_AI.Classes;
using System.Security.Cryptography;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Bunifu.Framework.UI;
using Technological_Future_AI.Properties;
using System.IO;
using System.Drawing.Text;


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
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;
        private bool isCollapsed;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void Tela_login_Load(object sender, EventArgs e)
        {
            tb_username.Focus();
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

        private void InitializePlaceholder(BunifuMaterialTextbox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray; // Define a cor do placeholder
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

        private void TextBox_Leave(object sender, EventArgs e)
        {
            BunifuMaterialTextbox textBox = sender as BunifuMaterialTextbox;
            UpdatePlaceholder(textBox, textBox.Tag.ToString(), false);
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            BMT_Full_Name.Tag = "FULL NAME";
            BMT_Email.Tag = "E-MAIL";
            BMT_Password.Tag = "PASSWORD";
            BMT_Re_Enter_Password.Tag = "RE-ENTER PASSWORD";

            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();
            panel3.Visible = false;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Usuário e senha são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = Classes.Crypto.cryto_login.HashPassword(password);

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\banco\Banco.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO TB_USUARIOS (T_USERNAME, T_SENHA_USUARIOS) VALUES (@username, @password)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_login_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btn_position.Image = Resources.setas_para_cima;
                corpo.Height += 8;
                if (corpo.Size == corpo.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
                else
                {
                    btn_position.Image = Resources.seta_para_baixo;
                    corpo.Height -= 8;
                    if (corpo.Size == corpo.MinimumSize)
                    {
                        timer1.Stop();
                        isCollapsed = true;
                    }
                }
            }
        }
    }
}

