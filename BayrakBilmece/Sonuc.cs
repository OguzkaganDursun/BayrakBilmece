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
    public partial class Sonuc : Form
    {
        public Sonuc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Giris.anaMenu.label3.Text = label7.Text;
            Giris.anaMenu.oyuncuToplamPuani = OyunAyari.oyun.oyuncuToplamPuani + OyunAyari.oyun.puan;
            Giris.anaMenu.Show();
            OyunAyari.oyun.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OyunAyari.oyun.YenidenOyna();
            this.Close();
        }
    }
}
