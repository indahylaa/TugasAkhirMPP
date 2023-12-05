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

namespace TugasAkhirIndah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-UE14D21\MYSQLSERVER;Initial Catalog=TugasMPPIndah;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from Login where NamaUser = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home panggil = new Home();
                panggil.Show();
            }
            else
            {
                MessageBox.Show("mohon isi user name dan password anda dengan benar !", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
