using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayrakBilmece
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        public bool oyunSesi;
        public bool muzikSesi;
        public int muzikSesiVolume;
        private void button1_Click(object sender, EventArgs e)
        {
            ButonMuzigiCal();
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ButonMuzigiCal();
            if (radioButton3.Checked)
            {
                muzikSesi = true;
                Giris.anaMenu.MuzikBaslat(muzikSesi);
            }
                
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ButonMuzigiCal();
            if (radioButton4.Checked)
            {
                muzikSesi = false;
                Giris.anaMenu.MuzikDurdur(muzikSesi);
            }
                
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Giris.anaMenu.MuzikVolumenuAyarla(trackBar2);
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\ButonSesi.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        public void ButonMuzigiCal()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ButonMuzigiCal();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ButonMuzigiCal();
        }
    }
}
