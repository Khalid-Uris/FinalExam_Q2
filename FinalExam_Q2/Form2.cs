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

namespace FinalExam_Q2
{
    
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-153RETS;Initial Catalog=Question2FE;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
       

        public Form2()
        {
            InitializeComponent();
            displayData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into Dictionary2 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been saved in the databse");

            conn.Close();
            displayData();
            Clean();
            

        }
        public void displayData()
        {
            conn.Open();

            adpt = new SqlDataAdapter("select * from Dictionary2", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public void Clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

    }
}
