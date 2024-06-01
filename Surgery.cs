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
    public partial class Surgery : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Nika\Desktop\Final_OS_HOSPITAL_MANAGEMENT\Hospital Management\Hospital Management\Database1.mdf; Integrated Security = True");

       

        public Surgery()
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

        void populatecombox1()
        {
            string sql = "select * from Final_Doctor";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdd;
            try
            {
                con.Open();
                DataTable dtt = new DataTable();
                dtt.Columns.Add("DoctorID", typeof(int));
                rdd = cmd.ExecuteReader();
                dtt.Load(rdd);
                comboBox2.ValueMember = "DoctorID";
                comboBox2.DataSource = dtt;
                con.Close();
            }
            catch
            {

            }
        }

        void populate()
        {
            con.Open();
            string query = "select * from Surgery";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var ds = new DataSet();
            da.Fill(ds);
            GV.DataSource = ds.Tables[0];
            con.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void Surgery_Load(object sender, EventArgs e)
        {
            populatecombox();
            populatecombox1();
            populate();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            populatecombox1();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pid = comboBox1.Text;
            string did = comboBox2.Text;
            string surgery = comboBox3.Text;
            string Date = textBox1.Text;
            string cost = textBox2.Text;

            string query = "Insert into Surgery(PatientID, DoctorID, Surgery, Date, Cost)"
                + "values ('"+pid+"', '"+did+"', '"+surgery+"', '"+Date+"', '"+cost+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();

            MessageBox.Show("Surgery added Successfully!");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Surgery set PatientID = '" + comboBox1.Text + "', DoctorID = '" + comboBox2.Text + "', Surgery = '" + comboBox3.Text + "', Date ='" + textBox1.Text + "', Cost = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Surgery Updated Successfully!");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Please enter a Patient ID!");
            }
            else
            {
                con.Open();
                string query = "delete from Surgery where PatientID = " + comboBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!");
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void DiagnosisGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
