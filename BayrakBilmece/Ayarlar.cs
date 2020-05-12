using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (oyunSesi == true)
                ButonMuzigiCal();
            this.Close();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (oyunSesi == true)
                ButonMuzigiCal();
            if (radioButton3.Checked)
            {
                muzikSesi = true;
                Giris.anaMenu.MuzikBaslat(muzikSesi);
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (oyunSesi == true)
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
            if (radioButton1.Checked)
            {
                oyunSesi = true;
            }
            if (oyunSesi == true)
                ButonMuzigiCal();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (oyunSesi == true)
                ButonMuzigiCal();
            if (radioButton2.Checked)
            {
                oyunSesi = false;
            }
        }
        public void OyunSesiVolumenuAyarla(TrackBar trackBar, AxWindowsMediaPlayer muzik)
        {
            muzik.settings.volume = trackBar.Value;
            Giris.anaMenu.axWindowsMediaPlayer2.settings.volume = trackBar.Value;
            Giris.anaMenu.oyunAyari.oyun.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.bilgilendirme.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.uyari.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.anaMenu.oyunAyari.oyun.cevap.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.ekle.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.duzenle.axWindowsMediaPlayer1.settings.volume = trackBar.Value;

            Giris.anaMenu.oyunAyari.uyari.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.anaMenu.oyunAyari.oyun.sonuc.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.ekle.uyari.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.ekle.bilgilendirme.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.yonetici.duzenle.bilgilendirme.axWindowsMediaPlayer1.settings.volume = trackBar.Value;
            Giris.mediaPlayer.settings.volume = trackBar.Value;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            OyunSesiVolumenuAyarla(trackBar1, axWindowsMediaPlayer1);
        }
    }
}
