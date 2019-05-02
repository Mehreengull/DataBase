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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String c = "Insert into Rubric(Id,Details, Cloid) VALUES(@Id, @Details, @Cloid)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@id", textBox1.Text);
            command.Parameters.AddWithValue("@Details",textBox2.Text);
            command.Parameters.AddWithValue("@Cloid",Convert.ToInt32(comboBox1.Text));
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
            MessageBox.Show("Data added");
            textBox2.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM Rubric ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Rubric");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Rubric";
        }

       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            string a = "SELECT Id from Clo";
            SqlCommand command = new SqlCommand(a, conn);
            SqlDataReader reader = command.ExecuteReader();
            
           
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
           
            conn.Close();
            

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Size = new System.Drawing.Size(400, 400);

            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            string a = "SELECT Id from Clo";
            SqlCommand command = new SqlCommand(a, conn);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
           // MessageBox.Show("Data Added");
            conn.Close();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 3)
            {
                conn.Open();
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                String a = "Delete from Rubric ";
                SqlCommand cmd = new SqlCommand(a, conn);

                MessageBox.Show("Data is deleted");
                conn.Close();

            }
           
        }
    }
}
