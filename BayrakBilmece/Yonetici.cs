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
            BilgilendirmeSilindi bilgilendirme = new BilgilendirmeSilindi();
            bilgilendirme.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaMenu anaMenu = new AnaMenu();
            anaMenu.Show();
            this.Close();
        }
        private void KayitlariListele()
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

        private void Yonetici_Load(object sender, EventArgs e)
        {
            KayitlariListele();
        }
        private void Ekle()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into ulke_bilgileri(id,kita,isim,baskent,nufus) values(18,'Asya','İran','Tahran','83M')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ülke Eklendi");
                KayitlariListele();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message, "Ülke Eklenemedi");
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
                text[1].Text = oku[1].ToString();
                text[2].Text = oku[2].ToString();
                text[3].Text = oku[3].ToString();
                combo.Text = oku[4].ToString();
                baglanti.Close();
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message,"işlem Başarısız");
                baglanti.Close();
            }
        }

    }
}
