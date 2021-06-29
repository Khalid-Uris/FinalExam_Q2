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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-153RETS;Initial Catalog=Question2FE;Integrated Security=True");
        SqlCommand cmd;
        //SqlDataAdapter adpt;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 obj1 = new Form2();
            obj1.Show();
            this.Hide();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updated obj2 = new Updated();
            obj2.Show();
            this.Hide();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWord obj2 = new DeleteWord();
            obj2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Dictionary2 where Word='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                }
            }
            else
            {
                MessageBox.Show("Word is not Exist");
            }

            conn.Close();
        }
    }
}
