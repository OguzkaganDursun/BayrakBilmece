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
    public partial class SilOnay : Form
    {
        public SilOnay()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilgilendirme bilgilendirme = new Bilgilendirme();
            bilgilendirme.textBox1.Text = "Veri Silindi";
            bilgilendirme.textBox1.ForeColor = Color.Red;
            Giris.yonetici.KayitSil();
            bilgilendirme.ShowDialog();
            this.Close();
            
        }
    }
}
