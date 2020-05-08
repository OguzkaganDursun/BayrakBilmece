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
        public static Oyun oyun = new Oyun();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                Uyari uyari = new Uyari();
                uyari.textBox1.Text = "En Az Bir Kıta Seçiniz!";
                uyari.ShowDialog();
            }
            else
            {
                oyun.YenidenOyna();
                oyun.Show();
                this.Close();
                Giris.anaMenu.Hide();
            }
        }
    }
}
