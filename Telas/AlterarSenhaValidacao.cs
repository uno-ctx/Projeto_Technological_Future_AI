using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technological_Future_AI.Telas
{
    public partial class AlterarSenhaValidacao : Form
    {
        public AlterarSenhaValidacao()
        {
            InitializeComponent();
        }

        private void lbl_fechar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Realmente deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Tela_login TL = new Tela_login();
                TL.Show();
                this.Hide();
            }
        }

        private void btn_sms_Click(object sender, EventArgs e)
        {

        }

        private void btn_email_Click(object sender, EventArgs e)
        {

        }

        private void btn_whatsapp_Click(object sender, EventArgs e)
        {

        }

        private void btn_sms_MouseEnter(object sender, EventArgs e)
        {
            btn_sms.FlatAppearance.BorderSize = 1;
            btn_sms.FlatAppearance.BorderColor = Color.Lime;
            btn_sms.BackColor = Color.FromArgb(34, 36, 49);
            btn_sms.ForeColor = Color.Lime;
        }

        private void btn_sms_MouseLeave(object sender, EventArgs e)
        {
            btn_sms.FlatAppearance.BorderSize = 0;
            btn_sms.FlatAppearance.BorderColor = Color.Empty;
            btn_sms.BackColor = Color.FromArgb(34, 36, 49);
            btn_sms.ForeColor = Color.White;
        }

        private void btn_email_MouseEnter(object sender, EventArgs e)
        {
            btn_email.FlatAppearance.BorderSize = 1;
            btn_email.FlatAppearance.BorderColor = Color.Lime;
            btn_email.BackColor = Color.FromArgb(34, 36, 49);
            btn_email.ForeColor = Color.Lime;
        }

        private void btn_email_MouseLeave(object sender, EventArgs e)
        {
            btn_email.FlatAppearance.BorderSize = 0;
            btn_email.FlatAppearance.BorderColor = Color.Empty;
            btn_email.BackColor = Color.FromArgb(34, 36, 49);
            btn_email.ForeColor = Color.White;
        }

        private void btn_whatsapp_MouseEnter(object sender, EventArgs e)
        {
            btn_whatsapp.FlatAppearance.BorderSize = 1;
            btn_whatsapp.FlatAppearance.BorderColor = Color.Lime;
            btn_whatsapp.BackColor = Color.FromArgb(34, 36, 49);
            btn_whatsapp.ForeColor = Color.Lime;
        }

        private void btn_whatsapp_MouseLeave(object sender, EventArgs e)
        {
            btn_whatsapp.FlatAppearance.BorderSize = 0;
            btn_whatsapp.FlatAppearance.BorderColor = Color.Empty;
            btn_whatsapp.BackColor = Color.FromArgb(34, 36, 49);
            btn_whatsapp.ForeColor = Color.White;
        }
    }
}
