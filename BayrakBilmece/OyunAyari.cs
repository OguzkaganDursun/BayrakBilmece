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
    public partial class OyunAyari : Form
    {
        public OyunAyari()
        {
            InitializeComponent();
        }
        public Oyun oyun = new Oyun();
        public Uyari uyari = new Uyari();
        private void button2_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();

            if (checkBox1.Checked)
                oyun.kitalar[0] = "Afrika";
            if (checkBox2.Checked)
                oyun.kitalar[1] = "Asya";
            if (checkBox3.Checked)
                oyun.kitalar[2] = "Avrupa";
            if (checkBox4.Checked)
                oyun.kitalar[3] = "Güney Amerika";
            if (checkBox5.Checked)
                oyun.kitalar[4] = "Kuzey Amerika";
            if (checkBox6.Checked)
                oyun.kitalar[5] = "Okyanusya";
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked
                && !checkBox6.Checked)
            {
                uyari.textBox1.Text = "En Az Bir Kıta Seçiniz!";
                uyari.ShowDialog();
            }
            else
            {
                Giris.anaMenu.MuzikDurdur(false);
                oyun.oyunZorlugu = comboBox1.Text;
                oyun.YenidenOyna();
                oyun.Show();
                this.Close();
                Giris.anaMenu.Hide();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
        }
    }
}
