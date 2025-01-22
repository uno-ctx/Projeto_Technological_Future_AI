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

namespace Technological_Future_AI.Telas
{
    public partial class AlterarSenha : Form
    {
        public AlterarSenha()
        {
            InitializeComponent();
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
    }
}
