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
    public partial class Cevap : Form
    {
        public Cevap()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(OyunAyari.oyun.hak>0)
                OyunAyari.oyun.SoruyuYenile();
            this.Close();
        }
    }
}
