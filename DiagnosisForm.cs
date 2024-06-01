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
    public partial class DiagnosisForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

        public DiagnosisForm()
        {
            InitializeComponent();
        }

        void populatecombox()
        {
            string sql = "select * from Final_Patient";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("PatientID", typeof(int));
                rd = cmd.ExecuteReader();
                dt.Load(rd);
                comboBox1.ValueMember = "PatientID";
                comboBox1.DataSource = dt;
                con.Close();
            }
            catch
            {

            }
        }

        string pname;
        void show()
        {
            con.Open();
            string sql = "select * from Final_Patient where PatientID = "+comboBox1.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                pname = dr["Name"].ToString();
                textBox2.Text = pname;
            }
            con.Close();
        }

        void populate()
        {
            con.Open();

            string query = "select * from Final_Diagnosis";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DiagnosisGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
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
            string diagnosisid = textBox1.Text;
            string pid = comboBox1.Text;
            string name = textBox2.Text;
            string symptoms = textBox3.Text;
            string diag = textBox5.Text;
            string medicines = textBox6.Text;


            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

            string query = "INSERT INTO [Final_Diagnosis] (DiagnosisID,PatientID,PatientName,Symptoms,Diagnosis,Medicines)" +
           "VALUES ('" + diagnosisid + "','" + pid + "','" + name + "','" + symptoms + "','" + diag + "','" + medicines + "')";

            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis succesfully added!");
            con.Close();
            populate();
        }

        private void DiagnosisForm_Load(object sender, EventArgs e)
        {
            populatecombox();
            populate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Enter the Diagnosis ID");
            else
            {
                con.Open();
                string query = "delete from Final_Diagnosis where DiagnosisID = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis successfully Deleted!");
                con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Final_Diagnosis set Symptoms = '" + textBox3.Text + "', Diagnosis = '" + textBox5.Text + "', Medicines= '" + textBox6.Text + "' where PatientID = " + comboBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis Updated Successfully!");
            con.Close();
            populate();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("See you Later!");
            Application.Exit();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DiagnosisGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
