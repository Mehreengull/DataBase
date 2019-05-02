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

namespace PROJECTB01
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String c = "Insert into ClassAttendance(AttendanceDate) VALUES( @AttendanceDate)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@AttendanceDate",Convert.ToDateTime(dateTimePicker1.Text));
            SqlDataReader reader = command.ExecuteReader();
            MessageBox.Show("Data Added");
            conn.Close();
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet3.ClassAttendance' table. You can move, or remove it, as needed.
           // this.classAttendanceTableAdapter.Fill(this.finalDataSet3.ClassAttendance);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dateTimePicker1.CustomFormat = "yyyy/dd/MM";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM ClassAttendance ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "ClassAttendance");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ClassAttendance";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();

            if (e.ColumnIndex == 0)
            {

                this.dataGridView1.Rows.RemoveAt(e.RowIndex);

                MessageBox.Show("Data is deleted");
               
            }

            conn.Close();
        }
    }
}
