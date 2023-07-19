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
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form10()
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

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox2.Text = Form2.Id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into fback (id,feedback) values (@id,@feedback)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@feedback", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Submitted Successfully !");
                    textBox1.Clear();

                }

                else
                {
                    MessageBox.Show("Submit failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
