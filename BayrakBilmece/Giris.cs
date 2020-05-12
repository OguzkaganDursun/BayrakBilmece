using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;

namespace BayrakBilmece
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        public static string isimGirisi;
        string yoneticiSifre = "9799";
        public static AnaMenu anaMenu = new AnaMenu();
        public static Yonetici yonetici = new Yonetici();
        public static Ayarlar ayarlar = new Ayarlar();
        public static Bilgilendirme bilgilendirme = new Bilgilendirme();
        public static Uyari uyari = new Uyari();
        public static AxWindowsMediaPlayer mediaPlayer = new AxWindowsMediaPlayer();
        public static Giris giris = new Giris();

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
            panel.Location = new Point(0, 220);
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
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PanelGotur(panel3);
            PanelGetir(panel6);
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            isimGirisi = textBox1.Text;
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            if (textBox1.Text == "İsim" || textBox1.Text == "" || textBox1.Text == " " || textBox1.Text == "  ")
            {
                uyari.textBox1.Text = "Lütfen Bir İsim Giriniz !";
                uyari.ShowDialog();
            }
            else
            {
                anaMenu.Show();
                giris.Hide();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            if (textBox2.Text == yoneticiSifre)
            {
                yonetici.Show();
                giris.Hide();
            }
            else
            {
                uyari.textBox1.Text = "Hatalı Giriş Yaptınız !";
                uyari.ShowDialog();
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            ayarlar.button1.Text = "Geri Dön";
            ayarlar.ShowDialog();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            giris.Close();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            if (e.KeyCode == Keys.Enter)
            {
                isimGirisi = textBox1.Text;
                if (textBox1.Text == "İsim" || textBox1.Text == "" || textBox1.Text == " " || textBox1.Text == "  ")
                {
                    uyari.textBox1.Text = "Lütfen Bir İsim Giriniz !";
                    uyari.ShowDialog();
                }
                else
                {
                    anaMenu.Show();
                    giris.Hide();
                }
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (Giris.ayarlar.oyunSesi == true)
                ButonMuzigiCal();
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == yoneticiSifre)
                {
                    yonetici.Show();
                    giris.Hide();
                }
                else
                {
                    uyari.textBox1.Text = "Hatalı Giriş Yaptınız !";
                    uyari.ShowDialog();
                }
            }
        }
        private void Giris_Load(object sender, EventArgs e)
        {
            giris = this;
            if (ayarlar.oyunSesi == false)
                ayarlar.oyunSesi = true;
            if (ayarlar.muzikSesi == false)
                ayarlar.muzikSesi = true;
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Muzik\\ButonSesi.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            mediaPlayer = axWindowsMediaPlayer1;
        }
        public void ButonMuzigiCal()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        public void YenidenBasla()
        {
            panel2.Location = new Point(0, 220);
            panel3.Location = new Point(301, 220);
            panel4.Location = new Point(601, 220);
            panel5.Location = new Point(301, 461);
            panel6.Location = new Point(901, 220);
            progressBar1.Value = 0;
            label3.Text = "%0";
            textBox1.Text = "";
            textBox2.Text = "";
            nokta = 0;
            label2.Text = "Oyun Yükleniyor";
            timer1.Start();
            timer2.Start();
        }
    }
}
