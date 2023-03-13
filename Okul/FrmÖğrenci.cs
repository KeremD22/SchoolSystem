using Okul.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Okul
{
    public partial class FrmÖğrenci : Form
    {
        public FrmÖğrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmÖğrenci_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource= ds.ÖğrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "Kulupad";
            cmbkulup.ValueMember = "Kulupid";
            cmbkulup.DataSource = dt;
            baglanti.Close();




        }
        string c = "";

        private void btnekle_Click(object sender, EventArgs e)
        {
           
        
            ds.ÖğrenciEkle(txtad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), txtsoyad.Text,c);
            MessageBox.Show("Öğrenci ekleme işlemi gerçekleştirildi.");

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğrenciListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ÖğrenciSil(int.Parse(txtöğrenciid.Text));
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtöğrenciid.Text = cmbkulup.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtöğrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
           

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖğrenciGüncelleme(txtad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()),txtsoyad.Text , c, int.Parse(txtöğrenciid.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
         
            if (radioButton2.Checked == true)

            {
                c = "Erkek";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
          
        }

        private void btnara_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource= ds.Öğrencigetir(txtara.Text);
        }
    }
}
