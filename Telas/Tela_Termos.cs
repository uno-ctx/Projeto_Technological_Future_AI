using System;
using System.Drawing;
using System.Windows.Forms;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_Termos : Form
    {
        public Tela_Termos()
        {
            InitializeComponent();

            // Configuração do Formulário
            this.Text = "Termos de Uso";
            this.Size = new Size(800, 600);
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;

            // Criação do WebBrowser
            WebBrowser webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScrollBarsEnabled = true,
                DocumentText = ObterHtmlTermosDeUso()
            };
            this.Controls.Add(webBrowser);

            // Criação do botão "Fechar"
           /* Button btnFechar = new Button
            {
                Text = "X",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width - 40, 10) // Canto superior direito
            };
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFechar.Click += (s, e) => this.Close();
            this.Controls.Add(btnFechar);*/

            // Criação do botão "Aceito"
            Button btnAceito = new Button
            {
                Text = "Aceito",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 50
            };

            btnAceito.MouseEnter += (s, e) => btnAceito.BackColor = Color.Green;
            btnAceito.MouseLeave += (s, e) => btnAceito.BackColor = Color.Gray;


            btnAceito.Click += BtnAceito_Click;
            this.Controls.Add(btnAceito);

            // Criação do botão "Não Aceito"
            Button btnNaoAceito = new Button
            {
                Text = "Não Aceito",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 50
            };
            btnNaoAceito.Click += BtnNaoAceito_Click;
            this.Controls.Add(btnNaoAceito);

            btnNaoAceito.MouseEnter += (s, e) => btnNaoAceito.BackColor = Color.DarkRed;
            btnNaoAceito.MouseLeave += (s, e) => btnNaoAceito.BackColor = Color.Gray;

            btnNaoAceito.Click += (s, e) =>
            
            this.Controls.Add(btnNaoAceito);            

            // Criação do botão "Fechar Termo"
            Button btnFecharTermo = new Button
            {
                Text = "Fechar Termo",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,                
                Height = 50
            };

            btnFecharTermo.MouseEnter += (s, e) => btnFecharTermo.BackColor = Color.DarkRed;
            btnFecharTermo.MouseLeave += (s, e) => btnFecharTermo.BackColor = Color.Gray;

            btnFecharTermo.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Realmente deseja sair do termo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            };
            this.Controls.Add(btnFecharTermo);
        }

        private void BtnAceito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você aceitou os termos!", "Aceito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnNaoAceito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você não aceitou os termos!!\nE o usuário não será criado!!", "Não Aceito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private string ObterHtmlTermosDeUso()
        {
            return @"
                <html>
                <head>
                    <style>
                        body {
                            font-family: 'Century Gothic', sans-serif;
                            font-size: 14px;
                            color: white;
                            background-color: black;
                            text-align: justify;
                            margin: 20px;
                        }
                        h1 {
                            font-size: 18px;
                            font-weight: bold;
                            text-align: center;
                        }
                    </style>
                </head>
                <body>
                    <h1>TERMO DE USO DA APLICAÇÃO</h1>
                    <p>
                        1. ACEITAÇÃO DOS TERMOS<br>
                        AO UTILIZAR ESTA APLICAÇÃO, VOCÊ CONCORDA COM TODOS OS TERMOS E CONDIÇÕES AQUI DESCRITOS. 
                        CASO NÃO CONCORDE, ABSTENHA-SE DE UTILIZAR A APLICAÇÃO.
                    </p>
                    <p>
                        2. COLETA E USO DE DADOS PESSOAIS<br>
                        2.1. FINALIDADE DOS DADOS:<br>
                        COLETAMOS SEUS DADOS PESSOAIS PARA FINALIDADES ESPECÍFICAS, COMO:
                    </p>
                    <ul>
                        <li>PROVER FUNCIONALIDADES DA APLICAÇÃO;</li>
                        <li>MELHORAR A EXPERIÊNCIA DO USUÁRIO;</li>
                        <li>GARANTIR A SEGURANÇA E CONFORMIDADE LEGAL.</li>
                    </ul>
                    <p>
                        2.2. DADOS COLETADOS:<br>
                        OS DADOS COLETADOS PODEM INCLUIR, MAS NÃO SE LIMITAM A:
                    </p>
                    <ul>
                        <li>NOME COMPLETO, E-MAIL, TELEFONE, CPF, ENDEREÇO IP, E HISTÓRICO DE USO DA APLICAÇÃO.</li>
                    </ul>
                    <p>
                        2.3. CONSENTIMENTO:<br>
                        AO UTILIZAR A APLICAÇÃO, VOCÊ CONCORDA EXPRESSAMENTE COM A COLETA E O USO DOS SEUS DADOS PESSOAIS, NOS TERMOS DA LGPD.
                    </p>
                    <p>
                        3. DIREITOS DO USUÁRIO<br>
                        VOCÊ TEM DIREITO A:
                    </p>
                    <ul>
                        <li>CONFIRMAR A EXISTÊNCIA DO TRATAMENTO DE SEUS DADOS;</li>
                        <li>ACESSAR OS DADOS PESSOAIS COLETADOS;</li>
                        <li>CORRIGIR DADOS INCOMPLETOS, INEXATOS OU DESATUALIZADOS;</li>
                        <li>SOLICITAR A EXCLUSÃO DE DADOS PESSOAIS, EXCETO QUANDO FOREM NECESSÁRIOS PARA O CUMPRIMENTO DE OBRIGAÇÕES LEGAIS.</li>
                    </ul>
                  
                    <p>
                        4. SEGURANÇA DOS DADOS<br>
                        IMPLEMENTAMOS MEDIDAS DE SEGURANÇA PARA PROTEGER SEUS DADOS CONTRA ACESSO NÃO AUTORIZADO, ALTERAÇÃO, DIVULGAÇÃO OU DESTRUIÇÃO. 
                        TODAVIA, NÃO GARANTIMOS QUE OS DADOS ESTEJAM TOTALMENTE SEGUROS CONTRA CIBERATAQUES OU OUTROS INCIDENTES.
                    </p>
                    <p>
                        5. COMPARTILHAMENTO DE DADOS<br>
                        NÃO COMPARTILHAMOS SEUS DADOS PESSOAIS COM TERCEIROS, EXCETO:
                    </p>
                    <ul>
                        <li>PARA CUMPRIMENTO DE OBRIGAÇÕES LEGAIS;</li>
                        <li>EM CASO DE AUTORIZAÇÃO EXPRESSA DO USUÁRIO;</li>
                        <li>QUANDO NECESSÁRIO PARA PROVER FUNCIONALIDADES DA APLICAÇÃO.</li>
                    </ul>
                    <p>
                        6. ALTERAÇÕES NO TERMO DE USO<br>
                        ESTE TERMO PODE SER ALTERADO A QUALQUER MOMENTO. O USUÁRIO SERÁ NOTIFICADO SOBRE MUDANÇAS SIGNIFICATIVAS ATRAVÉS DA APLICAÇÃO OU PELO E-MAIL CADASTRADO.
                    </p>
                    <p>
                        7. LEGISLAÇÃO APLICÁVEL<br>
                        ESTE TERMO ESTÁ REGIDO PELA LEI GERAL DE PROTEÇÃO DE DADOS (LEI Nº 13.709/2018) E PELAS LEIS BRASILEIRAS APLICÁVEIS. 
                        EM CASO DE DÚVIDAS OU CONTROVÉRSIAS, O FORO DA COMARCA DE [CIDADE/ESTADO] SERÁ COMPETENTE PARA DIRIMI-LAS.
                    </p>
                    <p>
                        AO PROSSEGUIR COM O USO DA APLICAÇÃO, VOCÊ DECLARA TER LIDO, ENTENDIDO E ACEITADO ESTE TERMO EM SUA TOTALIDADE.
                    </p>
                </body>
                </html>";
        }
    }
}
