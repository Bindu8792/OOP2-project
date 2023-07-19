using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CargoManagementSystem
{
    public partial class Form9 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select id,bid,fcity,tcity,t_departure FROM appvanorder where id='"+Form2.Id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SqlConnection con1 = new SqlConnection(cs);
            con1.Open();
            string query1 = "select id,bid,fcity,tcity,t_departure FROM appvanorder where id='" + Form2.Id + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();
            string query2 = "select id,bid,fcity,tcity,t_departure FROM appvanorder where id='" + Form2.Id + "'";
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, con2);
            DataTable data2 = new DataTable();
            sda2.Fill(data2);
            dataGridView3.DataSource = data2;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
    }
}
