using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data;
using Technological_Future_AI.Classes;

namespace Technological_Future_AI.Telas
{
    public partial class AlterarSenha : Form
    {
        public AlterarSenha()
        {
            InitializeComponent();
            tb_password.UseSystemPasswordChar = true;
            tb_password.PasswordChar = '\0'; // Evita conflito          
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void lbl_fechar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
                Telas.Tela_login tl = new Telas.Tela_login();
                tl.Visible = true;
            }
        }     

        private void lbl_fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.Red;
        }

        private void lbl_fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.White;
        }

        private void AlterarSenha_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_acesso_Click(object sender, EventArgs e)
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
                            Telas.AlterarSenhaValidacao tm = new Telas.AlterarSenhaValidacao();
                            tm.Show();
                            this.Close();
                            return;
                        }
                    }
                }

                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_password.Clear();
                tb_username.Clear();
                tb_username.Focus();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_acesso_MouseEnter(object sender, EventArgs e)
        {
            btn_acesso.FlatAppearance.BorderSize = 1;
            btn_acesso.FlatAppearance.BorderColor = Color.Lime;
            btn_acesso.ForeColor = Color.Lime;
        }

        private void btn_acesso_MouseLeave(object sender, EventArgs e)
        {
            btn_acesso.FlatAppearance.BorderSize = 0;
            btn_acesso.FlatAppearance.BorderColor = Color.Empty;
            btn_acesso.ForeColor = Color.DeepSkyBlue;
        }

        private void ValidacaoSenha2_Click(object sender, EventArgs e)
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
    }
}
