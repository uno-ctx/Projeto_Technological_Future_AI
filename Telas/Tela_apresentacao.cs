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

namespace Technological_Future_AI
{
    public partial class Tela_apresentacao : Form
    {
        public Tela_apresentacao()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 3;
            if (panel3.Width >= 499)
            {
                // Abre o Tela_login e fecha o Tela_apresentacao
                timer1.Stop();
                this.Hide(); // Isso para evitar que Tela_apresentacao permaneça visível

                // Certifica que Tela_login só é exibida uma vez
                Telas.Tela_login telaLogin = new Telas.Tela_login();
                telaLogin.ShowDialog(); // Isso garante que só fecha o form anterior ao abrir este
                this.Close(); // Encerra a Tela_apresentacao
            }
        }

        private void lbl_fechar_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            panel3.Enabled = false;

            DialogResult result = MessageBox.Show("Realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else 
            {
                timer1.Enabled = true;
                panel3.Enabled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tela_apresentacao_MouseDown);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tela_apresentacao_MouseDown);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tela_apresentacao_MouseDown);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tela_apresentacao_MouseDown);
            }
        }

        private void Tela_apresentacao_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
               // this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tela_apresentacao_MouseDown);
            }
        }
    }
}
