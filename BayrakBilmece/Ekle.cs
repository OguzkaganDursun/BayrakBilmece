using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayrakBilmece
{
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }
        public Bilgilendirme bilgilendirme = new Bilgilendirme();
        public Uyari uyari = new Uyari();
        private void button2_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();

            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && pictureBox1.ImageLocation != null)
            {
                TextBox[] texts = new TextBox[4];
                ComboBox combo = new ComboBox();
                texts[0] = textBox1;
                texts[1] = textBox2;
                texts[2] = textBox3;
                texts[3] = textBox4;
                combo = comboBox1;
                Giris.yonetici.Ekle(texts, combo, pictureBox1);

                bilgilendirme.textBox1.Text = "Veri Eklendi";
                bilgilendirme.ShowDialog();
                this.Close();
            }
            else
            {
                uyari.textBox1.Text = "Lütfen Bütün Alanları Doldurunuz";
                uyari.ShowDialog();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            openFileDialog1.Title = "Bayrak Seçiniz!";
            openFileDialog1.Filter = "Png(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void Ekle_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\ButonSesi.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        public void ButonMuzigiCal()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
