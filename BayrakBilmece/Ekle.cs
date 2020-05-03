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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilgilendirme bilgilendirme = new Bilgilendirme();
            TextBox[] texts = new TextBox[4];
            ComboBox combo = new ComboBox();
            texts[0]= textBox1;
            texts[1] = textBox2;
            texts[2] = textBox3;
            texts[3] = textBox4;
            combo = comboBox1;
            Giris.yonetici.Ekle(texts,combo);

            bilgilendirme.textBox1.Text = "Veri Eklendi";
            bilgilendirme.ShowDialog();
            this.Close();
        }   
    }
}
