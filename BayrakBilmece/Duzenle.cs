﻿using System;
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
    public partial class Duzenle : Form
    {
        OleDbConnection baglanti =new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Ulke.mdb");
        public Duzenle()
        {
            InitializeComponent();
        }
        string dosyaYolu;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {          
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update ulke_bilgileri set Isim='" + textBox2.Text + "',Baskent='" + textBox3.Text + "',Nufus='" + textBox4.Text + "',Kita='" + comboBox1.Text + "',Bayrak='"+dosyaYolu+"' where Id=" + Convert.ToInt32(textBox1.Text), baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                //MessageBox.Show("İşlem Tamam");
                Bilgilendirme();              
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message,"İşlem başarısız");
                baglanti.Close();
            }
        }
        private void Bilgilendirme()
        {
            Giris.yonetici.KayitlariListele();
            Bilgilendirme bilgilendirme = new Bilgilendirme();
            bilgilendirme.textBox1.Text = "Veri Güncellendi";
            bilgilendirme.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Bayrak Seçiniz!";
            openFileDialog1.FileName = textBox2.Text;
            openFileDialog1.Filter = "Png(*.png)|*.png";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
                pictureBox1.ImageLocation = openFileDialog1.FileName;          
            dosyaYolu = openFileDialog1.FileName;
            string uygulamaYolu;
            uygulamaYolu = Application.StartupPath;
            int yolUzunlugu;
            yolUzunlugu = uygulamaYolu.Length;
            dosyaYolu = dosyaYolu.Remove(0,yolUzunlugu);
        }

        private void Duzenle_Load(object sender, EventArgs e)
        {
            dosyaYolu = pictureBox1.ImageLocation;
            DosyaYolu();
        }
        public void DosyaYolu()
        {
            string uygulamaYolu;
            uygulamaYolu = Application.StartupPath;
            int yolUzunlugu;
            yolUzunlugu = uygulamaYolu.Length;
            dosyaYolu = dosyaYolu.Remove(0, yolUzunlugu);
        }
    }
}
