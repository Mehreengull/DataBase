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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace PROJECTB01
{
    public partial class Form3 : Form
    {
        public Form3()
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
            String c = "Insert into Clo(Name,DateCreated,DateUpdated) VALUES( @Name, @DateCreated, @DateUpdated)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@DateCreated", (textBox2.Text));
            command.Parameters.AddWithValue("@DateUpdated", (textBox3.Text));
           
            SqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Data Added");
            conn.Close();
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM Clo ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Clo");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Clo";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Size = new System.Drawing.Size(1366, 768);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 4)
            {
                conn.Open();
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                String a = "Delete from Clo ";
                SqlCommand cmd = new SqlCommand(a, conn);

                MessageBox.Show("Data is deleted");
                conn.Close();
            }
        }
        
       
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    
    }
}
