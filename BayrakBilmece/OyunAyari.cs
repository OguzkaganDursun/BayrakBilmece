﻿using System;
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
            if (checkBox1.Checked == true)
                oyun.kitalar[0] = "Afrika";
            if (checkBox2.Checked == true)
                oyun.kitalar[1] = "Asya";
            if (checkBox3.Checked == true)
                oyun.kitalar[2] = "Avrupa";
            if (checkBox4.Checked == true)
                oyun.kitalar[3] = "Güney Amerika";
            if (checkBox5.Checked == true)
                oyun.kitalar[4] = "Kuzey Amerika";
            if (checkBox6.Checked == true)
                oyun.kitalar[5] = "Okyanusya";
            oyun.YenidenOyna();
            oyun.Show();
            this.Close();
            Giris.anaMenu.Hide();
        }
    }
}
