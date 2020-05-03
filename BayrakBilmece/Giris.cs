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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        int nokta = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int yuzde;

            if (progressBar1.Value < 100)
            {
                yuzde = progressBar1.Value += 100 / 20;
                label3.Text = "%" + yuzde;
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                PanelGotur(panel2);             
                PanelGetir(panel3);
                PanelGetir2(panel5);
            }     
        }

        private void timer2_Tick(object sender, EventArgs e)
        {          
            if (progressBar1.Value < 100)
            {
                nokta++;
                label2.Text = "Oyun Yükleniyor";
                for (int a = 0; a < nokta; a++)
                {
                    label2.Text = label2.Text + ".";
                }
                if (nokta > 3)
                {
                    nokta = 0;
                    label2.Text = "Oyun Yükleniyor";
                }                   
            }
        }
        
        public void PanelGetir(Panel panel)
        {
            panel.Location = new Point(0,220);
        }
        public void PanelGetir2(Panel panel)
        {
            panel.Location = new Point(0, 460);
        }
        public void PanelGotur(Panel panel)
        {
            panel.Location = new Point(-300, 220);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelGotur(panel3);
            PanelGetir(panel4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelGotur(panel3);
            PanelGetir(panel6);
        }
        public static AnaMenu anaMenu = new AnaMenu();
        private void button7_Click(object sender, EventArgs e)
        {                     
            anaMenu.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yonetici yonetici = new Yonetici();
            yonetici.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.ShowDialog();
            ayarlar.button1.Text = "Oğuz";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
