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
    public partial class Form2 : Form
    {
    
        public Form2()
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
            String c = "Insert into Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES( @FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)";
            SqlCommand command = new SqlCommand(c, conn);
            command.Parameters.AddWithValue("@FirstName", textBox1.Text);
            command.Parameters.AddWithValue("@LastName", (textBox2.Text));
            command.Parameters.AddWithValue("@Contact", (textBox3.Text));
            command.Parameters.AddWithValue("@Email", (textBox4.Text));
            command.Parameters.AddWithValue("@RegistrationNumber", (textBox5.Text));
            command.Parameters.AddWithValue("@Status", Convert.ToInt32(textBox6.Text));
            SqlDataReader reader = command.ExecuteReader();

            MessageBox.Show("Data Added");
            conn.Close();
            // textBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM Student ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();
            
            dataadapter.Fill(ds, "Student");
            conn.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student";
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
                String a = "UPDATE  Student ";
                SqlCommand cmd1 = new SqlCommand(a, conn);
                SqlDataReader reader = cmd1.ExecuteReader();
            }
            
            conn.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source = (local); Initial Catalog = Final; Integrated Security = True; MultipleActiveResultSets = True";
            SqlConnection conn = new SqlConnection(conURL);
            conn.Open();
            String cmd = "SELECT * FROM Student ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Student");
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("E:/a.pdf", FileMode.Create));
            document.Open();
            Paragraph p = new Paragraph("Select * from Student");
            document.Add(p);
            document.Close();
        }
    }
}
