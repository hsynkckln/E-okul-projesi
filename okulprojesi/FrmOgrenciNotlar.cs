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

namespace okulprojesi
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        
        SqlConnection sn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\nevse\OneDrive\Masaüstü\okulprojesi\okulprojesi\proje.mdf';Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select ders_adi,sinav1,sinav2,sinav3,proje,ortalama,durum from Notlar n, Dersler d where d.ders_id=n.ders_id and ogrenci_id=@p1 ", sn);
            cmd.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
