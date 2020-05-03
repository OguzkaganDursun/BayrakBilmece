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
        public void karakterSec(Image resim)
        {
            pictureBox1.Image = resim;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
