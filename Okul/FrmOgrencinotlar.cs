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
    public partial class FrmOgrencinotlar : Form
    {
        public FrmOgrencinotlar()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM;Initial Catalog=BonusOkul;Integrated Security=True");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Dersad,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum From Tbl_Notlar\r\nInner join Tbl_Dersler on Tbl_Notlar.Dersid=Tbl_Dersler.Dersid where Ogrenciid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            this.Text = numara.ToString();
            SqlDataAdapter dataAdapter= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource= dt;
        }
    }
}
