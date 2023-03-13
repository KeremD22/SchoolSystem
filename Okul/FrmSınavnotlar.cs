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

namespace Okul
{
    public partial class FrmSınavnotlar : Form
    {
        public FrmSınavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM;Initial Catalog=BonusOkul;Integrated Security=True");
        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtöğrenciid.Text));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSınavnotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "Dersad";
            cmbders.ValueMember = "Dersid";
            cmbders.DataSource = dt;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtöğrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            string durum;
            sinav1 = Convert.ToInt16(txtsinav1.Text);
            sinav2 = Convert.ToInt16(txtsinav2.Text);
            sinav3 = Convert.ToInt16(txtsinav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";    
            }


        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.NotGüncelle(byte.Parse(cmbders.SelectedText),int.Parse(txtöğrenciid.Text),txtsinav1,txtsinav2,txtsinav3,txtproje,txtortalama,bool.Parse(txtdurum.Text));
        }
    }
}
