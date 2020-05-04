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
            label = Giris.anaMenu.label3;
            label4.Text = label.Text;

            //toplamKayitSayi = ToplamKayitSayisi();
            //MessageBox.Show(toplamKayitSayi.ToString());
            SoruHazirla();
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

        public void SoruHazirla()
        {
            Random rastgele = new Random();
            int salla,ipucu;
            int[] dizilerim = new int[3];
            int a = 0;
            ipucu = rastgele.Next(1,4);
            
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
                    soruMetni += "İsmi " + "isimDeğişkeni";
                if (dizilerim[i] == 2)
                    soruMetni += "Başkent " + "baskentDeğişkeni";
                if (dizilerim[i] == 3)
                    soruMetni += "Nüfus " + "nufusDeğişkeni";
                if((i+1)<ipucu)
                    soruMetni += " ve ";
            }
            textBox2.Text = soruMetni;
        }
    }
}
