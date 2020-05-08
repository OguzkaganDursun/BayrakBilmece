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
        public int oyuncuToplamPuani=0;
        public int oyunSuresi = 10000;
        public int oyunSuresiSiniri = 9000;


        public int dogruCevap=0;
        public string dogruCevapBayrakYolu;
        public int[] secilenPicBoxlar=new int[5];
        public int picSirasi = 0;
        int ulkeNo;
        string bayrakYolu;
        public int puan = 0;
        public int hak=4;
        public int bilinenSoruSayisi = 0;

        PictureBox pictureBox = new PictureBox();
        Label label = new Label();
        int toplamKayitSayi=0;
        string soruMetni;
        private void Oyun_Load(object sender, EventArgs e)
        {
            pictureBox = Giris.anaMenu.pictureBox1;            
            label = Giris.anaMenu.label2;
            pictureBox1.BackgroundImage = pictureBox.BackgroundImage;
            label2.Text = label.Text;
            oyuncuToplamPuani = Giris.anaMenu.oyuncuToplamPuani;
            label4.Text = oyuncuToplamPuani+" XP";           

            RastgeleUlkeSec();
            BosBayraklaraAtama();
            progressBar1.Maximum = oyunSuresi;
            timer1.Enabled = true;
        }
        public int ToplamKayitSayisi()
        {         
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select count(*) from ulke_bilgileri",baglanti);
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

        public void SoruHazirla(string isim,string baskent,string nufus)
        {
            Random rastgele = new Random();
            int salla,ipucu;
            int[] dizilerim = new int[3];
            int a = 0;
            ipucu = rastgele.Next(2,4);
            
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
            for (int i=0;i< ipucu; i++)
            {
                if (dizilerim[i] == 1)
                    soruMetni += "İsmi '" + isim + "'";
                if (dizilerim[i] == 2)
                    soruMetni += "Başkent '" + baskent + "'";
                if (dizilerim[i] == 3)
                    soruMetni += "Nüfus '" + nufus + "'";
                if((i+1)<ipucu)
                    soruMetni += " ve ";
            }
            soruMetni += " olan ülke?";
            textBox2.Text = soruMetni;
        }
        public void RastgeleUlkeSec()
        {
            Random rstSayi=new Random();
            int kayıtSayisi = ToplamKayitSayisi();
            int secilenUlke;
            int secilenPicBox;
            secilenPicBox = rstSayi.Next(1,6);
            secilenUlke = rstSayi.Next(1,kayıtSayisi);
            try
            {
                int id = 1;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (id <= secilenUlke)
                {
                    oku.Read();
                    id++;
                }

                if (dogruCevap == 0)
                {
                    dogruCevap = secilenPicBox;
                    dogruCevapBayrakYolu= oku[5].ToString();
                    secilenPicBoxlar[secilenPicBox-1] = Convert.ToInt32(oku[0]);
                    BayrakResmiYerlestir(secilenPicBox, oku[5].ToString());
                    SoruHazirla(oku[2].ToString(), oku[3].ToString(), oku[4].ToString());
                }
                else
                {
                    secilenPicBoxlar[picSirasi] = secilenPicBox;
                    BayrakResmiYerlestir(secilenPicBox, oku[5].ToString());
                }              
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Ülke Seçilemedi!");
                baglanti.Close();
            }
        }

        public void BayrakResmiYerlestir(int sayi,string bayrakKonumu)
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
            for (int i=1;i<6;i++)
            {
                UlkeSec();
                int b = 0;
                for (int a = 0; a < 5; a++)
                {
                    if (ulkeNo == secilenPicBoxlar[a])
                        b++;
                }
                if (b == 0)
                {
                    secilenPicBoxlar[i-1]=ulkeNo;
                    BayrakResmiYerlestir(i,bayrakYolu);
                }
                else
                    i--;
            }
            
        }
        public void UlkeSec()
        {
            Random rstSayi = new Random();
            int kayıtSayisi = ToplamKayitSayisi();
            int secilenUlke;
            secilenUlke = rstSayi.Next(1, kayıtSayisi);
            try
            {
                int id = 1;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (id <= secilenUlke)
                {
                    oku.Read();
                    id++;
                }
                ulkeNo = Convert.ToInt32(oku[0]);
                bayrakYolu = oku[5].ToString();
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Ülke Seçilemedi!");
                baglanti.Close();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 1)
            {
                DogruCevap();
                SoruyuYenile();
            }
            else
            {
                YanlisCevap();
                SoruyuYenile();
            }              
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 2)
            {
                DogruCevap();
                SoruyuYenile();
            }
            else
            {
                YanlisCevap();
                SoruyuYenile();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 3)
            {
                DogruCevap();
                SoruyuYenile();
            }
            else
            {
                YanlisCevap();
                SoruyuYenile();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 4)
            {
                DogruCevap();
                SoruyuYenile();
            }
            else
            {
                YanlisCevap();
                SoruyuYenile();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (dogruCevap == 5)
            {
                DogruCevap();
                SoruyuYenile();
            }
            else
            {
                YanlisCevap();
                SoruyuYenile();
            }
        }

        public void SoruyuYenile()
        {
            dogruCevap = 0;
            dogruCevapBayrakYolu="";
            secilenPicBoxlar[0] = 0;
            secilenPicBoxlar[1] = 0;
            secilenPicBoxlar[2] = 0;
            secilenPicBoxlar[3] = 0;
            secilenPicBoxlar[4] = 0;
            picSirasi = 0;
            ulkeNo=0;
            bayrakYolu="";
            toplamKayitSayi = 0;
            soruMetni="";            
            pictureBox5.ImageLocation = null;
            pictureBox6.ImageLocation = null;
            pictureBox7.ImageLocation = null;
            pictureBox8.ImageLocation = null;
            pictureBox9.ImageLocation = null;
            RastgeleUlkeSec();
            BosBayraklaraAtama();
        }
        public void DogruCevap()
        {
            Cevap cevap = new Cevap();
            cevap.pictureBox1.ImageLocation = Application.StartupPath + dogruCevapBayrakYolu;
            cevap.label1.Text = "Tebrikler";
            cevap.label1.ForeColor = Color.Gold;
            cevap.label1.Location = new Point((cevap.Width-cevap.label1.Width)/2,cevap.label1.Location.Y);
            timer1.Stop();
            cevap.ShowDialog();
            puan += 100;
            oyuncuToplamPuani += 100;
            bilinenSoruSayisi++;
            label3.Text = puan + " XP";
            label3.Location = new Point((this.Width-label3.Width)/2,label3.Location.Y);
            SureyiAzalt();
            progressBar1.Value = 0;
            timer1.Start();
        }
        public void YanlisCevap()
        {
            Cevap cevap = new Cevap();
            cevap.pictureBox1.ImageLocation = Application.StartupPath + dogruCevapBayrakYolu;
            cevap.label1.Text = "Yanlış";
            cevap.label1.ForeColor = Color.Red;
            timer1.Stop();
            cevap.ShowDialog();
            progressBar1.Value = 0;
            
            if (hak > 0)
            {
                hak--;
                OyuncuHakki(hak);
                if (hak == 0)
                {
                    Sonuc sonuc = new Sonuc();
                    OyuncuBilgileriniSonucaGonder(sonuc);                   
                    sonuc.ShowDialog();
                }
            }
            timer1.Start();
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
            else if(hak2>3||hak2<0)
                MessageBox.Show("Hata Geçerli hak sayısı Değil! "+hak2);
        }
        public void OyuncuBilgileriniSonucaGonder(Sonuc sonuc2)
        {
            
            sonuc2.pictureBox1.BackgroundImage = pictureBox1.BackgroundImage;
            sonuc2.label2.Text = label2.Text;
            sonuc2.label2.Location = new Point((sonuc2.Width-sonuc2.label2.Width)/2,sonuc2.label2.Location.Y);
            sonuc2.label7.Text = oyuncuToplamPuani + " XP";
            sonuc2.label7.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label7.Width) / 2, sonuc2.label7.Location.Y);
            sonuc2.label8.Text = "+" + puan;
            sonuc2.label8.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label8.Width) / 2, sonuc2.label8.Location.Y);
            sonuc2.label9.Text = bilinenSoruSayisi.ToString();
            sonuc2.label9.Location = new Point((sonuc2.groupBox1.Width - sonuc2.label9.Width) / 2, sonuc2.label9.Location.Y);
        }

        public void  YenidenOyna()
        {
            label4.Text = (oyuncuToplamPuani) + " XP";
            puan = 0;
            hak = 4;
            bilinenSoruSayisi = 0;
            kalp1.Visible = true;
            kalp2.Visible = true;
            kalp3.Visible = true;
            kalp4.Visible = true;

            pictureBox5.ImageLocation = null;
            pictureBox6.ImageLocation = null;
            pictureBox7.ImageLocation = null;
            pictureBox8.ImageLocation = null;
            pictureBox9.ImageLocation = null;

            SoruyuYenile();

            label3.Text = puan + " XP";        
            progressBar1.Value = 0;
            timer1.Start();
        }
        public void SureyiAzalt()
        {
            if (bilinenSoruSayisi%4==0 && oyunSuresi != oyunSuresiSiniri)
            {
                oyunSuresi -= 500;
                progressBar1.Maximum = oyunSuresi;
                MessageBox.Show("Bilinen Soru Sayısı = "+bilinenSoruSayisi+"\nOyun Süresi = "+oyunSuresi);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < oyunSuresi)
            {
                progressBar1.Value += 50;
            }
            else
            {
                timer1.Stop();
                Sonuc sonuc = new Sonuc();
                OyuncuBilgileriniSonucaGonder(sonuc);               
                sonuc.ShowDialog();
            }
        }


    }
}
