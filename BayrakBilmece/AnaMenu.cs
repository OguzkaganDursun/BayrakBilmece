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
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        public int oyuncuToplamPuani=0;
        public int oyuncuSeviyesi = 0;
        public int seviyeDegiskeni = 2000;
        private void button1_Click(object sender, EventArgs e)
        {
            OyunAyari oyunAyari = new OyunAyari();
            oyunAyari.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KarakterSecimi karakterSecimi = new KarakterSecimi();
            karakterSecimi.ShowDialog();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            label2.Text = Giris.isimGirisi;
            label3.Text = oyuncuToplamPuani + " XP";
            KullaniciBilgileriniGetir();
            progressBar1.Maximum = seviyeDegiskeni;
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
                
                OleDbCommand komut = new OleDbCommand("select * from kullanicilar where Isim='"+label2.Text+"'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                if (oku[0].ToString() == "")
                    MessageBox.Show("Kullanıcı Bulunamadı!");
                else
                {
                    //MessageBox.Show("Kullanıcı Adı = " + oku[0].ToString() + "\nKullanıcı Puanı = " + oku[1].ToString() + " XP\nAvatar = "+oku[2].ToString());
                    label3.Text = oku[1].ToString()+" XP";
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
                OleDbCommand komut = new OleDbCommand("insert into kullanicilar(Isim,Puan) values('"+label2.Text+"','"+oyuncuToplamPuani+"')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
        }
        public void SeviyeAtla()
        {
            if(oyuncuToplamPuani / seviyeDegiskeni >= 1)
            {
                oyuncuSeviyesi++;
                oyuncuToplamPuani = oyuncuToplamPuani-seviyeDegiskeni;
                progressBar1.Value = 0;
                label5.Text = oyuncuSeviyesi.ToString();
                label3.Text = oyuncuToplamPuani + " XP";
            }
        }
    }
}
