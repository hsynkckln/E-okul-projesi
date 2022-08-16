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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection sn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\nevse\OneDrive\Masaüstü\okulprojesi\okulprojesi\proje.mdf';Integrated Security=True");
        public void liste()
        {

            SqlDataAdapter dt = new SqlDataAdapter("select * from Kulupler ", sn);
            DataTable dr = new DataTable();
            dt.Fill(dr);
            dataGridView1.DataSource = dr;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand komut = new SqlCommand("update kulupler set kulup_adi=@p1 where kulup_id=@p2", sn);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand komut = new SqlCommand("insert into Kulupler (kulup_adi) values (@p1)", sn);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            sn.Open();
            SqlCommand komut = new SqlCommand("delete from Kulupler where kulup_id=@p1", sn);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }
    }
}
