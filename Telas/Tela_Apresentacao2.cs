using System;
using System.IO;
using System.Windows.Forms;
using AxWMPLib;

namespace Technological_Future_AI.Telas
{
    public partial class Tela_Apresentacao2 : Form
    {
        private AxWindowsMediaPlayer axWindowsMediaPlayer_Background;

        public Tela_Apresentacao2()
        {
            InitializeComponent();            
        }

        private void Tela_Apresentacao2_Load(object sender, EventArgs e)
        {
            string CaminhoDoVideo = Path.Combine(Application.StartupPath, "TECHNOLOGICAL_FUTURE_AI.mp4");

            if (File.Exists(CaminhoDoVideo))
            {
                axWindowsMediaPlayer1.uiMode = "none"; // Esconde controles do player de vídeo
                axWindowsMediaPlayer1.URL = CaminhoDoVideo;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            }
            else
            {
                MessageBox.Show($"Arquivo de vídeo não encontrado: {CaminhoDoVideo}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8) // MediaEnded
            {
                try
                {
                    if (axWindowsMediaPlayer_Background != null && axWindowsMediaPlayer_Background.playState == WMPLib.WMPPlayState.wmppsPlaying)
                        axWindowsMediaPlayer_Background.Ctlcontrols.stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao parar a música de fundo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Hide();

                using (Tela_login tl = new Tela_login())
                {
                    tl.ShowDialog();
                }

                this.Close();
            }
        }
    }
}
