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
    public partial class Form18 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form18()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form18_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select NAME,ID,EMAIL,PHONE,COMPANY_NAME FROM Client";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text !="")           
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from Client where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", textBox7.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                    string name = dt.Rows[0]["name"].ToString();
                    int Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    string email = dt.Rows[0]["email"].ToString();
                    int phone = Convert.ToInt32(dt.Rows[0]["phone"].ToString());
                    string cname = dt.Rows[0]["company_name"].ToString();

                textBox1.Text = name;
                textBox2.Text = Id.ToString();
                textBox4.Text = email;
                textBox5.Text = phone.ToString();
                textBox6.Text = cname;

            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

                SqlConnection con = new SqlConnection(cs);
                string query = "update client set Name=@name, ID=@id, Email=@email, Phone=@phone, Company_Name=@company_name where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                cmd.Parameters.AddWithValue("@company_name", textBox6.Text);

                int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");

            }

            else
            {
                MessageBox.Show("Update failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from client where ID=@id", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@id", textBox2.Text);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DELETED !");
                textBox2.Clear();
            }

            else
            {
                MessageBox.Show("Delete failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }      
    }
}
