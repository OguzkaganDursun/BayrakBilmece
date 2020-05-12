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
    public partial class KarakterSecimi : Form
    {
        public KarakterSecimi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        public int karakterNo = 0;
        PictureBox pictureBox = new PictureBox();
        PictureBox oncekiPictureBox = new PictureBox();
        public void KarakterSec(PictureBox karakter)
        {
            pictureBox = Giris.anaMenu.pictureBox1;
            pictureBox.BackgroundImage = karakter.BackgroundImage;
        }
        public void VeriTabaninaGonder()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update kullanicilar set Avatar='" + karakterNo + "' where Isim='" + Giris.anaMenu.label2.Text + "'", baglanti);
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            this.Close();
        }
        private void KarakterSecimi_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox1);
            karakterNo = 1;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox1;
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox2);
            karakterNo = 2;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox2;
            this.pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox3);
            karakterNo = 3;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox3;
            this.pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox4);
            karakterNo = 4;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox4;
            this.pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox5);
            karakterNo = 5;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox5;
            this.pictureBox5.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            KarakterSec(pictureBox6);
            karakterNo = 6;
            VeriTabaninaGonder();
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox6;
            this.pictureBox6.BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
