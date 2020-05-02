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
                nokta++;
                if (nokta == 1)
                    label2.Text = "Oyun YükleniyorA.";
                if (nokta == 2)
                    label2.Text = "Oyun YükleniyorAA..";
                if (nokta == 3)
                {
                    label2.Text = "Oyun YükleniyorAAA...";
                }
                else
                {
                    label2.Text = "Oyun Yükleniyor";
                    nokta = 0;
                }
                    
            }
            else
                timer1.Stop();
                
        }
    }
}
