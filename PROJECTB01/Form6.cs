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
    public partial class Form6 : Form
    {
        public Form6()
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
            String c = "Insert into AssessmentComponent(Name,TotalMarks,DateCreated,DateUpdated,AssessmentId,RubricId) VALUES( @Name, @TotalMarks, @DateCreated, @DateUpdated, @AssessmentId, @RubricId)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@TotalMarks", (textBox2.Text));
            command.Parameters.AddWithValue("@DateCreated", Convert.ToDateTime(dateTimePicker1.Text));
            command.Parameters.AddWithValue("@DateUpdated", Convert.ToDateTime(dateTimePicker2.Text));
            command.Parameters.AddWithValue("@AssessmentId",  (comboBox1.Text));
            command.Parameters.AddWithValue("@RubricId", (comboBox2.Text));
            SqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Data Added");
            conn.Close();
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet5.AssessmentComponent' table. You can move, or remove it, as needed.
            //this.assessmentComponentTableAdapter.Fill(this.finalDataSet5.AssessmentComponent);
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            string a = "SELECT Id from Assessment";
            string b = "SELECT Id from Rubric";
            SqlCommand command = new SqlCommand(a, conn);
            SqlCommand comm = new SqlCommand(b, conn);
            SqlDataReader reader = command.ExecuteReader();
            SqlDataReader reader1 = comm.ExecuteReader();


            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);

            }
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0]);
            }
            // MessageBox.Show("Data Added");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM AssessmentComponent ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "AssessmentComponent");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "AssessmentComponent";
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
                String a = "Delete from AssessmentComponent ";
                SqlCommand cmd = new SqlCommand(a, conn);

                MessageBox.Show("Data is deleted");
                conn.Close();

            }
        }
    }
}
