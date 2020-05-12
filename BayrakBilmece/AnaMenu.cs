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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        public OyunAyari oyunAyari = new OyunAyari();
        public Hakkinda hakkinda = new Hakkinda();
        public KarakterSecimi karakterSecimi = new KarakterSecimi();

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        public int oyuncuToplamPuani = 0;
        public int oyuncuSeviyesi = 0;
        public int seviyeDegiskeni = 1000;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            oyunAyari.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            Giris.ayarlar.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();

            hakkinda.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();

            karakterSecimi.ShowDialog();
        }
        private void AnaMenu_Load(object sender, EventArgs e)
        {
            label2.Text = Giris.isimGirisi;
            label3.Text = oyuncuToplamPuani + " XP";
            KullaniciBilgileriniGetir();
            progressBar1.Maximum = seviyeDegiskeni;

            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\AnaMenuMusic.mp3";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            axWindowsMediaPlayer2.URL = Application.StartupPath + "\\Muzik\\ButonSesi.mp3";
            axWindowsMediaPlayer2.Ctlcontrols.stop();

            MuzikBaslat(Giris.ayarlar.muzikSesi);
        }
        public void MuzikBaslat(bool muzikSesi)
        {
            if (muzikSesi)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        public void MuzikDurdur(bool muzikSesi)
        {
            if (!muzikSesi)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }
        public void MuzikVolumenuAyarla(TrackBar trackBar)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar.Value;
        }
        public void ButonMuzigiCal()
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }
        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void KullaniciBilgileriniGetir()
        {
            try
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("select * from kullanicilar where Isim='" + label2.Text + "'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                if (oku[0].ToString() == "")
                    MessageBox.Show("Kullanıcı Bulunamadı!");
                else
                {
                    label3.Text = oku[1].ToString() + " XP";
                    oyuncuToplamPuani = Convert.ToInt32(oku[1]);
                    oyuncuSeviyesi = Convert.ToInt32(oku[3]);
                    label5.Text = oku[3].ToString();
                    progressBar1.Value = oyuncuToplamPuani;
                    KarakterSecimi karakterSecimi = new KarakterSecimi();
                    if (Convert.ToInt32(oku[2]) == 1)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox1);
                    if (Convert.ToInt32(oku[2]) == 2)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox2);
                    if (Convert.ToInt32(oku[2]) == 3)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox3);
                    if (Convert.ToInt32(oku[2]) == 4)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox4);
                    if (Convert.ToInt32(oku[2]) == 5)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox5);
                    if (Convert.ToInt32(oku[2]) == 6)
                        karakterSecimi.KarakterSec(karakterSecimi.pictureBox6);
                }

                baglanti.Close();
            }
            catch (Exception)
            {
                OleDbCommand komut = new OleDbCommand("insert into kullanicilar(Isim,Puan) values('" + label2.Text + "','" + oyuncuToplamPuani + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
        }
        public void SeviyeAtla()
        {
            bool artanPuan = true;
            while (artanPuan == true)
            {
                if (oyuncuToplamPuani >= seviyeDegiskeni)
                {
                    oyuncuSeviyesi++;
                    oyuncuToplamPuani = oyuncuToplamPuani - seviyeDegiskeni;
                    label5.Text = oyuncuSeviyesi.ToString();
                    label3.Text = oyuncuToplamPuani + " XP";
                }
                else
                {
                    progressBar1.Value = oyuncuToplamPuani;
                    artanPuan = false;
                }
            }


        }
    }
}
