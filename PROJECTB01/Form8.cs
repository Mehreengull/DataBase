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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet6.RubricLevel' table. You can move, or remove it, as needed.
            //this.rubricLevelTableAdapter.Fill(this.finalDataSet6.RubricLevel);
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
           
            string a = "SELECT Id from Rubric";
            SqlCommand command = new SqlCommand(a, conn);
           
            SqlDataReader reader = command.ExecuteReader();
           

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String c = "Insert into RubricLevel(Details,MeasurementLevel,RubricId) VALUES( @Details, @MeasurementLevel,@RubricId)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@Details", textBox2.Text);
            command.Parameters.AddWithValue("@MeasurementLevel", (textBox3.Text));
            command.Parameters.AddWithValue("@RubricId", (comboBox1.Text));

            SqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Data Added");
            conn.Close();
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM RubricLevel ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "RubricLevel");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "RubricLevel";
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
                String a = "Delete from RubricLevel ";
                SqlCommand cmd = new SqlCommand(a, conn);

                MessageBox.Show("Data is deleted");
                conn.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
