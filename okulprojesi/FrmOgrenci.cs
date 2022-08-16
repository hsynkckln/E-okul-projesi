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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection sn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\nevse\OneDrive\Masaüstü\okulprojesi\okulprojesi\proje.mdf';Integrated Security=True");
       

        public void liste()
        {

            SqlDataAdapter dt = new SqlDataAdapter("select * from Ogrenciler ", sn);
            DataTable dr = new DataTable();
            dt.Fill(dr);
            dataGridView1.DataSource = dr;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand cmd = new SqlCommand("select * from Kulupler", sn);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataTable dr = new DataTable();
            dt.Fill(dr);
            comboBox1.DisplayMember = "kulup_adi";
            comboBox1.ValueMember = "kulup_id";
            comboBox1.DataSource = dr;
            sn.Close();


            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string c = " ";

            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }


            sn.Open();
            SqlCommand komut = new SqlCommand("insert into Ogrenciler (ogrenci_ad,ogrenci_soyad,ogrenci_cinsiyet,ogrenci_kulup) values (@p1,@p2,@p3,@p4)", sn);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", c);
            komut.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand komut = new SqlCommand("delete from Ogrenciler where ogrenci_id=@ogrenci_id", sn);
            komut.Parameters.AddWithValue("@ogrenci_id", textBox1.Text);
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }
        string c = " ";
        private void button2_Click(object sender, EventArgs e)
        {
           

            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }


            sn.Open();
            SqlCommand komut = new SqlCommand("update Ogrenciler set ogrenci_ad=@p1,ogrenci_soyad=@p2,ogrenci_cinsiyet=@p3,ogrenci_kulup=@p4 where ogrenci_id=@ogrenci_id", sn);
            komut.Parameters.AddWithValue("@ogrenci_id", textBox1.Text);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3",c);
            komut.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            
            komut.ExecuteNonQuery();
            sn.Close();
            liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
