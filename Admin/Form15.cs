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
    public partial class Form15 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form15()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select id,bid,fcity,tcity,t_departure FROM cargovan";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            string query1 = "select id,bid,fcity,tcity,t_departure FROM appvanorder";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from cargovan where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", textBox2.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                int Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                int bid = Convert.ToInt32(dt.Rows[0]["bid"].ToString());
                string fcity = dt.Rows[0]["fcity"].ToString();
                string tcity = dt.Rows[0]["tcity"].ToString();
                string t_departure = dt.Rows[0]["t_departure"].ToString();

                textBox4.Text = Id.ToString();
                textBox1.Text = bid.ToString();
                textBox5.Text = fcity;
                textBox6.Text = tcity;
                textBox3.Text = t_departure;

            }
            else
            {
                MessageBox.Show("ID is Incorrect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert Into appvanorder (id,bid,fcity,tcity,t_departure) values (@id,@bid,@fcity,@tcity,@t_departure)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                cmd.Parameters.AddWithValue("@bid", textBox1.Text);
                cmd.Parameters.AddWithValue("@fcity", textBox5.Text);
                cmd.Parameters.AddWithValue("@tcity", textBox6.Text);
                cmd.Parameters.AddWithValue("@t_departure", textBox3.Text);

                int a = cmd.ExecuteNonQuery();
             if(a>0)
                {
                    MessageBox.Show("Booking Approved Successfully");

                    SqlConnection connection = new SqlConnection(cs);

                    SqlCommand cmd2 = new SqlCommand("delete from cargovan where ID=@id", connection);


                    connection.Open();
                    cmd2.Parameters.AddWithValue("@id", textBox2.Text);

                    int b = cmd2.ExecuteNonQuery();
                    if (b > 0)
                    {

                        MessageBox.Show("Moved To Approved Booking");
                        textBox2.Clear();

                    }

                    else
                    {
                        MessageBox.Show("Delete failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
             else
                {
                    MessageBox.Show("Unable to Approve");
                }
                    
             
            }
           
        }

     }
}
