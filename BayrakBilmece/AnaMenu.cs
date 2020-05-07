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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }
        public int oyuncuToplamPuani=3000;
        private void button1_Click(object sender, EventArgs e)
        {
            OyunAyari oyunAyari = new OyunAyari();
            oyunAyari.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KarakterSecimi karakterSecimi = new KarakterSecimi();
            karakterSecimi.ShowDialog();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            label2.Text = Giris.isimGirisi;
            label3.Text = oyuncuToplamPuani+" XP";
        }

        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
