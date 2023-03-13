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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(textBox2.Text);
            MessageBox.Show("Kulup başarıyla eklenmiştir.");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(textBox1.Text));

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(textBox2.Text,byte.Parse(textBox1.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
