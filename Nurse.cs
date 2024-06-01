using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class Nurse : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
        public Nurse()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void populate()
        {
            con.Open();

            string query = "select * from Final_Nurse";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGV.DataSource = ds.Tables[0];
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string nurseid1 = textBox1.Text;
            string name = textBox2.Text;
            string lastname = textBox3.Text;
            string birthdate = textBox4.Text;
            string Enterprise = textBox5.Text;
            string year = textBox6.Text;
            string gender = comboBox1.Text;


            int nurseid = int.Parse(nurseid1);

            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

            string query = "INSERT INTO [Final_Nurse] (NurseID,Name,LastName,BirthDate,Enterprise,YearOfexp,Gender)" +
           "VALUES ('" + nurseid + "','" + name + "','" + lastname + "','" + birthdate + "','" + Enterprise + "','" + year + "','" + gender + "')";


            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Nurse succesfully added!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Final_Nurse set Name = '" + textBox2.Text + "', LastName = '" + textBox3.Text + "', BirthDate= '" + textBox4.Text + "', Enterprise = '" + textBox5.Text + "',YearOfexp = '" + textBox6.Text + "', Gender = '" + comboBox1.Text + "' where NurseID = " + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Nurse Updated Successfully!");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Enter the Nurse Id");
            else
            {
                con.Open();
                string query = "delete from Final_Nurse where NurseID = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nurse successfully Deleted!");
                con.Close();
                populate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
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

        private void Nurse_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
