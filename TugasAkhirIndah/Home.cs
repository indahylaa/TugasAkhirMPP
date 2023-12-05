﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace TugasAkhirIndah
{
    public partial class Home : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-UE14D21\MYSQLSERVER;Initial Catalog=TugasMPPIndah;Integrated Security=True");
        public Home()
        {
            InitializeComponent();
        }
        string Jenis_Kelamin;
        string imglocation = "";
        SqlCommand cmd;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Siswa] (NIS,Nama,Kelas,Jurusan,Tempat_Lahir,Tanggal_Lahir,Jenis_kelamin,Alamat,Foto) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+ "','" + textBox6.Text + "','" + textBox4.Text + "','"+dateTimePicker1.Text+ "','" + Jenis_Kelamin + "','" + textBox5.Text + "',@images)";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
            display_data();
            MessageBox.Show("Data insert Sucessfully");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Pria";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Wanita";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Siswa]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Siswa] where NIS = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            display_data();
            MessageBox.Show("Data delete sucessfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Siswa] set NIS ='" + this.textBox1.Text + "', Nama ='" + this.textBox2.Text + "', Kelas ='" + this.textBox2.Text + "', jurusan ='" + this.textBox6.Text + "', Tempat_Lahir ='" + this.textBox4.Text + "',Tanggal_Lahir='" + dateTimePicker1.Text + "', Jenis_Kelamin='" + Jenis_Kelamin + "', Alamat = '" + this.textBox5.Text + "',Foto=@images where NIS='" + this.textBox1.Text + "'";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
            display_data();
            MessageBox.Show("Data update Sucessfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Siswa] where Nama = '" + textBox7.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
        }
    }
}
