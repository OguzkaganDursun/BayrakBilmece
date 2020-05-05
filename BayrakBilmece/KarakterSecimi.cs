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
        PictureBox oncekiPictureBox = new PictureBox();
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
            if(oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox1;
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox2);
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox2;
            this.pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox3);
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox3;
            this.pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox4);
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox4;
            this.pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox5);
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox5;
            this.pictureBox5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            KarakterSec(pictureBox6);
            if (oncekiPictureBox != null)
            {
                oncekiPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
            oncekiPictureBox = pictureBox6;
            this.pictureBox6.BorderStyle = BorderStyle.Fixed3D;
        }

        
    }
}
