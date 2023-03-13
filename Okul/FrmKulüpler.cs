using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Okul
{
    public partial class FrmKulüpler : Form
    {
        public FrmKulüpler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmKulüpler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Tbl_Kulupler (Kulupad) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp listeye eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Tbl_Kulupler where Kulupid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text); 
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleştirildi.");
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Kulupler set Kulupad=@p1 where Kulupid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp güncelleme işlemi gerçekleştirildi.");


        }
    }
}
