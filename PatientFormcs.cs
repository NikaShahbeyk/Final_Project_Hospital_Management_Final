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
    public partial class PatientFormcs : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");
        public PatientFormcs()
        {
            InitializeComponent();
        }

        void populate()
        {
            con.Open();

            string query = "select * from Final_Patient";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();

            h.Show();

            this.Hide();
        }

        private void PatientFormcs_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DoctorGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string lastname = textBox3.Text;
            string birthdate = textBox4.Text;
            string gender = comboBox1.Text;
            string blood = comboBox2.Text;
            string disease = textBox5.Text;
            string addresss = textBox6.Text;
            string phone = textBox7.Text;
  


            int id1 = int.Parse(id);

            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

            string query = "INSERT INTO [Final_Patient] (PatientID,Name,LastName,BirthDate,Gender,BloodGroup,MajorDisease,Address,PhoneNumber)" +
           "VALUES ('" + id + "','" + name + "','" + lastname + "','" + birthdate + "','" + gender + "','" + blood + "','" + disease + "','"+addresss+"', '"+phone+"')";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Patient succesfully added!");
            con.Close();
            populate();
        }

        private void DoctorGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Enter the Patient ID");
            else
            {
                con.Open();
                string query = "delete from Final_Patient where PatientID = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient successfully Deleted!");
                con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Final_Patient set Name = '" + textBox2.Text + "', LastName = '" + textBox3.Text + "', BirthDate= '" + textBox4.Text + "', Gender = '" + comboBox1.Text + "',BloodGroup = '" + comboBox2.Text + "', MajorDisease = '" + textBox5.Text + "', Address= '"+textBox6.Text+"', PhoneNumber = '"+textBox7.Text+"' where PatientID = " + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Updated Successfully!");
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
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        
        }
    }
}
