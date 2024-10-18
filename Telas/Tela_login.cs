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

namespace Technological_Future_AI.Telas
{
    public partial class Tela_login : Form
    {
        public Tela_login()
        {
            InitializeComponent();
            panel3.Visible = false;
            tb_username.Focus();
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;

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
            BMT_First_Name.Focus();
        }

        private void lbl_LogIn_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
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
            dt = Classes.Banco.consulta(sql);
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
                this.Show(); // Opcional: pode trazer a tela de login de volta se necessário
            }
            else
            {
                MessageBox.Show("Usuário ou senha inconsistentes ou usuário não encontrado!!");
            }
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

        private void lbl_fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.Red;   
        }

        private void lbl_fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.LightGray;
        }

        private void Check_Terms_MouseEnter(object sender, EventArgs e)
        {
            Check_Terms.ForeColor = Color.Lime;
        }

        private void Check_Terms_MouseLeave(object sender, EventArgs e)
        {
            Check_Terms.ForeColor = Color.LightGray;
        }

        private void checkBox2_MouseEnter(object sender, EventArgs e)
        {
            checkBox2.ForeColor = Color.Lime;
        }

        private void checkBox2_MouseLeave(object sender, EventArgs e)
        {
            checkBox2.ForeColor = Color.LightGray;
        }

        private void lbl_LogIn_MouseEnter(object sender, EventArgs e)
        {
            lbl_LogIn.ForeColor = Color.Lime;
        }

        private void lbl_LogIn_MouseLeave(object sender, EventArgs e)
        {
            lbl_LogIn.ForeColor = Color.LightGray;
        }

        private void lbl_SignUp_MouseEnter(object sender, EventArgs e)
        {
            lbl_SignUp.ForeColor = Color.Lime;
        }

        private void lbl_SignUp_MouseLeave(object sender, EventArgs e)
        {
            lbl_SignUp.ForeColor = Color.LightGray;
        }

        private void checkBox3_MouseEnter(object sender, EventArgs e)
        {
            checkBox3.ForeColor = Color.Lime;
        }

        private void checkBox3_MouseLeave(object sender, EventArgs e)
        {
            checkBox3.ForeColor = Color.LightGray;
        }

        private void tb_username_MouseEnter(object sender, EventArgs e)
        {
            pnl_linha_username.BackColor = Color.Lime;
        }

        private void tb_username_MouseLeave(object sender, EventArgs e)
        {
            pnl_linha_username.BackColor = Color.LightGray;
        }
        
        private void tb_password_MouseEnter(object sender, EventArgs e)
        {            
            pnl_linha_password.BackColor = Color.Lime;
        }

        private void tb_password_MouseLeave(object sender, EventArgs e)
        {
            pnl_linha_password.BackColor = Color.LightGray;
        }     
    }
}
