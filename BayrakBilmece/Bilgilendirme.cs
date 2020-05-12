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
    public partial class Bilgilendirme : Form
    {
        public Bilgilendirme()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            this.Close();
        }
        private void Bilgilendirme_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\ButonSesi.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        public void ButonMuzigiCal()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
