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
    public partial class OyunAyari : Form
    {
        public OyunAyari()
        {
            InitializeComponent();
        }
        public static Oyun oyun = new Oyun();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oyun.YenidenOyna();
            oyun.Show();
            this.Close();
            Giris.anaMenu.Hide();
        }
    }
}
