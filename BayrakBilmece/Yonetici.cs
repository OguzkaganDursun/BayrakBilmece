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
    public partial class Yonetici : Form
    {
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
    }
}
