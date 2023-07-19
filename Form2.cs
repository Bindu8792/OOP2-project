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
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }
        public static string name;
        public static int Id;
        public static string email;
        public static string pass;
        public static string cname;
        public static int phone;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from Client where id = @id and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    name = dt.Rows[0]["name"].ToString();
                    Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    email = dt.Rows[0]["email"].ToString();
                    phone = Convert.ToInt32(dt.Rows[0]["phone"].ToString());
                    cname = dt.Rows[0]["company_name"].ToString();
                    pass = dt.Rows[0]["pass"].ToString();

                    Form6 f6 = new Form6();
                    f6.ShowDialog();
                    this.Hide();
                    f6.Show();
                }
                else
                {
                    MessageBox.Show("Your PassWord is Wrong, Try Again");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }  
    }
}
