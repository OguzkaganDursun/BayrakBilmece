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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        public bool oyunSesi;
        public bool muzikSesi=false;
        public int muzikSesiVolume;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton3.Checked)
            //    muzikSesi = true;
            //MessageBox.Show(muzikSesi.ToString());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton4.Checked)
            //    muzikSesi = false;
            //MessageBox.Show(muzikSesi.ToString());
        }
    }
}
