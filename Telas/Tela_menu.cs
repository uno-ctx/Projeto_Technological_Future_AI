using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Technological_Future_AI.Properties;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_menu : Form
    {
        private bool isCollapsed;
        public Tela_menu()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void movepanel(Control btn)
        {
            if (panelSlide != null)
            {
                panelSlide.Width = btn.Width;
                panelSlide.Height = btn.Left;
                panelSlide.Visible = true;
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

        private void lbl_fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.Red;
        }

        private void lbl_fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_fechar.ForeColor = Color.LightGray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button7.Image = Resources.setas_para_cima;
                corpo1.Height += 8;
                if (corpo1.Size == corpo1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button7.Image = Resources.seta_para_baixo;
                corpo1.Height -= 8;
                if (corpo1.Size == corpo1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button37.Image = Resources.setas_para_cima;
                corpo2.Height += 8;
                if (corpo2.Size == corpo2.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button37.Image = Resources.seta_para_baixo;
                corpo2.Height -= 8;
                if (corpo2.Size == corpo2.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button45.Image = Resources.setas_para_cima;
                corpo3.Height += 8;
                if (corpo3.Size == corpo3.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button45.Image = Resources.seta_para_baixo;
                corpo3.Height -= 8;
                if (corpo3.Size == corpo3.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button21.Image = Resources.setas_para_cima;
                corpo4.Height += 8;
                if (corpo4.Size == corpo4.MaximumSize)
                {
                    timer4.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button21.Image = Resources.seta_para_baixo;
                corpo4.Height -= 8;
                if (corpo4.Size == corpo4.MinimumSize)
                {
                    timer4.Stop();
                    isCollapsed = true;
                }
            }
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            movepanel(button7);
            timer1.Start();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            movepanel(button37);
            timer2.Start();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            movepanel(button45);
            timer3.Start();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            movepanel(button21);
            timer4.Start();
        }        

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnl_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Ativar_SQL_Server_Click(object sender, EventArgs e)
        {
            string CaminhoBatchSQLServer = @"D:\Projeto_Contas_2024\Projeto_Technological_Future-AI\Bat\Ligar serviços SQL Server.bat";

            System.Diagnostics.Process.Start(CaminhoBatchSQLServer);
        }
    }
}
