using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnders_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmÖğrenci fr = new FrmÖğrenci();
            fr.Show();
        }

        private void btnsınavnotlar_Click(object sender, EventArgs e)
        {
            FrmSınavnotlar fr=new FrmSınavnotlar();
            fr.Show();
        }
    }
}
