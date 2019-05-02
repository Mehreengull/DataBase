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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String c = "Insert into Assessment(Title,DateCreated,TotalMarks,TotalWeightage) VALUES( @Title, @DateCreated, @TotalMarks, @TotalWeightage)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@Title", textBox1.Text);
            command.Parameters.AddWithValue("@DateCreated", Convert.ToDateTime(dateTimePicker1.Text));
            command.Parameters.AddWithValue("@TotalMarks", (textBox2.Text));
            command.Parameters.AddWithValue("@TotalWeightage", (textBox3.Text));
          
            SqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Data Added");
            conn.Close();
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM Assessment ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Assessment");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Assessment";
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet4.Assessment' table. You can move, or remove it, as needed.
           // this.assessmentTableAdapter.Fill(this.finalDataSet4.Assessment);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
           // int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 0)
            {
                conn.Open();
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                String a = "Delete from Assessment ";
                SqlCommand cmd = new SqlCommand(a, conn);

                MessageBox.Show("Data is deleted");
                conn.Close();

            }
        }
    }
}
