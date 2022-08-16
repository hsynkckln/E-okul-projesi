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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection sn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\nevse\OneDrive\Masaüstü\okulprojesi\okulprojesi\proje.mdf';Integrated Security=True");
        
        
        private void button4_Click(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand komut = new SqlCommand("select sinav1,sinav2,sinav3 from Notlar  where  ogrenci_id=@p1",sn);
            
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            sn.Close();
            
           





        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            sn.Open();
            SqlCommand cmd = new SqlCommand("select * from Dersler", sn);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            DataTable dr = new DataTable();
            dt.Fill(dr);
            comboBox1.DisplayMember = "ders_adi";
            comboBox1.ValueMember = "ders_id";
            comboBox1.DataSource = dr;
            sn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sınav1, sınav2, sınav3, proje;
            double ortalama;
            sınav1 = Convert.ToInt16(textBox3.Text);
            sınav2 = Convert.ToInt16(textBox2.Text);
            sınav3 = Convert.ToInt16(textBox4.Text);
            proje = Convert.ToInt16(textBox5.Text);
            ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
            textBox6.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                textBox7.Text = "True";
            }
            else
            {
                textBox7.Text = "False";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
