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
    public partial class Tela_Termos : Form
    {
        public Tela_Termos()
        {
            InitializeComponent();

            // Configuração básica do formulário
            this.Text = "Termos de Uso";
            this.Size = new Size(800, 600);
            this.BackColor = Color.Black;

            // Criação do WebBrowser
            WebBrowser webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScrollBarsEnabled = true
            };
            this.Controls.Add(webBrowser);

            // Adicionando os termos em formato HTML
            string htmlContent = @"
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
                    SOLICITAÇÕES DEVEM SER ENVIADAS ATRAVÉS DO E-MAIL: <a href='mailto:SEU_EMAIL_AQUI'>SEU_EMAIL_AQUI</a>.
                </p>
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


            webBrowser.DocumentText = htmlContent;

            // Criação do botão "Aceito"
            Button btnAceito = new Button
            {
                Text = "Aceito",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Width = 50,
                Height = 40,
                Margin = new Padding(20)
            };
            btnAceito.Click += BtnAceito_Click; // Evento de clique
            this.Controls.Add(btnAceito);

            // Criação do botão "Não Aceito"
            Button btnNaoAceito = new Button
            {
                Text = "Não Aceito",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Width = 50,
                Height = 40,
                Margin = new Padding(20)
            };
            btnNaoAceito.Click += BtnNaoAceito_Click; // Evento de clique
            this.Controls.Add(btnNaoAceito);
        }

        private void BtnNaoAceito_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAceito_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

