using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Technological_Future_AI.Properties;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_menu : Form
    {
        public Tela_menu()
        {
            InitializeComponent();
            panelSlide.Click += panel_Click;
            panelSlide2.Click += panel_Click;
            panelSlide3.Click += panel_Click;
            panelSlide4.Click += panel_Click;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;
        }

        public const int WM_NCLBUTTONDOWN = 0XA1;
        public const int HT_CAPTION = 0X2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);

        private void movepanels(Control btn)
        {
            panelSlide.Visible = true;
            panelSlide2.Visible = true;

            // Desativa outros painéis
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;
            panelSlide5.Visible = false;
            panelSlide6.Visible = false;
            panelSlide7.Visible = false;
            panelSlide8.Visible = false;
            panelSlide9.Visible = false;
            panelSlide10.Visible = false;
            panelSlide11.Visible = false;
            panelSlide12.Visible = false;

            // Define posições do painel
            panelSlide.Left = btn.Left;
            panelSlide.Top = btn.Top;
            panelSlide.Height = 2;
            panelSlide2.Top = btn.Top + btn.Height;
            panelSlide2.Left = btn.Left;
            panelSlide2.Height = 2;
        }

        private bool allowMoveButton1 = false;
        private bool allowMoveButton2 = false;
        private bool allowMoveButton3 = false;
        private bool allowMoveButton4 = false;
        private bool allowMoveButton5 = false;
        private bool allowMoveButton24 = false;
        private bool allowMoveButton34 = false;
        private bool allowMoveButton74 = false;

        private void movepanels2(Control btn)
        {
            panelSlide4.Visible = true;
            panelSlide3.Visible = true;

            // Desativa outros painéis
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide5.Visible = false;
            panelSlide6.Visible = false;
            panelSlide7.Visible = false;
            panelSlide8.Visible = false;
            panelSlide9.Visible = false;
            panelSlide10.Visible = false;
            panelSlide11.Visible = false;
            panelSlide12.Visible = false;

            panelSlide3.Left = btn.Left;
            panelSlide3.Top = btn.Top;
            panelSlide3.Height = 2;
            panelSlide4.Top = btn.Top + btn.Height;
            panelSlide4.Left = btn.Left;
            panelSlide4.Height = 2;
        }

        private void movepanels3(Control btn)
        {
            panelSlide5.Visible = true;
            panelSlide6.Visible = true;

            // Desativa outros painéis
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;
            panelSlide7.Visible = false;
            panelSlide8.Visible = false;
            panelSlide9.Visible = false;
            panelSlide10.Visible = false;
            panelSlide11.Visible = false;
            panelSlide12.Visible = false;

            // Define posições do painel
            panelSlide5.Left = btn.Left;
            panelSlide5.Top = btn.Top;
            panelSlide5.Height = 2;
            panelSlide6.Top = btn.Top + btn.Height;
            panelSlide6.Left = btn.Left;
            panelSlide6.Height = 2;
        }

        private void movepanels4(Control btn)
        {
            // Ativa painéis de button2 e button24
            panelSlide7.Visible = true;
            panelSlide8.Visible = true;

            // Desativa outros painéis
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;
            panelSlide5.Visible = false;
            panelSlide6.Visible = false;
            panelSlide9.Visible = false;
            panelSlide10.Visible = false;
            panelSlide11.Visible = false;
            panelSlide12.Visible = false;

            // Define posições do painel
            panelSlide7.Left = btn.Left;
            panelSlide7.Top = btn.Top;
            panelSlide7.Height = 2;
            panelSlide8.Top = btn.Top + btn.Height;
            panelSlide8.Left = btn.Left;
            panelSlide8.Height = 2;
        }

        private void movepanels5(Control btn)
        {
            // Ativa painéis de button2 e button24
            panelSlide9.Visible = true;
            panelSlide10.Visible = true;

            // Desativa outros painéis
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;
            panelSlide5.Visible = false;
            panelSlide6.Visible = false;
            panelSlide7.Visible = false;
            panelSlide8.Visible = false;
            panelSlide11.Visible = false;
            panelSlide12.Visible = false;

            // Define posições do painel
            panelSlide10.Left = btn.Left;
            panelSlide10.Top = btn.Top;
            panelSlide10.Height = 2;
            panelSlide9.Top = btn.Top + btn.Height;
            panelSlide9.Left = btn.Left;
            panelSlide9.Height = 2;
        }

        private void movepanels6(Control btn)
        {
            // Ativa painéis de button2 e button24
            panelSlide11.Visible = true;
            panelSlide12.Visible = true;

            // Desativa outros painéis
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;
            panelSlide5.Visible = false;
            panelSlide6.Visible = false;
            panelSlide7.Visible = false;
            panelSlide8.Visible = false;
            panelSlide9.Visible = false;
            panelSlide10.Visible = false;

            // Define posições do painel
            panelSlide11.Left = btn.Left;
            panelSlide11.Top = btn.Top;
            panelSlide11.Height = 2;
            panelSlide12.Top = btn.Top + btn.Height;
            panelSlide12.Left = btn.Left;
            panelSlide12.Height = 2;
        }

        private void UpdateButtonStates(bool isButton1Active, bool isButton2Active = false, bool isButton5Active = false, bool isButton24Active = false)
        {
            // Controlar os estados de todos os botões
            allowMoveButton1 = isButton1Active;
            allowMoveButton2 = isButton2Active;
            allowMoveButton5 = isButton5Active;
            allowMoveButton24 = isButton24Active;

            // Garantir que os painéis dos botões inativos sejam desativados
            if (!isButton1Active && !isButton2Active)
            {
                panelSlide.Visible = false;
                panelSlide2.Visible = false;
            }

            if (!isButton5Active && !isButton24Active)
            {
                panelSlide5.Visible = false;
                panelSlide6.Visible = false;
            }

            if (!isButton2Active && !isButton24Active)
            {
                panelSlide7.Visible = false;
                panelSlide8.Visible = false;
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            // Debug.WriteLine("Evento disparado por: " + ((Control)sender).Name);

            if (sender == panelSlide || sender == panelSlide2)
            {
                panelSlide3.Visible = false;
                panelSlide4.Visible = false;
                panelSlide.Visible = true;
                panelSlide2.Visible = true;
            }
            else
            {
                panelSlide.Visible = false;
                panelSlide2.Visible = false;
                panelSlide3.Visible = true;
                panelSlide4.Visible = true;
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

        private void button49_Click(object sender, EventArgs e)
        {
            movepanels2(button49);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            movepanels2(button50);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            movepanels2(button51);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            movepanels2(button52);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            movepanels2(button53);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            movepanels2(button54);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            movepanels2(button55);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            movepanels2(button56);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            movepanels2(button57);
        }

        private void btn_Atv_SQL_Click(object sender, EventArgs e)
        {
            string caminhoBat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Bat\Ligar_serviços_SQL_Server.bat");
            System.Diagnostics.Process.Start(caminhoBat);
            movepanels2(btn_Atv_SQL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (corpo1.Visible)
            {
                // Se o corpo1 já estiver visível, ocultá-lo
                corpo1.Visible = false;
                movepanels(button1);
                button1.Image = Resources.seta_para_baixo;
            }
            else
            {
                // Se não estiver visível, mostrá-lo
                movepanels(button1);
                corpo1.Visible = true;

                // Certifique-se de ocultar outros corpos
                corpo2.Visible = false;
                corpo3.Visible = false;
                corpo4.Visible = false;
                movepanels(button1);
                button1.Image = Resources.setas_para_cima;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (corpo2.Visible)
            {
                // Se o corpo1 já estiver visível, ocultá-lo
                corpo2.Visible = false;
                movepanels(button2);
                button2.Image = Resources.seta_para_baixo;
            }
            else
            {
                // Se não estiver visível, mostrá-lo
                movepanels(button2);
                corpo2.Visible = true;

                // Certifique-se de ocultar outros corpos
                corpo1.Visible = false;
                corpo3.Visible = false;
                corpo4.Visible = false;
                movepanels(button2);
                button2.Image = Resources.setas_para_cima;
            }
        }

        private void corpo1_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = true;
        }

        private void corpo1_MouseLeave(object sender, EventArgs e)
        {
            if (!corpo1.ClientRectangle.Contains(corpo1.PointToClient(Cursor.Position)))
            {
                button1.Image = Resources.seta_para_baixo;
                corpo1.Visible = false;
            }
        }

        private void corpo2_MouseEnter(object sender, EventArgs e)
        {
            corpo2.Visible = true;
        }

        private void corpo2_MouseLeave(object sender, EventArgs e)
        {
            if (!corpo2.ClientRectangle.Contains(corpo2.PointToClient(Cursor.Position)) && !button2.ClientRectangle.Contains(button2.PointToClient(Cursor.Position)))
            {
                corpo2.Visible = false;
                button2.Image = Resources.seta_para_baixo;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (corpo3.Visible)
            {
                // Se o corpo1 já estiver visível, ocultá-lo
                corpo3.Visible = false;
                movepanels(button3);
                button3.Image = Resources.seta_para_baixo;
            }
            else
            {
                // Se não estiver visível, mostrá-lo
                movepanels(button3);
                corpo3.Visible = true;

                // Certifique-se de ocultar outros corpos
                corpo2.Visible = false;
                corpo4.Visible = false;
                corpo1.Visible = false;
                button3.Image = Resources.setas_para_cima;
            }
        }

        private void corpo3_MouseEnter(object sender, EventArgs e)
        {
            corpo3.Visible = true;
        }

        private void corpo3_MouseLeave(object sender, EventArgs e)
        {
            if (!corpo3.ClientRectangle.Contains(corpo3.PointToClient(Cursor.Position)) && !button3.ClientRectangle.Contains(button3.PointToClient(Cursor.Position)))
            {
                corpo3.Visible = false;
                button3.Image = Resources.seta_para_baixo;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (corpo4.Visible)
            {
                // Se o corpo1 já estiver visível, ocultá-lo
                corpo4.Visible = false;
                movepanels(button4);
                button4.Image = Resources.seta_para_baixo;
            }
            else
            {
                // Se não estiver visível, mostrá-lo
                movepanels(button4);
                corpo4.Visible = true;

                // Certifique-se de ocultar outros corpos
                corpo2.Visible = false;
                corpo3.Visible = false;
                corpo1.Visible = false;
                button4.Image = Resources.setas_para_cima;
            }
        }

        private void corpo4_MouseEnter(object sender, EventArgs e)
        {
            corpo4.Visible = true;
        }

        private void corpo4_MouseLeave(object sender, EventArgs e)
        {
            if (!corpo4.ClientRectangle.Contains(corpo4.PointToClient(Cursor.Position)) && !button4.ClientRectangle.Contains(button4.PointToClient(Cursor.Position)))
            {
                corpo4.Visible = false;
                button4.Image = Resources.seta_para_baixo;
            }
        }

        private void btn_Dest_SQL_Click(object sender, EventArgs e)
        {
            movepanels2(btn_Dest_SQL);
            string caminhoBat2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Bat\Parar_serviços_do_SQL_Server.bat");
            System.Diagnostics.Process.Start(caminhoBat2);
        }

        private void pnl_titulo_MouseEnter(object sender, EventArgs e)
        {
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void btn_Atv_SQL_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(btn_Atv_SQL);
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void Tela_menu_MouseEnter(object sender, EventArgs e)
        {
            panelSlide.Visible = false;
            panelSlide2.Visible = false;
            panelSlide3.Visible = false;
            panelSlide4.Visible = false;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void btn_Dest_SQL_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(btn_Dest_SQL);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button49_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button49);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button50_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button50);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button51_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button51);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button52_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button52);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button53_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button53);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button54_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button54);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button55_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button55);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button56_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button56);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button57_MouseEnter(object sender, EventArgs e)
        {
            movepanels2(button57);
            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo1.Visible = false;
            corpo4.Visible = false;
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void Tela_menu_Load(object sender, EventArgs e)
        {
            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            movepanels(button1);

            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;

            corpo2.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            if (allowMoveButton1) return;

            UpdateButtonStates(true); // Ativa apenas o button1
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            movepanels(button2);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;

            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            if (allowMoveButton2) return;

            UpdateButtonStates(true); // Ativa apenas o button2
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            movepanels(button3);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            if (allowMoveButton3) return;

            UpdateButtonStates(true); // Ativa apenas o button2
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            movepanels(button4);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;

            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            if (allowMoveButton4) return;

            UpdateButtonStates(true); // Ativa apenas o button2
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button5);
            if (allowMoveButton5) return;

            UpdateButtonStates(false, false, true); // Ativa apenas o button5
        }

        private void button24_MouseEnter(object sender, EventArgs e)
        {
            movepanels4(button24);
            if (allowMoveButton24) return;

            UpdateButtonStates(false, false, false, true); // Ativa apenas o button24

            Debug.WriteLine("Painéis de button24 ativados");
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            movepanels3(button5);

        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button7);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button8);
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button9);
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button10);
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button11);
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button12);
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button13);
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            movepanels3(button14);
        }

        private void button23_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button23);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button22_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button22);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button21_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button21);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button20_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button20);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button19_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button19);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button18_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button18);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button17_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button17);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button16);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo3.Visible = false;
            corpo4.Visible = false;

            movepanels4(button15);

            button1.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            movepanels4(button24);
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button33);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;

        }


        private void button32_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button32);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button31);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button30);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button29_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button29);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button28_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button28);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button27_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button27);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button26_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button26);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button25_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo4.Visible = false;

            movepanels5(button25);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button4.Image = Resources.seta_para_baixo;
        }

        private void button73_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button73);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button72_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button72);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button71_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button71);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button70_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button70);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button69_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button69);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button68_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button68);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button67_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button67);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button66_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button66);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button65_MouseEnter(object sender, EventArgs e)
        {
            corpo1.Visible = false;
            corpo2.Visible = false;
            corpo3.Visible = false;

            movepanels6(button65);

            button1.Image = Resources.seta_para_baixo;
            button2.Image = Resources.seta_para_baixo;
            button3.Image = Resources.seta_para_baixo;
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {
            movepanels5(button34);
            if (allowMoveButton34) return;

            UpdateButtonStates(true); // Ativa apenas o button24

            Debug.WriteLine("Painéis de button24 ativados");
        }

        private void button74_MouseEnter(object sender, EventArgs e)
        {
            movepanels6(button74);
            if (allowMoveButton74) return;

            UpdateButtonStates(true); // Ativa apenas o button24

            Debug.WriteLine("Painéis de button24 ativados");
        }
    }
}

