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

namespace Hospital_Management
{
    public partial class DoctorForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

        public DoctorForm()
        {
            InitializeComponent();
        }

        void populate()
        {
            con.Open();

            string query = "select * from Final_Doctor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();

            h.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            string doctorid1 = textBox1.Text;
            string name = textBox2.Text;
            string lastname = textBox3.Text;
            string birthdate = textBox4.Text;
            string Enterprise = textBox5.Text;
            string year = textBox6.Text;
            string gender = comboBox1.Text;


            int doctorid = int.Parse(doctorid1);

            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

            string query = "INSERT INTO [Final_Doctor] (DoctorID,Name,LastName,BirthDate,Enterprise,YearOfexp,Gender)" +
           "VALUES ('" + doctorid + "','" + name + "','" + lastname + "','" + birthdate + "','" + Enterprise+ "','" +year+ "','" + gender+ "')";


            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor succesfully added!");
            con.Close();
            populate();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.Text = DoctorGV.SelectedRows[0].Cells[0].Value.ToString();
            //textBox2.Text = DoctorGV.SelectedRows[0].Cells[1].Value.ToString();
            //textBox3.Text = DoctorGV.SelectedRows[0].Cells[2].Value.ToString();
            //textBox4.Text = DoctorGV.SelectedRows[0].Cells[3].Value.ToString();
            //textBox5.Text = DoctorGV.SelectedRows[0].Cells[4].Value.ToString();
            //textBox6.Text = DoctorGV.SelectedRows[0].Cells[5].Value.ToString();
            //comboBox1.Text = DoctorGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Enter the Doctor Id");
            else
            {
                con.Open();
                string query = "delete from Final_Doctor where DoctorID = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor successfully Deleted!");
                con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Final_Doctor set Name = '" + textBox2.Text + "', LastName = '" + textBox3.Text + "', BirthDate= '" + textBox4.Text + "', Enterprise = '" + textBox5.Text + "',YearOfexp = '" + textBox6.Text + "', Gender = '" + comboBox1.Text + "' where DoctorID = "+textBox1.Text+"";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Updated Successfully!");
            con.Close();
            populate();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
