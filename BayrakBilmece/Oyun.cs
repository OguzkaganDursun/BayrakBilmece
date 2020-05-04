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
    public partial class Oyun : Form
    {
        public Oyun()
        {
            InitializeComponent();
        }
        PictureBox pictureBox = new PictureBox();
        Label label = new Label();
        private void Oyun_Load(object sender, EventArgs e)
        {           
            pictureBox = Giris.anaMenu.pictureBox1;            
            label = Giris.anaMenu.label2;
            pictureBox1.BackgroundImage = pictureBox.BackgroundImage;
            label2.Text = label.Text;
            label = Giris.anaMenu.label3;
            label4.Text = label.Text;
        }
    }
}
