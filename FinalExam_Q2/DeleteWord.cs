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
    public partial class DeleteWord : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-153RETS;Initial Catalog=Question2FE;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int Word_Id;

        public DeleteWord()
        {
            InitializeComponent();
            displayData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Word_Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void DeleteWord_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from Dictionary2 where Word_Id='" + Word_Id + "'", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The Data has been Deleted");
            conn.Close();
            displayData();
        }
    }
}
