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
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into ulke_bilgileri values(16,'Asya','İran','Tahran','83M')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ülke Eklendi");
                
            }
            catch (Exception acikla)
            {
                MessageBox.Show(acikla.Message,"Ülke Eklenemedi");
            }
            //Ekle ekle = new Ekle();
            //ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duzenle duzenle = new Duzenle();
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
            }
        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
            KayitlariListele();
        }
    }
}
