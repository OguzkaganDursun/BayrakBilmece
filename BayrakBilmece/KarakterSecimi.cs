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
    public partial class KarakterSecimi : Form
    {
        public KarakterSecimi()
        {
            InitializeComponent();
        }
        PictureBox pictureBox = new PictureBox();
        
        public void KarakterSec(PictureBox karakter)
        {
            pictureBox = Giris.anaMenu.pictureBox1;
            pictureBox.BackgroundImage = karakter.BackgroundImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KarakterSecimi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox6);
        }
    }
}
