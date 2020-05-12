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
    public partial class Cevap : Form
    {
        public Cevap()
        {
            InitializeComponent();
        }
        bool yeniSoru = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                Giris.anaMenu.ButonMuzigiCal();
            if (Giris.anaMenu.oyunAyari.oyun.hak > 0)
                Giris.anaMenu.oyunAyari.oyun.SoruyuYenile();
            yeniSoru = false;
            this.Close();
        }
        private void Cevap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (yeniSoru == true)
            {
                if (Giris.ayarlar.oyunSesi == true)
                    Giris.anaMenu.ButonMuzigiCal();
                if (Giris.anaMenu.oyunAyari.oyun.hak > 0)
                    Giris.anaMenu.oyunAyari.oyun.SoruyuYenile();
            }
            yeniSoru = true;
        }
    }
}
