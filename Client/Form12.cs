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
    public delegate void cvan(int a, int b, int c);

    public partial class Form12 : Form
    {
        int sych = 15000;
        int syrj = 10000;
        int disc = 1000;
        int sum = 0;
        public void cost(int a, int b, int d)
        {
            sum = (a - d) + (b - d);
        }

        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form12()
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

        private void button4_Click(object sender, EventArgs e)
        {
           if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into cargovan (id,bid,fcity,tcity,t_departure) values(@id,@bid,@fcity,@tcity,@t_departure)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("bid", textBox2.Text);
                cmd.Parameters.AddWithValue("fcity", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("tcity", comboBox2.Text.ToString());
                cmd.Parameters.AddWithValue("t_departure", textBox3.Text);

                int b = cmd.ExecuteNonQuery();
                if (b>0)
                {
                    MessageBox.Show("Your Cargo is Booked");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }
                else
                {
                    MessageBox.Show("Fill Information Correctly");
                }
            }
            else
            {
               MessageBox.Show("Your Booking Is Failled");
          
           }
            cvan c = this.cost;
            c(sych, syrj, disc);

            MessageBox.Show("Sylhet to Chittagong Cost:" + sum);
           }


        private void Form12_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form2.Id.ToString();
        }
    }
}
