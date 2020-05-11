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

            Giris.anaMenu.ButonMuzigiCal();
            
            OyunAyari.oyun.kitalar[0] = "";
            OyunAyari.oyun.kitalar[1] = "";
            OyunAyari.oyun.kitalar[2] = "";
            OyunAyari.oyun.kitalar[3] = "";
            OyunAyari.oyun.kitalar[4] = "";
            OyunAyari.oyun.kitalar[5] = "";

            Giris.anaMenu.label3.Text = label7.Text;
            Giris.anaMenu.oyuncuToplamPuani = OyunAyari.oyun.oyuncuToplamPuani ;
            
            Giris.anaMenu.SeviyeAtla();
            VeriTabaninaGonder();
            OyunAyari.oyun.oyuncuToplamPuani = Giris.anaMenu.oyuncuToplamPuani;
            Giris.anaMenu.Show();
            OyunAyari.oyun.Hide();
            Giris.anaMenu.MuzikBaslat(true);
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Giris.anaMenu.ButonMuzigiCal();
            OyunAyari.oyun.YenidenOyna();
            this.Close();
        }

        public void VeriTabaninaGonder()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update kullanicilar set Puan='" + Giris.anaMenu.oyuncuToplamPuani + "', Seviye='"+ Giris.anaMenu.oyuncuSeviyesi +"' where Isim='"  + Giris.anaMenu.label2.Text + "'", baglanti);
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

    }
}
