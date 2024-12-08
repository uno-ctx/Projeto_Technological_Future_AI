using System;
using System.Windows.Forms;

namespace Technological_Future_AI.Telas
{
    public partial class FormInput : Form
    {
        // Declaração correta do campo txtInput como TextBox
        private TextBox txtInput;

        public string UserInput { get; private set; } = string.Empty;

        // Construtor
        public FormInput(string message, string title)
        {
            InitializeComponent();
            this.Text = title;
            lblMessage.Text = message; // Exibe a mensagem no Label

            // Inicializa o TextBox dinamicamente
            txtInput = new TextBox();
            txtInput.Location = new System.Drawing.Point(15, 60); // Ajuste a localização conforme necessário
            txtInput.Width = 200; // Ajuste a largura conforme necessário
            this.Controls.Add(txtInput); // Adiciona o TextBox ao formulário
        }

        // Ação do botão OK
        private void btnOk_Click(object sender, EventArgs e)
        {
            UserInput = txtInput.Text; // Agora 'txtInput' é um TextBox válido
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Ação do botão Cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
