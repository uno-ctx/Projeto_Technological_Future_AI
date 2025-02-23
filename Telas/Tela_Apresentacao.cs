using System;
using System.Windows.Forms;
using System.IO;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_Apresentacao : Form
    {       
        public Tela_Apresentacao()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panel2.Width += 3;

            if (panel2.Width >= 578)
            {
                timer1.Stop();                
                using (Tela_Apresentacao2 TA2 = new Tela_Apresentacao2())
                {
                    this.Hide();
                    TA2.ShowDialog();
                }
                this.Close();
            }
        }
    }
}