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
    public partial class Yonetici : Form
    {
        OleDbConnection baglanti =new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        
        public Yonetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ekle ekle = new Ekle();
            IdGetir(ekle.textBox1);
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duzenle duzenle = new Duzenle();
            //duzenle.textBox1.Text = dataGridView1.CurrentRow.Index.ToString();
            TextBox[] texts = new TextBox[4];
            texts[0] = duzenle.textBox1;
            texts[1] = duzenle.textBox2;
            texts[2] = duzenle.textBox3;
            texts[3] = duzenle.textBox4;
            ComboBox combo = duzenle.comboBox1;
            Verileriyerlestir(texts,combo);
            duzenle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SilOnay silOnay = new SilOnay();
            silOnay.ShowDialog();
            //Bilgilendirme bilgilendirme = new Bilgilendirme();
            //bilgilendirme.textBox1.Text = "Veri Silindi";
            //bilgilendirme.textBox1.ForeColor = Color.Red;
           // KayitSil();
            //bilgilendirme.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Close();
        }
        public void KayitlariListele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select *from ulke_bilgileri", baglanti);
                DataSet dsHafiza = new DataSet();
                liste.Fill(dsHafiza);
                dataGridView1.DataSource = dsHafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Veriler Listelenemedi!");
                baglanti.Close();
            }
        }
        public void IdGetir(TextBox text)
        {
            try
            {
                int id = 1;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    id++;
                }
                text.Text = id.ToString();
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "işlem Başarısız");
                baglanti.Close();
            }
        }
        public void Yonetici_Load(object sender, EventArgs e)
        {
            KayitlariListele();
            
            IdGetir(textBox1);
            textBox1.Text = (Convert.ToInt32(textBox1.Text)-1).ToString();
        }
        public void Ekle(TextBox[] texts,ComboBox combo)
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into ulke_bilgileri(Id,Kita,Isim,Baskent,Nufus) values('"+texts[0].Text.ToString()+ "','" + combo.Text.ToString() + "','" + texts[1].Text.ToString() + "','" + texts[2].Text.ToString() + "','" + texts[3].Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Ülke Eklenemedi");
                baglanti.Close();
            }
        }
        private void Verileriyerlestir(TextBox[] text, ComboBox combo)
        {
            try
            {
                baglanti.Open();
                int id = 0;
                id = dataGridView1.CurrentRow.Index;
                OleDbCommand komut = new OleDbCommand("select * from ulke_bilgileri", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                for (int a=0;a<=id;a++)
                {
                    oku.Read();
                }
                text[0].Text = oku[0].ToString();
                text[1].Text = oku[2].ToString();
                text[2].Text = oku[3].ToString();
                text[3].Text = oku[4].ToString();
                combo.Text = oku[1].ToString();
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message,"işlem Başarısız");
                baglanti.Close();
            }
        }

        public void KayitSil()
        {
            try
            {
                int id = 0;
                id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) ;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("delete from ulke_bilgileri where Id="+id, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Islem Başarısız");
                baglanti.Close();
            }
            IdSirala();
        }
        
        
        public void IdSirala()
        {
            TextBox text1 = new TextBox();
            IdGetir(text1);
            int id = Convert.ToInt32(text1.Text)-1;

            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select Id from ulke_bilgileri", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                for (int a = 1; a <= id; a++)
                {
                    oku.Read();
                    OleDbCommand komut1 = new OleDbCommand("update ulke_bilgileri set Id=" + a + " where Id=" + oku[0], baglanti);
                    komut1.ExecuteNonQuery();
                }
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "işlem Başarısız");
                baglanti.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KayitlariListele();
            IdGetir(textBox1);
            textBox1.Text = (Convert.ToInt32(textBox1.Text) - 1).ToString();
        }
    }
}
