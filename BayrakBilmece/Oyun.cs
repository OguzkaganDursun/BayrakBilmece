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
    public partial class Oyun : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        public Oyun()
        {
            InitializeComponent();
        }

        public Cevap cevap = new Cevap();
        public Sonuc sonuc = new Sonuc();
        //Oyun Ayarları Bilgileri

        public int red = 0, green = 255, blue = 0;
        public int renkDegisim = 0;

        public string[] kitalar = new string[6];
        public string oyunZorlugu = "Kolay";

        public int oyuncuToplamPuani = 0;
        public int oyunSuresi = 0;
        public int oyunSuresiSiniri = 0;

        public int dogruCevap = 0;
        public string dogruCevapBayrakYolu;
        public int[] secilenPicBoxlar = new int[5];
        public int picSirasi = 0;
        int ulkeNo;
        string bayrakYolu;
        public int puan = 0;
        public int hak = 0;
        public int bilinenSoruSayisi = 0;

        PictureBox pictureBox = new PictureBox();
        Label label = new Label();
        int toplamKayitSayi = 0;
        string soruMetni;

        int kayıtSayisi = 0;

        private void Oyun_Load(object sender, EventArgs e)
        {
            pictureBox = Giris.anaMenu.pictureBox1; //Kullanıcı Profil Resmi           
            label = Giris.anaMenu.label2;//Kullanıcı İsmi
            pictureBox1.BackgroundImage = pictureBox.BackgroundImage;
            label2.Text = label.Text;
            oyuncuToplamPuani = Giris.anaMenu.oyuncuToplamPuani;//Kullanıcı Toplam Puanı
            label4.Text = oyuncuToplamPuani + " XP";
            progressBar1.Maximum = oyunSuresi;
            timer1.Enabled = true;

            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\Timer.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        public int ToplamKayitSayisi()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select count(*) from ulke_bilgileri where Kita='" + kitalar[0] + "' or Kita='" + kitalar[1] + "' or Kita='" + kitalar[2] + "' or Kita='" + kitalar[3] + "' or Kita='" + kitalar[4] + "' or Kita='" + kitalar[5] + "' ", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                toplamKayitSayi = Convert.ToInt32(oku[0]);
                baglanti.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "toplam Kayıt çalışmadı");
                baglanti.Close();
            }
            return toplamKayitSayi;
        }
        public void SoruHazirla(string isim, string baskent, string nufus)
        {
            Random rastgele = new Random();
            int salla, ipucu;
            int[] dizilerim = new int[3];
            int a = 0;
            ipucu = rastgele.Next(2, 4);

            for (int i = 0; i < ipucu; i++)
            {
                salla = rastgele.Next(1, 4);
                for (int j = 0; j < dizilerim.Length; j++)
                {
                    if (dizilerim[j] == salla)
                    {
                        a++;
                        i--;
                        break;
                    }
                }
                if (a == 0)
                {
                    dizilerim[i] = salla;
                }
                a = 0;
            }
            for (int i = 0; i < ipucu; i++)
            {
                if (dizilerim[i] == 1)
                    soruMetni += "İsmi " + isim + "";
                if (dizilerim[i] == 2)
                    soruMetni += "Başkenti " + baskent + "";
                if (dizilerim[i] == 3)
                    soruMetni += "Nüfusu " + nufus + "";
                if ((i + 1) < ipucu)
                    soruMetni += ", ";
            }
            soruMetni += " Olan Ülke Hangisidir ?";
            label5.Text = soruMetni;
            label5.Location = new Point((this.Width - label5.Width) / 2, label5.Location.Y);
        }
        public void RastgeleUlkeSec()
        {
            Random rstSayi = new Random();
            kayıtSayisi = ToplamKayitSayisi();//
            int secilenUlke;
            int secilenPicBox;
            secilenPicBox = rstSayi.Next(1, 6);//
            secilenUlke = rstSayi.Next(1, kayıtSayisi + 1);//+
            try
            {
                int id = 0;//
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri where Kita='" + kitalar[0] + "' or Kita='" + kitalar[1] + "' or Kita='" + kitalar[2] + "' or Kita='" + kitalar[3] + "' or Kita='" + kitalar[4] + "' or Kita='" + kitalar[5] + "' ", baglanti);//
                OleDbDataReader oku = komut.ExecuteReader();//
                while (id < secilenUlke)
                {
                    oku.Read();
                    id++;
                }

                if (dogruCevap == 0)
                {
                    dogruCevap = secilenPicBox;
                    dogruCevapBayrakYolu = oku[5].ToString();

                    secilenPicBoxlar[picSirasi] = Convert.ToInt32(oku[0]);//secilenPicBoxlar[secilenPicBox-1]                  
                    BayrakResmiYerlestir(secilenPicBox, oku[5].ToString());
                    SoruHazirla(oku[2].ToString(), oku[3].ToString(), oku[4].ToString());
                    picSirasi++;
                }
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Rastgele Ülke Seçilemedi!");
                baglanti.Close();
            }
        }
        public void BayrakResmiYerlestir(int sayi, string bayrakKonumu)
        {
            if (sayi == 1 && pictureBox5.ImageLocation == null)
                pictureBox5.ImageLocation = Application.StartupPath + bayrakKonumu;
            if (sayi == 2 && pictureBox6.ImageLocation == null)
                pictureBox6.ImageLocation = Application.StartupPath + bayrakKonumu;
            if (sayi == 3 && pictureBox7.ImageLocation == null)
                pictureBox7.ImageLocation = Application.StartupPath + bayrakKonumu;
            if (sayi == 4 && pictureBox8.ImageLocation == null)
                pictureBox8.ImageLocation = Application.StartupPath + bayrakKonumu;
            if (sayi == 5 && pictureBox9.ImageLocation == null)
                pictureBox9.ImageLocation = Application.StartupPath + bayrakKonumu;
            if (sayi == 0 || sayi > 5)
                MessageBox.Show("Hata " + sayi);
        }
        public void BosBayraklaraAtama()
        {
            for (int i = 1; i < 6; i++)
            {
                UlkeSec();
                bool b = true;
                for (int a = 0; a < 5; a++)
                {
                    if (secilenPicBoxlar[a] == ulkeNo)
                    {
                        i--;
                        b = false;
                        break;
                    }
                }
                if (b == true)
                {
                    if (picSirasi < 5)
                    {
                        secilenPicBoxlar[picSirasi] = ulkeNo;
                        picSirasi++;
                    }
                    BayrakResmiYerlestir(i, bayrakYolu);
                }
            }
        }
        public void UlkeSec()
        {
            Random rstSayi = new Random();
            int secilenUlke;
            secilenUlke = rstSayi.Next(1, kayıtSayisi + 1);

            try
            {
                int id = 0;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri where Kita='" + kitalar[0] + "' or Kita='" + kitalar[1] + "' or Kita='" + kitalar[2] + "' or Kita='" + kitalar[3] + "' or Kita='" + kitalar[4] + "' or Kita='" + kitalar[5] + "' ", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (id < secilenUlke)
                {
                    oku.Read();
                    id++;
                }
                bayrakYolu = oku[5].ToString();
                ulkeNo = Convert.ToInt32(oku[0]);
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Ülke Seçilemedi!(UlkeSeç)");
                baglanti.Close();
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 1)
            {
                DogruCevap();
            }
            else
            {
                YanlisCevap();
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 2)
            {
                DogruCevap();
            }
            else
            {
                YanlisCevap();
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 3)
            {
                DogruCevap();
            }
            else
            {
                YanlisCevap();
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 4)
            {
                DogruCevap();
            }
            else
            {
                YanlisCevap();
            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 5)
            {
                DogruCevap();
            }
            else
            {
                YanlisCevap();
            }
        }
        public void SoruyuYenile()
        {
            dogruCevap = 0;
            dogruCevapBayrakYolu = "";
            secilenPicBoxlar[0] = 0;
            secilenPicBoxlar[1] = 0;
            secilenPicBoxlar[2] = 0;
            secilenPicBoxlar[3] = 0;
            secilenPicBoxlar[4] = 0;
            picSirasi = 0;
            ulkeNo = 0;
            bayrakYolu = "";
            toplamKayitSayi = 0;
            soruMetni = "";
            pictureBox5.ImageLocation = null;
            pictureBox6.ImageLocation = null;
            pictureBox7.ImageLocation = null;
            pictureBox8.ImageLocation = null;
            pictureBox9.ImageLocation = null;
            RastgeleUlkeSec();
            BosBayraklaraAtama();
            red = 0;
            green = 255;
            blue = 0;
            progressBar1.Value = 0;
            progressBar1.ForeColor = Color.FromArgb(255, red, green, blue);
            timer1.Start();
            timer2.Start();
        }
        public void DogruCevap()
        {
            cevap.pictureBox1.ImageLocation = Application.StartupPath + dogruCevapBayrakYolu;
            cevap.label1.Text = "Tebrikler";
            cevap.label1.ForeColor = Color.Gold;
            cevap.label1.Location = new Point((cevap.Width - cevap.label1.Width) / 2, cevap.label1.Location.Y);
            timer1.Stop();
            timer2.Stop();
            cevap.axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\DogruCevap.mp3";
            cevap.axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (Giris.ayarlar.oyunSesi == true)
                cevap.axWindowsMediaPlayer1.Ctlcontrols.play();
            cevap.ShowDialog();
            puan += 100;
            oyuncuToplamPuani += 100;
            bilinenSoruSayisi++;
            label3.Text = puan + " XP";
            label3.Location = new Point((this.Width - label3.Width) / 2, label3.Location.Y);
            SureyiAzalt();
        }
        public void YanlisCevap()
        {
            if (hak > 0)
            {
                hak--;
                OyuncuHakki(hak);
            }
            cevap.pictureBox1.ImageLocation = Application.StartupPath + dogruCevapBayrakYolu;
            cevap.label1.Text = "Yanlış";
            cevap.label1.ForeColor = Color.Red;
            timer1.Stop();
            timer2.Stop();
            cevap.axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\YanlisCevap.mp3";
            cevap.axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (Giris.ayarlar.oyunSesi == true)
                cevap.axWindowsMediaPlayer1.Ctlcontrols.play();
            cevap.ShowDialog();
            if (hak == 0)
            {
                OyuncuBilgileriniSonucaGonder(sonuc);
                sonuc.ShowDialog();
            }
        }
        public void OyuncuHakki(int hak2)
        {
            if (hak2 == 3)
                kalp1.Visible = false;
            if (hak2 == 2)
                kalp2.Visible = false;
            if (hak2 == 1)
                kalp3.Visible = false;
            if (hak2 == 0)
                kalp4.Visible = false;
            else if (hak2 > 3 || hak2 < 0)
                MessageBox.Show("Hata Geçerli hak sayısı Değil! " + hak2);
        }
        public void OyuncuBilgileriniSonucaGonder(Sonuc sonuc2)
        {
            sonuc2.pictureBox1.BackgroundImage = pictureBox1.BackgroundImage;
            sonuc2.label2.Text = label2.Text;
            sonuc2.label2.Location = new Point((sonuc2.Width - sonuc2.label2.Width) / 2, sonuc2.label2.Location.Y);
            sonuc2.label7.Text = oyuncuToplamPuani + " XP";
            sonuc2.label7.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label7.Width) / 2, sonuc2.label7.Location.Y);
            sonuc2.label8.Text = "+" + puan;
            sonuc2.label8.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label8.Width) / 2, sonuc2.label8.Location.Y);
            sonuc2.label9.Text = bilinenSoruSayisi.ToString();
            sonuc2.label9.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label9.Width) / 2, sonuc2.label9.Location.Y);
        }
        public void YenidenOyna()
        {
            kalp1.Visible = true;
            kalp2.Visible = true;
            kalp3.Visible = true;
            kalp4.Visible = true;
            label4.Text = (oyuncuToplamPuani) + " XP";
            puan = 0;

            if (oyunZorlugu == "Kolay")
            {
                hak = 4;
                oyunSuresi = 10000;
                oyunSuresiSiniri = 8000;
                progressBar1.Maximum = oyunSuresi;
                renkDegisim = 3;
            }
            if (oyunZorlugu == "Orta")
            {
                hak = 3;
                kalp1.Visible = false;
                kalp2.Location = new Point(604, 48);
                kalp3.Location = new Point(640, 48);
                kalp4.Location = new Point(676, 48);
                oyunSuresi = 8000;
                oyunSuresiSiniri = 6000;
                progressBar1.Maximum = oyunSuresi;
                renkDegisim = 5;
            }
            if (oyunZorlugu == "Zor")
            {
                hak = 2;
                kalp1.Visible = false;
                kalp2.Visible = false;
                kalp3.Location = new Point(625, 48);
                kalp4.Location = new Point(661, 48);
                oyunSuresi = 6000;
                oyunSuresiSiniri = 4000;
                progressBar1.Maximum = oyunSuresi;
                renkDegisim = 5;
            }
            bilinenSoruSayisi = 0;


            pictureBox5.ImageLocation = null;
            pictureBox6.ImageLocation = null;
            pictureBox7.ImageLocation = null;
            pictureBox8.ImageLocation = null;
            pictureBox9.ImageLocation = null;

            SoruyuYenile();

            label3.Text = puan + " XP";
            progressBar1.Value = 0;
            timer1.Start();
            timer2.Start();
        }
        public void SureyiAzalt()
        {
            if (bilinenSoruSayisi % 4 == 0 && oyunSuresi != oyunSuresiSiniri)
            {
                oyunSuresi -= 500;
                progressBar1.Maximum = oyunSuresi;
                timer2.Interval -= 100;
            }
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox5.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox6.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox7.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox8.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox9.BorderStyle = BorderStyle.Fixed3D;
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.BorderStyle = BorderStyle.None;
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.BorderStyle = BorderStyle.None;
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox7.BorderStyle = BorderStyle.None;
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox8.BorderStyle = BorderStyle.None;
        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox9.BorderStyle = BorderStyle.None;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void Oyun_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < oyunSuresi)
            {
                if (green > 0)
                {
                    green -= renkDegisim;
                    blue += renkDegisim;
                    progressBar1.ForeColor = Color.FromArgb(255, red, green, blue);
                }
                else if (red < 255)
                {
                    red += renkDegisim;
                    blue -= renkDegisim;
                    progressBar1.ForeColor = Color.FromArgb(255, red, green, blue);
                }
                progressBar1.Value += 50;
            }
            else
            {
                timer1.Stop();
                timer2.Stop();

                OyuncuBilgileriniSonucaGonder(sonuc);
                sonuc.ShowDialog();
            }
        }
    }
}
