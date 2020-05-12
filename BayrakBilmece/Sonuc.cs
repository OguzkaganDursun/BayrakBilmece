using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BayrakBilmece
{
    public partial class Sonuc : Form
    {
        public Sonuc()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();

            Giris.anaMenu.oyunAyari.oyun.kitalar[0] = "";
            Giris.anaMenu.oyunAyari.oyun.kitalar[1] = "";
            Giris.anaMenu.oyunAyari.oyun.kitalar[2] = "";
            Giris.anaMenu.oyunAyari.oyun.kitalar[3] = "";
            Giris.anaMenu.oyunAyari.oyun.kitalar[4] = "";
            Giris.anaMenu.oyunAyari.oyun.kitalar[5] = "";

            Giris.anaMenu.label3.Text = label7.Text;
            Giris.anaMenu.oyuncuToplamPuani = Giris.anaMenu.oyunAyari.oyun.oyuncuToplamPuani;

            Giris.anaMenu.SeviyeAtla();
            VeriTabaninaGonder();
            Giris.anaMenu.oyunAyari.oyun.oyuncuToplamPuani = Giris.anaMenu.oyuncuToplamPuani;
            Giris.anaMenu.Show();
            Giris.anaMenu.oyunAyari.oyun.Hide();
            if (Giris.ayarlar.muzikSesi == true)
                Giris.anaMenu.MuzikBaslat(true);
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            Giris.anaMenu.oyunAyari.oyun.YenidenOyna();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Close();
        }
        public void VeriTabaninaGonder()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update kullanicilar set Puan='" + Giris.anaMenu.oyuncuToplamPuani + "', Seviye='" + Giris.anaMenu.oyuncuSeviyesi + "' where Isim='" + Giris.anaMenu.label2.Text + "'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                baglanti.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veri Tabanına Gönder Çalışmadı!");
                baglanti.Close();
            }
        }
        private void Sonuc_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\SonucEkraniMuzigi.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (Giris.ayarlar.oyunSesi == true)
                axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
